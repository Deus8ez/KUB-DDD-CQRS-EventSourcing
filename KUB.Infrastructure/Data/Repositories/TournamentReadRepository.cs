using KUB.Core.Interfaces;
using KUB.Core.Models;
using KUB.SharedKernel.DTOModels.Tournament;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUB.Infrastructure.Data.Repositories
{
    public class TournamentReadRepository : IReadRepository<TournamentDto>
    {
        string _connectionString;

        public TournamentReadRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("LocalDB");
        }

        public async Task<List<TournamentDto>> GetAllAsync()
        {
            var connection = ConnectToDb(_connectionString);
            var items = new List<TournamentDto>();
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            using (connection)
            {
                SqlCommand command = new SqlCommand(
                    "select top(10) " +
                    "Tournaments.Id, " +
                    "Tournaments.TournamentName, " +
                    "Tournaments.Date, " +
                    "Tournaments.StartTime, " +
                    "Tournaments.EndTime, " +
                    "TournamentFormats.Format, " +
                    "TournamentGridTypes.Type, " +
                    "TournamentTypes.Type, " +
                    "Locations.City " +
                    "from Tournaments " +
                    "inner join TournamentFormats on Tournaments.TournamentFormatId = TournamentFormats.FormatId " +
                    "inner join TournamentGridTypes on Tournaments.TournamentGridId = TournamentGridTypes.GridId " +
                    "inner join TournamentTypes on Tournaments.TournamentTypeId = TournamentTypes.TypeId " +
                    "inner join Locations on Tournaments.LocationId = Locations.Id ", 
                  connection);
                connection.Open();

                await command.ExecuteNonQueryAsync();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        items.Add(new TournamentDto
                        {
                            Id = reader.GetGuid(0),
                            TournamentName = reader.GetString(1),
                            Date = reader.GetDateTime(2),
                            StartTime = reader.GetTimeSpan(3),
                            EndTime = reader.GetTimeSpan(4),
                            TournamentFormat = reader.GetString(5),
                            TournamentGrid = reader.GetString(6),
                            TournamentType = reader.GetString(7),
                            Location = reader.GetString(8),
                        });
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
                stopWatch.Stop();
                Console.WriteLine("raw" + stopWatch.Elapsed.Milliseconds.ToString());
                reader.Close();
            }
            return items;
        }

        public async Task<TournamentDto> GetByIdAsync(Guid id)
        {
            var connection = ConnectToDb(_connectionString);
            var item = new TournamentDto();
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            using (connection)
            {
                SqlCommand command = new SqlCommand(
                    "select " +
                    "Tournaments.Id, " +
                    "Tournaments.TournamentName, " +
                    "Tournaments.Date, " +
                    "Tournaments.StartTime, " +
                    "Tournaments.EndTime, " +
                    "TournamentFormats.Format, " +
                    "TournamentGridTypes.Type, " +
                    "TournamentTypes.Type, " +
                    "Locations.City " +
                    "from Tournaments " +
                    "inner join TournamentFormats on Tournaments.TournamentFormatId = TournamentFormats.FormatId " +
                    "inner join TournamentGridTypes on Tournaments.TournamentGridId = TournamentGridTypes.GridId " +
                    "inner join TournamentTypes on Tournaments.TournamentTypeId = TournamentTypes.TypeId " +
                    "inner join Locations on Tournaments.LocationId = Locations.Id " +
                    "where Tournaments.Id = @ID",
                  connection);
                command.Parameters.Add("@ID", SqlDbType.UniqueIdentifier);
                command.Parameters["@ID"].Value = id;
                connection.Open();

                await command.ExecuteNonQueryAsync();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        item = new TournamentDto
                        {
                            Id = reader.GetGuid(0),
                            TournamentName = reader.GetString(1),
                            Date = reader.GetDateTime(2),
                            StartTime = reader.GetTimeSpan(3),
                            EndTime = reader.GetTimeSpan(4),
                            TournamentFormat = reader.GetString(5),
                            TournamentGrid = reader.GetString(6),
                            TournamentType = reader.GetString(7),
                            Location = reader.GetString(8),
                        };
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
                stopWatch.Stop();
                Console.WriteLine("raw" + stopWatch.Elapsed.Milliseconds.ToString());
                reader.Close();
            }
            return item;
        }

        private SqlConnection ConnectToDb(string connectionString)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
        }
    }
}
