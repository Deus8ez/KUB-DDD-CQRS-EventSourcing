using KUB.Core.Interfaces;
using KUB.SharedKernel.DTOModels;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUB.Infrastructure.Data.Repositories
{
    public class SchoolReadRepository : BaseReadRepository, ISchoolReadRepository
    {
        string _connectionString;
        public SchoolReadRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("LocalDB");
        }
        public async Task<List<SchoolDto>> GetAllAsync()
        {
            var connection = ConnectToDb(_connectionString);
            var items = new List<SchoolDto>();
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            using (connection)
            {
                SqlCommand command = new SqlCommand
                                        (
                                        "select " +
                                        "Schools.Id, " +
                                        "Schools.SchoolName " +
                                        "from " +
                                        "Schools "
                                        , connection);
                connection.Open();
                await command.ExecuteNonQueryAsync();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        items.Add(new SchoolDto
                        {
                            Id = reader.GetGuid(0),
                            SchoolName = reader.GetString(1),
                        });
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
            }

            Console.WriteLine("sending roles");
            return items;
        }

        public Task<List<SchoolDto>> GetAllAsync(int offset, int rowNumber)
        {
            throw new NotImplementedException();
        }

        public Task<SchoolDto> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
