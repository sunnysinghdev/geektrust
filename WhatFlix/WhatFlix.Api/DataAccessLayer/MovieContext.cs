
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using CsvHelper;
using WhatFlix.Api.Model;
using Newtonsoft.Json;

namespace WhatFlix.DataAccessLayer
{
    public class MovieContext : DbContext
    {
        private string connectionString = "";
        public static List<Movie> Movies_cache = new List<Movie>();
        public static List<Credit> Credits_cache = new List<Credit>();
        public List<Movie> Movies = new List<Movie>();
        public List<Credit> Credits = new List<Credit>();
        public MovieContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {
            connectionString = nameOrConnectionString;
            if (Movies_cache.Count > 1)
            {
                Movies = Movies_cache;
                Credits = Credits_cache;
            }
            else
            {
                InitMovie();
                InitCredits();
            }
        }
        private void InitMovie()
        {
            using (var reader = new StreamReader("wwwroot/tmdb_5000_movies.csv"))
            using (var csv = new CsvReader(reader))
            {
                //csv.Configuration.HasHeaderRecord = true;
                var records = csv.GetRecords<Movie>();
                foreach (var item in records)
                {

                    Movies.Add(item);
                }
            }
            Movies_cache = Movies;
        }
        private void InitCredits()
        {
            using (var reader = new StreamReader("wwwroot/tmdb_5000_credits.csv"))
            using (var csv = new CsvReader(reader))
            {
                //csv.Configuration.HasHeaderRecord = true;
                var records = csv.GetRecords<CreditParse>();
                int i = 0;
                foreach (var item in records)
                {
                    if (i > 3)
                    {
                        break;
                    }
                    var crews = JsonConvert.DeserializeObject<Crew[]>(item.Crew);
                    var casts = JsonConvert.DeserializeObject<Cast[]>(item.Cast);

                    Credits.Add(new Credit { Id = item.Id, Title = item.Title, Casts = casts.ToList(), Crews = crews.ToList() });
                }
            }
            Credits_cache = Credits;
        }
    }
}