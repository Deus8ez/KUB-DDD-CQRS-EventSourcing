using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackEnd.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Data.SqlClient;
using KUB.Web.Controllers;
using KUB.Infrastructure.Data;
using KUB.SharedKernel.DTOModels.Tournament.Responses;
using KUB.Core.Models;
using KUB.SharedKernel.DTOModels.Tournament.Requests;
using KUB.SharedKernel.CQRS.Interfaces;
using KUB.SharedKernel.DTOModels.Tournament;
using KUB.Core.Interfaces;
using System.Diagnostics;
using AutoMapper;

namespace KUB.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TournamentsController : BaseController<Tournament, TournamentDto, TournamentRegistrationPostRequest>
    {
        public TournamentsController(IService<TournamentDto, TournamentRegistrationPostRequest> service, IMapper mapper) : base(service, mapper)
        {
        }

        //ManagementGamesDB _context;

        //string _connectionString;
        //public TournamentsController(IConfiguration conf, ManagementGamesDB context)
        //{
        //    _connectionString = conf.GetConnectionString("LocalDB");
        //    _context = context;
        //}

        //[HttpGet]
        //[Route("test")]
        //public List<Tournament> Test()
        //{
        //    Stopwatch stopWatch = new Stopwatch();
        //    stopWatch.Start();
        //    var items = new List<Tournament>();

        //    var connection = ConnectToDb(_connectionString);
        //    using (connection)
        //    {
        //        SqlCommand command = new SqlCommand(
        //          "SELECT TOP 100 * FROM Tournaments;",
        //          connection);
        //        connection.Open();

        //        SqlDataReader reader = command.ExecuteReader();
        //        if (reader.HasRows)
        //        {
        //            while (reader.Read())
        //            {
        //                items.Add(new Tournament
        //                {
        //                    Id = reader.GetGuid(0),
        //                    TournamentName = reader.GetString(1),
        //                    Date = reader.GetDateTime(2),
        //                    StartTime = reader.GetTimeSpan(3),
        //                    EndTime = reader.GetTimeSpan(4),
        //                    LocationId = reader.GetGuid(5),
        //                    TournamentFormatId = reader.GetGuid(6),
        //                    TournamentGridId = reader.GetGuid(7),
        //                    TournamentTypeId = reader.GetGuid(8),
        //                });
        //            }
        //        }
        //        else
        //        {
        //            Console.WriteLine("No rows found.");
        //        }
        //        stopWatch.Stop();
        //        Console.WriteLine("raw" + stopWatch.Elapsed.Milliseconds.ToString());
        //        reader.Close();
        //    }
        //    return items;
        //}

        //[HttpGet]
        //[Route("testOrm")]
        //public List<Tournament> TestOrm()
        //{
        //    Stopwatch stopWatch = new Stopwatch();
        //    stopWatch.Start();
        //    var items = _context.Tournaments.Take(100).ToList();
        //    stopWatch.Stop();

        //    // Get the elapsed time as a TimeSpan value.
        //    TimeSpan ts = stopWatch.Elapsed;
        //    Console.WriteLine("EfCore" + ts.Milliseconds.ToString());

        //    return items;
        //}

        private SqlConnection ConnectToDb(string connectionString)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
        }
    }
}