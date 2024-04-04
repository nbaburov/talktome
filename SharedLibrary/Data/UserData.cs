using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SharedLibrary.Data
{
    public class UserData
    {
        private readonly string _connectionString;

        public UserData(string connectionString)
        {
            _connectionString = connectionString;
            EnsureTablesCreatedAsync().Wait();
        }

        private async Task EnsureTablesCreatedAsync()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = @"
                IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Users]') AND type in (N'U'))
                BEGIN
                    CREATE TABLE Users (
                        UserId INT PRIMARY KEY IDENTITY(1,1),
                        Username VARCHAR(255) NOT NULL,
                        Email VARCHAR(255) NOT NULL,
                        ImagePath VARCHAR(255),
                        PasswordHash VARCHAR(255) NOT NULL,
                        Salt VARCHAR(255) NOT NULL,
                        RegistrationDate DATETIME NOT NULL,
                        UserType VARCHAR(50) NOT NULL,
                        Bio VARCHAR(MAX),
                        Status INT,
                        Permission INT
                    )
                END";

                using (var command = new SqlCommand(query, connection))
                {
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        // Add a User
        public async Task AddUser(string username, string email, string imagePath, string passwordHash, string salt, DateTime registrationDate, string userType, string bio = null, int? status = null, int? permission = null)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = @"
                INSERT INTO Users (Username, Email, ImagePath, PasswordHash,Salt, RegistrationDate, UserType, Bio, Status, Permission) 
                VALUES (@Username, @Email, @ImagePath, @PasswordHash, @Salt, @RegistrationDate, @UserType, @Bio, @Status, @Permission)";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@ImagePath", imagePath ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@PasswordHash", passwordHash);
                    command.Parameters.AddWithValue("@Salt", salt);
                    command.Parameters.AddWithValue("@RegistrationDate", registrationDate);
                    command.Parameters.AddWithValue("@UserType", userType); // "Admin" or "Client"
                    command.Parameters.AddWithValue("@Bio", bio ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Status", status.HasValue ? status.Value : (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Permission", permission.HasValue ? permission.Value : (object)DBNull.Value);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        // Read (Get) a single User by ID
        public async Task<string> GetUserById(int userId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = "SELECT * FROM Users WHERE UserId = @UserId";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserId", userId);
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            var userType = reader["UserType"].ToString();
                            var user = new
                            {
                                UserId = reader.GetInt32(reader.GetOrdinal("UserId")),
                                Username = reader["Username"].ToString(),
                                Email = reader["Email"].ToString(),
                                ImagePath = reader["ImagePath"].ToString(),
                                PasswordHash = reader["PasswordHash"].ToString(),
                                Salt = reader["Salt"].ToString(),
                                RegistrationDate = reader.GetDateTime(reader.GetOrdinal("RegistrationDate")),
                                UserType = userType,
                                Bio = reader["Bio"] as string,
                                Status = reader["Status"] as int?,
                                Permission = reader["Permission"] as int?
                            };
                            return JsonConvert.SerializeObject(user);
                        }
                    }
                }
            }
            return null;
        }

        // Read (Get) all Users
        public async Task<List<string>> GetAllUsers()
        {
            List<string> userList = new List<string>();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = "SELECT * FROM Users";

                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var userType = reader["UserType"].ToString();
                            var user = new
                            {
                                UserId = reader.GetInt32(reader.GetOrdinal("UserId")),
                                Username = reader["Username"].ToString(),
                                Email = reader["Email"].ToString(),
                                ImagePath = reader["ImagePath"].ToString(),
                                PasswordHash = reader["PasswordHash"].ToString(),
                                Salt = reader["Salt"].ToString(),
                                RegistrationDate = reader.GetDateTime(reader.GetOrdinal("RegistrationDate")),
                                UserType = userType,
                                Bio = reader["Bio"] as string,
                                Status = reader["Status"] as int?,
                                Permission = reader["Permission"] as int?
                            };
                            userList.Add(JsonConvert.SerializeObject(user));
                        }
                    }
                }
            }

            return userList;
        }


        // Update a User
        public async Task UpdateUser(int userId, string username, string email, string imagePath, string passwordHash, string salt, DateTime registrationDate, string userType, string bio = null, int? status = null, int? permission = null)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = @"
                UPDATE Users 
                SET 
                    Username = @Username, 
                    Email = @Email, 
                    ImagePath = @ImagePath, 
                    PasswordHash = @PasswordHash, 
                    Salt = @Salt, 
                    RegistrationDate = @RegistrationDate,
                    UserType = @UserType,
                    Bio = @Bio, 
                    Status = @Status, 
                    Permission = @Permission
                WHERE UserId = @UserId";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserId", userId);
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@ImagePath", imagePath ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@PasswordHash", passwordHash);
                    command.Parameters.AddWithValue("@Salt", salt);
                    command.Parameters.AddWithValue("@RegistrationDate", registrationDate);
                    command.Parameters.AddWithValue("@UserType", userType);
                    command.Parameters.AddWithValue("@Bio", bio ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Status", status.HasValue ? status.Value : (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Permission", permission.HasValue ? permission.Value : (object)DBNull.Value);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        // Delete a User
        public async Task DeleteUser(int userId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = "DELETE FROM Users WHERE UserId = @UserId";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserId", userId);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

    }
}
