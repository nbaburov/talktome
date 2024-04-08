using System.Data.SqlClient;
using Newtonsoft.Json;

namespace SharedLibrary.Data
{
    public class CategoryData
    {
        private readonly string _connectionString;

        public CategoryData(string connectionString)
        {
            _connectionString = connectionString;
            EnsureTablesCreatedAsync().Wait();
        }

        private async Task EnsureTablesCreatedAsync()
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            var createCategoryTable = @"IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Categories') BEGIN CREATE TABLE Categories (CategoryId INT PRIMARY KEY IDENTITY, Name NVARCHAR(255) NOT NULL) END";

            using (var command = new SqlCommand(createCategoryTable, connection))
            {
                await command.ExecuteNonQueryAsync();
            }
        }

        public async Task<int> AddCategory(string name)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = @"INSERT INTO Categories (Name) VALUES (@Name); SELECT SCOPE_IDENTITY();";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", name);

                    return Convert.ToInt32(await command.ExecuteScalarAsync());
                }
            }
        }

        public async Task<bool> EditCategory(int categoryId, string name)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = @"UPDATE Categories SET Name = @Name WHERE CategoryId = @CategoryId";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@CategoryId", categoryId);

                    return await command.ExecuteNonQueryAsync() > 0;
                }
            }
        }

        public async Task<bool> DeleteCategory(int categoryId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = @"DELETE FROM Categories WHERE CategoryId = @CategoryId";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CategoryId", categoryId);

                    return await command.ExecuteNonQueryAsync() > 0;
                }
            }
        }

        public async Task<string> GetCategoryById(int categoryId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = @"SELECT * FROM Categories WHERE CategoryId = @CategoryId";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CategoryId", categoryId);
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            var category = new
                            {
                                CategoryId = reader.GetInt32(reader.GetOrdinal("CategoryId")),
                                Name = reader["Name"].ToString()
                            };
                            return JsonConvert.SerializeObject(category);
                        }
                    }
                }
            }

            return null;
        }

        public async Task<List<string>> GetAllCategories()
        {
            List<string> categoriesList = new List<string>();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = @"SELECT * FROM Categories";

                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var category = new
                            {
                                CategoryId = reader.GetInt32(reader.GetOrdinal("CategoryId")),
                                Name = reader["Name"].ToString()
                            };
                            categoriesList.Add(JsonConvert.SerializeObject(category));
                        }
                    }
                }
            }

            return categoriesList;
        }

    }
}
