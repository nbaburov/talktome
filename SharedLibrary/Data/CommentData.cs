using System.Data.SqlClient;
using Newtonsoft.Json;

namespace SharedLibrary.Data
{
    public class CommentData
    {
        private readonly string _connectionString;

        public CommentData(string connectionString)
        {
            _connectionString = connectionString;
            EnsureTablesCreatedAsync().Wait();
        }

        private async Task EnsureTablesCreatedAsync()
        {
            try
            {
                using var connection = new SqlConnection(_connectionString);
                await connection.OpenAsync();

                var createCommentTable = @"IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Comments') BEGIN CREATE TABLE 
            Comments (CommentId INT PRIMARY KEY IDENTITY, 
            Text TEXT NOT NULL, 
            UserId INT, 
            PostId INT, 
            CreationDate 
            DATETIME NOT NULL DEFAULT GETDATE(), 
            FOREIGN KEY (UserId) REFERENCES Users(UserId) , 
            FOREIGN KEY (PostId) REFERENCES Posts(PostId) ON DELETE CASCADE
            ) END";

                using (var command = new SqlCommand(createCommentTable, connection))
                {
                    await command.ExecuteNonQueryAsync();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("❌ Failed to connect to the database. Please check your network connection or VPN settings.");
                throw;
            }
        }

        public async Task<int> AddComment(string text, int userId, int postId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = @"INSERT INTO Comments (Text, UserId, PostId) VALUES (@Text, @UserId, @PostId); SELECT SCOPE_IDENTITY();";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Text", text);
                    command.Parameters.AddWithValue("@UserId", userId);
                    command.Parameters.AddWithValue("@PostId", postId);

                    return Convert.ToInt32(await command.ExecuteScalarAsync());
                }
            }
        }

        public async Task<bool> EditComment(int commentId, string text)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = @"UPDATE Comments SET Text = @Text WHERE CommentId = @CommentId";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Text", text);
                    command.Parameters.AddWithValue("@CommentId", commentId);

                    return await command.ExecuteNonQueryAsync() > 0;
                }
            }
        }

        public async Task<bool> DeleteComment(int commentId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = @"DELETE FROM Comments WHERE CommentId = @CommentId";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CommentId", commentId);

                    return await command.ExecuteNonQueryAsync() > 0;
                }
            }
        }

        public async Task<List<string>> GetCommentsByPost(int postId)
        {
            List<string> commentsList = new List<string>();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = @"SELECT * FROM Comments WHERE PostId = @PostId";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PostId", postId);
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var comment = new
                            {
                                CommentId = reader.GetInt32(reader.GetOrdinal("CommentId")),
                                Text = reader["Text"].ToString(),
                                UserId = reader.GetInt32(reader.GetOrdinal("UserId")),
                                PostId = reader.GetInt32(reader.GetOrdinal("PostId")),
                                CreationDate = reader.GetDateTime(reader.GetOrdinal("CreationDate"))
                            };
                            commentsList.Add(JsonConvert.SerializeObject(comment));
                        }
                    }
                }
            }

            return commentsList;
        }
        public async Task<List<string>> GetAllComments()
        {
            List<string> commentsList = new List<string>();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = @"SELECT * FROM Comments";

                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var comment = new
                            {
                                CommentId = reader.GetInt32(reader.GetOrdinal("CommentId")),
                                Text = reader["Text"].ToString(),
                                UserId = reader.GetInt32(reader.GetOrdinal("UserId")),
                                PostId = reader.GetInt32(reader.GetOrdinal("PostId")),
                                CreationDate = reader.GetDateTime(reader.GetOrdinal("CreationDate"))
                            };
                            commentsList.Add(JsonConvert.SerializeObject(comment));
                        }
                    }
                }
            }

            return commentsList;
        }

        public async Task<string> GetCommentById(int commentId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = @"SELECT * FROM Comments WHERE CommentId = @CommentId";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CommentId", commentId);
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            var comment = new
                            {
                                CommentId = reader.GetInt32(reader.GetOrdinal("CommentId")),
                                Text = reader["Text"].ToString(),
                                UserId = reader.GetInt32(reader.GetOrdinal("UserId")),
                                PostId = reader.GetInt32(reader.GetOrdinal("PostId")),
                                CreationDate = reader.GetDateTime(reader.GetOrdinal("CreationDate"))
                            };
                            return JsonConvert.SerializeObject(comment);
                        }
                    }
                }
            }

            return null;
        }
    }
}
