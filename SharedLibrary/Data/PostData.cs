using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
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
            try
            {
                using var connection = new SqlConnection(_connectionString);
                await connection.OpenAsync();

                var createPostTable = @"
                IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Posts') 
                BEGIN CREATE TABLE Posts (
                        PostId INT PRIMARY KEY IDENTITY(1,1),
                        Text TEXT NULL,
                        ImagePath VARCHAR(255) NULL,
                        PostedBy INT,
                        CategoryId INT,
                        CreationDate DATETIME NOT NULL DEFAULT GETDATE(),
                        FOREIGN KEY (PostedBy) REFERENCES Users(UserId) ON DELETE CASCADE,
                        FOREIGN KEY (CategoryId) REFERENCES Categories(CategoryId) ON DELETE CASCADE
                    );
                END";

                using (var command = new SqlCommand(createPostTable, connection))
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

        // Post CRUD

        public async Task<int> AddPost(string text, string imagePath, int postedBy, int categoryId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = @"INSERT INTO Posts (Text, ImagePath, PostedBy, CategoryId, CreationDate) VALUES (@Text, @ImagePath, @PostedBy, @CategoryId, GETDATE()); SELECT SCOPE_IDENTITY();";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Text", text ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@ImagePath", imagePath ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@PostedBy", postedBy);
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
                                UserId = reader.GetInt32(reader.GetOrdinal("PostedBy")),
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
                                UserId = reader.GetInt32(reader.GetOrdinal("PostedBy")),
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

        public async Task<List<string>> GetPostsByUser(int postedBy)
        {
            List<string> postsList = new List<string>();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = @"SELECT * FROM Posts WHERE PostedBy = @PostedBy";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PostedBy", postedBy);
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var post = new
                            {
                                PostId = reader.GetInt32(reader.GetOrdinal("PostId")),
                                Text = reader["Text"].ToString(),
                                ImagePath = reader["ImagePath"].ToString(),
                                UserId = reader.GetInt32(reader.GetOrdinal("PostedBy")),
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
