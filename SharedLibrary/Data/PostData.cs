using System.Data.SqlClient;
using Newtonsoft.Json;

namespace SharedLibrary.Data
{
    public class PostData
    {
        private readonly string _connectionString;

        public PostData(string connectionString)
        {
            _connectionString = connectionString;
            EnsureTablesCreatedAsync().Wait();
        }

        private async Task EnsureTablesCreatedAsync()
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            var createPostTable = @"
                IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Posts') 
                BEGIN 
                    CREATE TABLE Posts (
                        PostId INT PRIMARY KEY IDENTITY, 
                        Text TEXT NULL, 
                        ImagePath NVARCHAR(255) NULL, 
                        UserId INT, 
                        CategoryId INT,
                        CreationDate DATETIME NOT NULL DEFAULT GETDATE(), -- Added CreationDate column
                        FOREIGN KEY (UserId) REFERENCES Users(UserId), 
                        FOREIGN KEY (CategoryId) REFERENCES Categories(CategoryId),
                    ) 
                END";

            using (var command = new SqlCommand(createPostTable, connection))
            {
                await command.ExecuteNonQueryAsync();
            }
        }


        // Post CRUD

        public async Task<int> AddPost(string text, string imagePath, int userId, int categoryId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = @"INSERT INTO Posts (Text, ImagePath, UserId, CategoryId) VALUES (@Text, @ImagePath, @UserId, @CategoryId); SELECT SCOPE_IDENTITY();";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Text", text ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@ImagePath", imagePath ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@UserId", userId);
                    command.Parameters.AddWithValue("@CategoryId", categoryId);

                    return Convert.ToInt32(await command.ExecuteScalarAsync());
                }
            }
        }

        public async Task<bool> EditPost(int postId, string text, string imagePath, int categoryId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = @"UPDATE Posts SET Text = @Text, ImagePath = @ImagePath, CategoryId = @CategoryId WHERE PostId = @PostId";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Text", text ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@ImagePath", imagePath ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@CategoryId", categoryId);
                    command.Parameters.AddWithValue("@PostId", postId);

                    return await command.ExecuteNonQueryAsync() > 0;
                }
            }
        }

        public async Task<List<string>> GetAllPosts()
        {
            List<string> postsList = new List<string>();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = @"SELECT * FROM Posts";

                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var post = new
                            {
                                PostId = reader.GetInt32(reader.GetOrdinal("PostId")),
                                Text = reader["Text"].ToString(),
                                ImagePath = reader["ImagePath"].ToString(),
                                UserId = reader.GetInt32(reader.GetOrdinal("UserId")),
                                CategoryId = reader.GetInt32(reader.GetOrdinal("CategoryId")),
                                CreationDate = reader.GetDateTime(reader.GetOrdinal("CreationDate"))
                            };
                            postsList.Add(JsonConvert.SerializeObject(post));
                        }
                    }
                }
            }

            return postsList;
        }

        public async Task<string> GetPostById(int postId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = @"SELECT * FROM Posts WHERE PostId = @PostId";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PostId", postId);
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {

                            var post = new
                            {
                                PostId = reader.GetInt32(reader.GetOrdinal("PostId")),
                                Text = reader["Text"].ToString(),
                                ImagePath = reader["ImagePath"].ToString(),
                                UserId = reader.GetInt32(reader.GetOrdinal("UserId")),
                                CategoryId = reader.GetInt32(reader.GetOrdinal("CategoryId")),
                                CreationDate = reader.GetDateTime(reader.GetOrdinal("CreationDate"))
                            };
                            return JsonConvert.SerializeObject(post);
                        }
                    }
                }
            }

            return null;
        }

        public async Task<List<string>> GetPostsByUser(int userId)
        {
            List<string> postsList = new List<string>();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = @"SELECT * FROM Posts WHERE UserId = @UserId";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserId", userId);
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var post = new
                            {
                                PostId = reader.GetInt32(reader.GetOrdinal("PostId")),
                                Text = reader["Text"].ToString(),
                                ImagePath = reader["ImagePath"].ToString(),
                                UserId = reader.GetInt32(reader.GetOrdinal("UserId")),
                                CategoryId = reader.GetInt32(reader.GetOrdinal("CategoryId")),
                                CreationDate = reader.GetDateTime(reader.GetOrdinal("CreationDate"))
                            };
                            postsList.Add(JsonConvert.SerializeObject(post));
                        }
                    }
                }
            }

            return postsList;
        }

        public async Task<bool> DeletePost(int postId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = @"DELETE FROM Posts WHERE PostId = @PostId";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PostId", postId);

                    return await command.ExecuteNonQueryAsync() > 0;
                }
            }
        }


    }
}
