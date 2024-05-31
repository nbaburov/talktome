using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
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
            try
            {
                using var connection = new SqlConnection(_connectionString);
                await connection.OpenAsync();

                var createLikeTable = @"IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Likes')
                        BEGIN CREATE TABLE Likes (
                            LikeId INT PRIMARY KEY IDENTITY(1,1),
                            LikedBy INT,
                            PostId INT,
                            CreationDate DATETIME NOT NULL DEFAULT GETDATE(),
                            FOREIGN KEY (LikedBy) REFERENCES Users(UserId) ON DELETE CASCADE,
                            FOREIGN KEY (PostId) REFERENCES Posts(PostId) ON DELETE NO ACTION
                        );
                        END";

                using (var command = new SqlCommand(createLikeTable, connection))
                {
                    await command.ExecuteNonQueryAsync();
                }
            }
            catch (System.AggregateException ex)
            {
                Console.WriteLine("❌ Failed to connect to the database. Please check your network connection or VPN settings.");
                throw;
            }
        }

        public async Task<int> AddLike(int likedBy, int postId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = @"INSERT INTO Likes (LikedBy, PostId) VALUES (@LikedBy, @PostId); SELECT SCOPE_IDENTITY();";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LikedBy", likedBy);
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
                                UserId = reader.GetInt32(reader.GetOrdinal("LikedBy")),
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
                                UserId = reader.GetInt32(reader.GetOrdinal("LikedBy")),
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

        public async Task<bool> DoesUserLikePost(int likedBy, int postId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = @"SELECT COUNT(*) FROM Likes WHERE LikedBy = @LikedBy AND PostId = @PostId";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LikedBy", likedBy);
                    command.Parameters.AddWithValue("@PostId", postId);

                    int count = Convert.ToInt32(await command.ExecuteScalarAsync());
                    return count > 0;
                }
            }
        }
    }
}
