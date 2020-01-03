
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using CsvHelper;
using WhatFlix.Api.Model;
using Newtonsoft.Json;

namespace WhatFlix.DataAccessLayer
{
    public class Cache
    {
        public static List<Movie> Movies_cache { get; set; }
        public static List<Credit> Credits_cache { get; set; }

        public static void Seed()
        {
            if (Cache.Movies_cache != null && Cache.Movies_cache.Count() > 1)
            {
                //Movies = Cache.Movies_cache;
                //Credits = Cache.Credits_cache;
            }
            else
            {
                InitMovie();
                InitCredits();
            }
        }
        private static void InitMovie()
        {
            using (var reader = new StreamReader("wwwroot/tmdb_5000_movies.csv"))
            using (var csv = new CsvReader(reader))
            {
                List<Movie> dbSet = new List<Movie>();
                //Movies_cache = dbSet;
                //csv.Configuration.HasHeaderRecord = true;
                var records = csv.GetRecords<Movie>();
                foreach (var item in records)
                {

                    dbSet.Add(item);
                }
                Movies_cache = dbSet;
                //Movies_cache.AddRange(dbSet);

            }
        }
        private static void InitCredits()
        {
            using (var reader = new StreamReader("wwwroot/tmdb_5000_credits.csv"))
            using (var csv = new CsvReader(reader))
            {
                //csv.Configuration.HasHeaderRecord = true;
                List<Credit> dbSet = new List<Credit>();

                var records = csv.GetRecords<CreditParse>();
                int i = 0;
                foreach (var item in records)
                {
                    if (i > 3)
                    {
                        break;
                    }
                    var crew = JsonConvert.DeserializeObject<Crew[]>(item.Crew)?.ToList()?.Find(x=>x.Job=="Director")?.Name;
                    var cast = JsonConvert.DeserializeObject<Cast[]>(item.Cast)?.ToList()?.Find(x=>x.Order==0)?.Name;
                    dbSet.Add(new Credit { Id = item.Id, 
                    Title = item.Title, 
                    ActorName = (cast == null ? "":cast), 
                    DirectorName = (crew == null ? "":crew) });
                }
                Credits_cache = dbSet;
                //.AddRange(dbSet);
            }
        }

    }
}