using System.Data.SqlClient;
using Newtonsoft.Json;

namespace SharedLibrary.Data
{
    public class LikeData
    {
        private readonly string _connectionString;

        public LikeData(string connectionString)
        {
            _connectionString = connectionString;
            EnsureTablesCreatedAsync().Wait();
        }

        private async Task EnsureTablesCreatedAsync()
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            var createLikeTable = @"IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Likes') BEGIN CREATE TABLE Likes (LikeId INT PRIMARY KEY IDENTITY, UserId INT, PostId INT, CreationDate DATETIME NOT NULL DEFAULT GETDATE(), FOREIGN KEY (UserId) REFERENCES Users(UserId), FOREIGN KEY (PostId) REFERENCES Posts(PostId)) END";

            using (var command = new SqlCommand(createLikeTable, connection))
            {
                await command.ExecuteNonQueryAsync();
            }
        }

        public async Task<int> AddLike(int userId, int postId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = @"INSERT INTO Likes (UserId, PostId) VALUES (@UserId, @PostId); SELECT SCOPE_IDENTITY();";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserId", userId);
                    command.Parameters.AddWithValue("@PostId", postId);

                    return Convert.ToInt32(await command.ExecuteScalarAsync());
                }
            }
        }

        public async Task<bool> DeleteLike(int likeId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = @"DELETE FROM Likes WHERE LikeId = @LikeId";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LikeId", likeId);

                    return await command.ExecuteNonQueryAsync() > 0;
                }
            }
        }

        public async Task<List<string>> GetLikesByPost(int postId)
        {
            List<string> likesList = new List<string>();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = @"SELECT * FROM Likes WHERE PostId = @PostId";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PostId", postId);
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var like = new
                            {
                                LikeId = reader.GetInt32(reader.GetOrdinal("LikeId")),
                                UserId = reader.GetInt32(reader.GetOrdinal("UserId")),
                                PostId = reader.GetInt32(reader.GetOrdinal("PostId")),
                                CreationDate = reader.GetDateTime(reader.GetOrdinal("CreationDate"))
                            };
                            likesList.Add(JsonConvert.SerializeObject(like));
                        }
                    }
                }
            }

            return likesList;
        }

        public async Task<List<string>> GetAllLikes()
        {
            List<string> likesList = new List<string>();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = @"SELECT * FROM Likes";

                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var like = new
                            {
                                LikeId = reader.GetInt32(reader.GetOrdinal("LikeId")),
                                UserId = reader.GetInt32(reader.GetOrdinal("UserId")),
                                PostId = reader.GetInt32(reader.GetOrdinal("PostId"))
                            };
                            likesList.Add(JsonConvert.SerializeObject(like));
                        }
                    }
                }
            }

            return likesList;
        }


        public async Task<bool> DoesUserLikePost(int userId, int postId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = @"SELECT COUNT(*) FROM Likes WHERE UserId = @UserId AND PostId = @PostId";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserId", userId);
                    command.Parameters.AddWithValue("@PostId", postId);

                    int count = Convert.ToInt32(await command.ExecuteScalarAsync());
                    return count > 0;
                }
            }
        }
    }
}
