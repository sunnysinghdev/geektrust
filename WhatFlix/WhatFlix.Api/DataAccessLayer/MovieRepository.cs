using System;
using System.Web;
using System.IO;
using System.Linq;
//using System.Reflection;
using System.Data.OleDb;
using System.Data;
using System.Text;
using System.Collections.Generic;
using WhatFlix.Common;
using System.Data.Common;
using WhatFlix.Api.Model;
using CsvHelper;
using System.Data.Entity;

namespace WhatFlix.DataAccessLayer
{
    public class MovieRepository
    {
        MovieContext _context;
        public MovieRepository(MovieContext context)
        {
            _context = context;
        }
        public IEnumerable<Object> Get(string text)
        {
            IEnumerable<Object> m;
            // using (var reader = new StreamReader("wwwroot/tmdb_5000_movies.csv"))
            // using (var csv = new CsvReader(reader))
            // {
            //     //csv.Configuration.HasHeaderRecord = true;
            //     var records = csv.GetRecords<Movie>();
            m = (from movie in _context.Movies
                    join credit in _context.Credits on movie.Id equals credit.Id
                    where movie.Title.ToLower().Contains(text.ToLower()) || 
                    (credit.Casts.Find(x=> x.Name.ToLower().Contains(text.ToLower())) != null ? true:false) ||
                    (credit.Crews.Find(x=> x.Job =="Director" && x.Name.ToLower().Contains(text.ToLower())) != null ? true:false)
                    select new
                    {
                        Id = movie.Id,
                        Name = movie.Title,
                        Actor = credit.Casts.Find(x=> x.Order == 0),
                        Director = credit.Crews.Find(x=> x.Job == "Director")

                    });
            //}

            return m;
        }
        public IEnumerable<Movie> GetMovie()
        {
            IEnumerable<Movie> m = new List<Movie>();
            // using (var reader = new StreamReader("wwwroot/tmdb_5000_movies.csv"))
            // using (var csv = new CsvReader(reader))
            // {
            //     //csv.Configuration.HasHeaderRecord = true;
            //     var records = csv.GetRecords<Movie>();
            m = (from d in _context.Movies
                 where d.Title.Contains("ate")
                 select d).ToArray();
            //}

            return m;
        }

        public IEnumerable<Credit> GetCredit()
        {
            IEnumerable<Credit> m = new List<Credit>();
            // using (var reader = new StreamReader("wwwroot/tmdb_5000_movies.csv"))
            // using (var csv = new CsvReader(reader))
            // {
            //     //csv.Configuration.HasHeaderRecord = true;
            //     var records = csv.GetRecords<Movie>();
            m = (from d in _context.Credits select d).ToArray();
            //}

            return m;
        }
        public IEnumerable<Movie> GetAll()
        {
            // Newtonsoft.Json.Converters.BsonObjectIdConverter\
            //ConnectionStringSettings csv = ConfigurationManager.ConnectionStrings["csv"];
            string conStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='\\wwwroot\\tmdb_5000_movies.csv';Extended Properties='text;HDR=Yes;FMT=Delimited';";
            List<Movie> stats = new List<Movie>();

            using (OleDbConnection cn = new OleDbConnection(conStr))
            {
                cn.Open();
                using (OleDbCommand cmd = cn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM [Stats.csv]";
                    cmd.CommandType = CommandType.Text;
                    using (OleDbDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        int original_title = reader.GetOrdinal("original_title");
                        int fieldDate = reader.GetOrdinal("date");
                        int fieldTeamOne = reader.GetOrdinal("teamone");
                        int fieldTeamTwo = reader.GetOrdinal("teamtwo");
                        int fieldScore = reader.GetOrdinal("score");

                        foreach (DbDataRecord record in reader)
                        {
                            stats.Add(new Movie
                            {
                                Title = record.GetString(original_title),
                                //Director = "",//record.GetDateTime(fieldDate),
                                //Language = record.GetString(fieldTeamOne),
                                //Actor = record.GetString(fieldTeamTwo),
                            });
                        }
                    }
                }
            }

            foreach (var stat in stats)
            {
                Console.WriteLine("Sport: {0}", stat.Title);
            }
            return stats;
        }
    }
}