using KUB.Core.Interfaces;
using KUB.Core.Models;
using KUB.SharedKernel.DTOModels;
using KUB.SharedKernel.DTOModels.Participant;
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
    public class TournamentReadRepository : BaseReadRepository, ITournamentReadRepository
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
                        "inner join TournamentFormats on Tournaments.TournamentFormatId = TournamentFormats.Id " +
                        "inner join TournamentGridTypes on Tournaments.TournamentGridId = TournamentGridTypes.Id " +
                        "inner join TournamentTypes on Tournaments.TournamentTypeId = TournamentTypes.Id " +
                        "inner join Locations on Tournaments.LocationId = Locations.Id " +
                        "ORDER BY Tournaments.Date ",
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

        public async Task<List<TournamentDto>> GetAllAsync(int offset, int rowNumber)
        {
            var connection = ConnectToDb(_connectionString);
            var items = new List<TournamentDto>();
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
                        "inner join TournamentFormats on Tournaments.TournamentFormatId = TournamentFormats.Id " +
                        "inner join TournamentGridTypes on Tournaments.TournamentGridId = TournamentGridTypes.Id " +
                        "inner join TournamentTypes on Tournaments.TournamentTypeId = TournamentTypes.Id " +
                        "inner join Locations on Tournaments.LocationId = Locations.Id " +
                        "ORDER BY Tournaments.Date OFFSET @offset ROWS FETCH NEXT @rowNumber ROWS ONLY ",
                  connection);
                command.Parameters.Add("@offset", SqlDbType.Int);
                command.Parameters.Add("@rowNumber", SqlDbType.Int);

                command.Parameters["@offset"].Value = offset;
                command.Parameters["@rowNumber"].Value = rowNumber;

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
                    "inner join TournamentFormats on Tournaments.TournamentFormatId = TournamentFormats.Id " +
                    "inner join TournamentGridTypes on Tournaments.TournamentGridId = TournamentGridTypes.Id " +
                    "inner join TournamentTypes on Tournaments.TournamentTypeId = TournamentTypes.Id " +
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
    }
}
