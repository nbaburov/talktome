using System.Data.SqlClient;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SharedLibrary.Models;
using System.Collections.Generic;

namespace SharedLibrary.Data
{
    public class FlagData
    {
        private readonly string _connectionString;

        public FlagData(string connectionString)
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

                //! Ask teacher I want to delete flag when post or comment is deleted but I cant set them both cascade
                //! I tried triggers and the logic should work but I get
                // SqlException: The DELETE statement conflicted with the REFERENCE constraint "FK__Flags__PostId__269AB60B". The conflict occurred in database "dbi530788_talktome", table "dbo.Flags", column 'PostId'.
                //! I get that because the post needs to be deleted firstly before trying to delete flag, i think
                // Create Flags table
                var createFlagTable = @"IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Flags')
        BEGIN
            CREATE TABLE Flags (
                FlagId INT PRIMARY KEY IDENTITY(1,1),
                FromUserId INT NOT NULL,
                Resolved BIT NOT NULL DEFAULT 0,
                FlagType VARCHAR(50) NOT NULL,
                CreationDate DATETIME NOT NULL DEFAULT GETDATE(),
                ToUserId INT,
                Reason TEXT,
                PostId INT,
                CommentId INT,
                FOREIGN KEY (FromUserId) REFERENCES Users(UserId), 
                FOREIGN KEY (ToUserId) REFERENCES Users(UserId), 
                FOREIGN KEY (CommentId) REFERENCES Comments(CommentId) ON DELETE CASCADE,
                FOREIGN KEY (PostId) REFERENCES Posts(PostId), 
            )
        END";

                using (var command = new SqlCommand(createFlagTable, connection))
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


