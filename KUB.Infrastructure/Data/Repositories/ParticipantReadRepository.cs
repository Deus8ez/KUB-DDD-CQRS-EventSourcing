using KUB.Core.Interfaces;
using KUB.SharedKernel.DTOModels.Participant;
using KUB.SharedKernel.DTOModels.Tournament;
using Microsoft.Data.SqlClient;
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
    public class ParticipantReadRepository : BaseReadRepository, IParticipantReadRepository
    {
        string _connectionString;

        public ParticipantReadRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("LocalDB");
        }

        public Task<List<ParticipantAndRolesDto>> GetAllAsync(int offset, int rowNumber)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ParticipantAndRolesDto>> GetAllAsyncNotInTournament(Guid tournamentId)
        {
            var connection = ConnectToDb(_connectionString);
            var items = new ParticipantAndRolesDto();
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            using (connection)
            {
                SqlCommand command = new SqlCommand
                                        (
                                            "select " +
                                            "Participants.Id, " +
                                            "Participants.Name, " +
                                            "Participants.Surname, " +
                                            "Participants.Patronym, " +
                                            "Participants.DateOfBirth, " +
                                            "Participants.ClassicGameRank, " +
                                            "Participants.BlitzGameRank, " +
                                            "Participants.CanBeAJury, " +
                                            "Schools.SchoolName " +
                                            "from " +
                                            "Participants " +
                                            "left join ParticipantInTournaments on Participants.Id = ParticipantInTournaments.ParticipantId " +
                                            "left join ParticipantInSchools on Participants.Id = ParticipantInSchools.ParticipantId " +
                                            "left join Schools on Schools.Id = ParticipantInSchools.SchoolId " +
                                            "where ParticipantInTournaments.ParticipantId is null " +
                                            "union " +
                                            "select " +
                                            "Participants.Id, " +
                                            "Participants.Name, " +
                                            "Participants.Surname, " +
                                            "Participants.Patronym, " +
                                            "Participants.DateOfBirth, " +
                                            "Participants.ClassicGameRank, " +
                                            "Participants.BlitzGameRank, " +
                                            "Participants.CanBeAJury, " +
                                            "Schools.SchoolName " +
                                            "from " +
                                            "Participants " +
                                            "left join ParticipantInTournaments on Participants.Id = ParticipantInTournaments.ParticipantId " +
                                            "left join ParticipantInSchools on Participants.Id = ParticipantInSchools.ParticipantId " +
                                            "left join Schools on Schools.Id = ParticipantInSchools.SchoolId " +
                                            "where ParticipantInTournaments.TournamentId != @tournamentId"
                                        , connection);
                command.Parameters.Add("@tournamentId", SqlDbType.UniqueIdentifier);
                command.Parameters["@tournamentId"].Value = tournamentId;
                connection.Open();
                await command.ExecuteNonQueryAsync();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        items.Participants.Add(new ParticipantDto
                        {
                            Id = reader.GetGuid(0),
                            Name = reader.GetString(1),
                            Surname = reader.GetString(2),
                            Patronym = reader.GetString(3),
                            DateOfBirth = reader.GetDateTime(4),
                            ClassicGameRank = reader.IsDBNull(5) ? null : reader.GetInt32(5),
                            BlitzGameRank = reader.IsDBNull(6) ? null : reader.GetInt32(6),
                            CanBeAJury = reader.GetBoolean(7),
                            SchoolName = reader.IsDBNull(8) ? null : reader.GetString(8),
                        });
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
                reader.Close();

                command.CommandText = "select " +
                                        "id, " +
                                        "roleName " +
                                        "from " +
                                        "roles ";

                await command.ExecuteNonQueryAsync();
                reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        items.Roles.Add(new RoleDto
                        {
                            Id = reader.GetGuid(0),
                            RoleName = reader.GetString(1),
                        });
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
                reader.Close();

            }

            var result = new List<ParticipantAndRolesDto>();
            result.Add(items);
            Console.WriteLine("sending roles");
            return result;
        }

        public async Task<List<ParticipantAndRolesDto>> GetAllAsync(Guid tournamentId)
        {
            var connection = ConnectToDb(_connectionString);
            var items = new ParticipantAndRolesDto();
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            using (connection)
            {
                SqlCommand command = new SqlCommand(
                            "select " +
                            "Participants.Id, " +
                            "Participants.Name, " +
                            "Participants.Surname, " +
                            "Participants.Patronym, " +
                            "Participants.DateOfBirth, " +
                            "Participants.ClassicGameRank, " +
                            "Participants.BlitzGameRank, " +
                            "Participants.CanBeAJury, " +
                            "Schools.SchoolName, " +
                            "Roles.RoleName " +
                            "from " +
                            "Participants " +
                            "inner join ParticipantInTournaments on Participants.Id = ParticipantInTournaments.ParticipantId " +
                            "left join ParticipantInSchools on Participants.Id = ParticipantInSchools.ParticipantId " +
                            "left join Schools on Schools.Id = ParticipantInSchools.SchoolId " +
                            "inner join Roles on ParticipantInTournaments.RoleId = Roles.Id " +
                            "where ParticipantInTournaments.TournamentId = @tournamentId",
                  connection);
                command.Parameters.Add("@tournamentId", SqlDbType.UniqueIdentifier);
                command.Parameters["@tournamentId"].Value = tournamentId;
                connection.Open();

                await command.ExecuteNonQueryAsync();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        items.Participants.Add(new ParticipantDto
                        {
                            Id = reader.GetGuid(0),
                            Name = reader.GetString(1),
                            Surname = reader.GetString(2),
                            Patronym = reader.GetString(3),
                            DateOfBirth = reader.GetDateTime(4),
                            ClassicGameRank = reader.IsDBNull(5) ? null : reader.GetInt32(5),
                            BlitzGameRank = reader.IsDBNull(6) ? null : reader.GetInt32(6),
                            CanBeAJury = reader.GetBoolean(7),
                            SchoolName = reader.IsDBNull(8) ? "Не выбрана" : reader.GetString(8),
                            RoleName = reader.IsDBNull(9) ? "Не выбрана" : reader.GetString(9),
                            IsInTournament = true,
                        });
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
                reader.Close();
                
                stopWatch.Stop();
                Console.WriteLine("raw" + stopWatch.Elapsed.Milliseconds.ToString());
                reader.Close();
            }

            var result = new List<ParticipantAndRolesDto>();
            result.Add(items);
            Console.WriteLine("sending roles");
            return result;
        }


        public async Task<List<ParticipantAndRolesDto>> GetAllAsync()
        {
            var connection = ConnectToDb(_connectionString);
            var items = new ParticipantAndRolesDto();
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            using (connection)
            {
                SqlCommand command = new SqlCommand(
                            "select " +
                            "Participants.Id, " +
                            "Participants.Name, " +
                            "Participants.Surname, " +
                            "Participants.Patronym, " +
                            "Participants.DateOfBirth, " +
                            "Participants.ClassicGameRank, " +
                            "Participants.BlitzGameRank, " +
                            "Participants.CanBeAJury, " +
                            "Schools.SchoolName " +
                            "from Participants " +
                            "left join ParticipantInSchools on Participants.Id = ParticipantInSchools.ParticipantId " +
                            "left join Schools on Schools.Id = ParticipantInSchools.SchoolId " +
                            "order by " +
                            "Participants.DateOfBirth ",
                  connection);

                connection.Open();

                await command.ExecuteNonQueryAsync();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        items.Participants.Add(new ParticipantDto
                        {
                            Id = reader.GetGuid(0),
                            Name = reader.GetString(1),
                            Surname = reader.GetString(2),
                            Patronym = reader.GetString(3),
                            DateOfBirth = reader.GetDateTime(4),
                            ClassicGameRank = reader.IsDBNull(5) ? null : reader.GetInt32(5),
                            BlitzGameRank = reader.IsDBNull(6) ? null : reader.GetInt32(6),
                            CanBeAJury = reader.GetBoolean(7),
                            SchoolName = reader.IsDBNull(8) ? null : reader.GetString(8),
                        });
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
                reader.Close();
                command.CommandText = "select Id, RoleName from roles";

                await command.ExecuteNonQueryAsync();
                reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        items.Roles.Add(new RoleDto
                        {
                            Id = reader.GetGuid(0),
                            RoleName = reader.GetString(1),
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

            var result = new List<ParticipantAndRolesDto>();
            result.Add(items);
            Console.WriteLine("sending roles");
            return result;
        }

        public Task<ParticipantAndRolesDto> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

    }
}
