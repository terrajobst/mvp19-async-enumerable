using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace iasyncenumerable
{
    public class DataAccess
    {
        private readonly string _connectionString;

        public DataAccess(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async IAsyncEnumerable<Employee> GetAllEmployeesAsync()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var sql = @"
                    SELECT	e.EmployeeID,
		                    e.FirstName,
		                    e.LastName
                    FROM	Employees e
                ";

                using (var cmd = new SqlCommand(sql, connection))
                {
                    var reader = await cmd.ExecuteReaderAsync();
                    while (await reader.ReadAsync())
                    {
                        yield return new Employee
                        {
                            EmployeeId = Convert.ToInt32(reader["EmployeeId"]),
                            FirstName = Convert.ToString(reader["FirstName"]),
                            LastName = Convert.ToString(reader["LastName"])
                        };
                    }
                }
            }
        }
    }
}