        public async Task<bool> IsAlreadyFlagged(int fromUserId, int? toUserId, int? postId, int? commentId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = @"SELECT COUNT(*) FROM Flags WHERE FromUserId = @FromUserId AND ToUserId = @ToUserId AND PostId = @PostId AND CommentId = @CommentId";
                if (toUserId != null)
                {

                    query = @"SELECT COUNT(*) FROM Flags WHERE FromUserId = @FromUserId AND ToUserId = @ToUserId";
                }
                if (postId != null)
                {

                    query = @"SELECT COUNT(*) FROM Flags WHERE FromUserId = @FromUserId AND PostId = @PostId";
                }
                if (commentId != null)
                {

                    query = @"SELECT COUNT(*) FROM Flags WHERE FromUserId = @FromUserId AND CommentId = @CommentId";
                }



                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FromUserId", fromUserId);
                    if (toUserId != null)
                    {
                        command.Parameters.AddWithValue("@ToUserId", toUserId ?? (object)DBNull.Value);
                    }
                    if (postId != null)
                    {
                        command.Parameters.AddWithValue("@PostId", postId ?? (object)DBNull.Value);
                    }
                    if (commentId != null)
                    {
                        command.Parameters.AddWithValue("@CommentId", commentId ?? (object)DBNull.Value);
                    }

                    var count = (int)await command.ExecuteScalarAsync();
                    return count > 0;
                }
            }
        }
        public async Task<int> AddFlagUser(int fromUserId, int toUserId, string reason)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = @"INSERT INTO Flags (FromUserId, ToUserId, FlagType, Reason) VALUES (@FromUserId, @ToUserId, 'User', @Reason); SELECT SCOPE_IDENTITY();";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FromUserId", fromUserId);
                    command.Parameters.AddWithValue("@ToUserId", toUserId);
                    command.Parameters.AddWithValue("@Reason", reason);

                    return Convert.ToInt32(await command.ExecuteScalarAsync());
                }
            }
        }

        public async Task<int> AddFlagPost(int fromUserId, int postId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = @"INSERT INTO Flags (FromUserId, PostId, FlagType) VALUES (@FromUserId, @PostId, 'Post'); SELECT SCOPE_IDENTITY();";


                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FromUserId", fromUserId);
                    command.Parameters.AddWithValue("@PostId", postId);

                    return Convert.ToInt32(await command.ExecuteScalarAsync());
                }
            }
        }

        public async Task<int> AddFlagComment(int fromUserId, int commentId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = @"INSERT INTO Flags (FromUserId, CommentId, FlagType) VALUES (@FromUserId, @CommentId, 'Comment'); SELECT SCOPE_IDENTITY();";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FromUserId", fromUserId);
                    command.Parameters.AddWithValue("@CommentId", commentId);

                    return Convert.ToInt32(await command.ExecuteScalarAsync());
                }
            }
        }

        public async Task<List<FlagUser>> GetAllFlagUsers()
        {
            List<FlagUser> flagUsers = new List<FlagUser>();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = @"SELECT * FROM Flags WHERE FlagType = 'User'";

                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var flagUser = new FlagUser
                            {
                                FlagId = reader.GetInt32(reader.GetOrdinal("FlagId")),
                                FromUserId = reader.GetInt32(reader.GetOrdinal("FromUserId")),
                                Resolved = reader.GetBoolean(reader.GetOrdinal("Resolved")),
                                CreationDate = reader.GetDateTime(reader.GetOrdinal("CreationDate")),
                                ToUserId = reader.IsDBNull(reader.GetOrdinal("ToUserId")) ? 0 : reader.GetInt32(reader.GetOrdinal("ToUserId")),
                                Reason = reader.IsDBNull(reader.GetOrdinal("Reason")) ? string.Empty : reader.GetString(reader.GetOrdinal("Reason"))
                            };
                            flagUsers.Add(flagUser);
                        }
                    }
                }
            }

            return flagUsers;
        }

        public async Task<List<FlagPost>> GetAllFlagPosts()
        {
            List<FlagPost> flagPosts = new List<FlagPost>();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = @"SELECT * FROM Flags WHERE FlagType = 'Post'";

                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var flagPost = new FlagPost
                            {
                                FlagId = reader.GetInt32(reader.GetOrdinal("FlagId")),
                                FromUserId = reader.GetInt32(reader.GetOrdinal("FromUserId")),
                                Resolved = reader.GetBoolean(reader.GetOrdinal("Resolved")),
                                CreationDate = reader.GetDateTime(reader.GetOrdinal("CreationDate")),
                                PostId = reader.IsDBNull(reader.GetOrdinal("PostId")) ? 0 : reader.GetInt32(reader.GetOrdinal("PostId")),
                            };
                            flagPosts.Add(flagPost);
                        }
                    }
                }
            }

            return flagPosts;
        }

        public async Task<List<FlagComment>> GetAllFlagComments()
        {
            List<FlagComment> flagComments = new List<FlagComment>();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = @"SELECT * FROM Flags WHERE FlagType = 'Comment'";

                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var flagComment = new FlagComment
                            {
                                FlagId = reader.GetInt32(reader.GetOrdinal("FlagId")),
                                FromUserId = reader.GetInt32(reader.GetOrdinal("FromUserId")),
                                Resolved = reader.GetBoolean(reader.GetOrdinal("Resolved")),
                                CreationDate = reader.GetDateTime(reader.GetOrdinal("CreationDate")),
                                CommentId = reader.IsDBNull(reader.GetOrdinal("CommentId")) ? 0 : reader.GetInt32(reader.GetOrdinal("CommentId")),
                            };
                            flagComments.Add(flagComment);
                        }
                    }
                }
            }

            return flagComments;
        }

        // Remove flagged user by flag ID
        public async Task<bool> RemoveFlagUser(int flagId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = @"DELETE FROM Flags WHERE FlagId = @FlagId";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FlagId", flagId);

                    return await command.ExecuteNonQueryAsync() > 0;
                }
            }
        }

        // Remove flagged post by flag ID
        public async Task<bool> RemoveFlagPost(int flagId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = @"DELETE FROM Flags WHERE FlagId = @FlagId";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FlagId", flagId);

                    return await command.ExecuteNonQueryAsync() > 0;
                }
            }
        }

        // Remove flagged comment by flag ID
        public async Task<bool> RemoveFlagComment(int flagId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = @"DELETE FROM Flags WHERE FlagId = @FlagId";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FlagId", flagId);

                    return await command.ExecuteNonQueryAsync() > 0;
                }
            }
        }

        public async Task<bool> MarkFlagAsResolved(int flagId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = "UPDATE Flags SET Resolved = 1 WHERE FlagId = @FlagId";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FlagId", flagId);
                    int rowsAffected = await command.ExecuteNonQueryAsync();
                    return rowsAffected > 0;
                }
            }
        }

    }
}
