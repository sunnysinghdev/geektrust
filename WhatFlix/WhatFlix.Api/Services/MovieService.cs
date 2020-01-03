using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;
using WhatFlix.Common;
using WhatFlix.DataAccessLayer;
using WhatFlix.Api.Model;

namespace WhatFlix.Services
{
    public class MovieService
    {
        private IUnitOfWork unitOfWork;
        public MovieService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public IEnumerable<Object> GetAllMovie(string text)
        {
            //var context =  new MovieContext();
            //context.Movies.AddRange(Cache.Movies_cache);


            var movies = unitOfWork.Movies.GetAll().ToArray();
            var credits = unitOfWork.Credits.GetAll().ToArray();
            var l = (from movie in movies
                    join credit in credits on movie.Id equals credit.Id
                    where movie.Title.ToLower().Contains(text.ToLower()) || 
                    credit.ActorName.ToLower().Contains(text.ToLower()) ||
                    credit.DirectorName.ToLower().Contains(text.ToLower())
                    select new
                    {
                        Id = movie.Id,
                        Name = movie.Title,
                        Actor = credit.ActorName,
                        Director = credit.DirectorName

                    });
                    //Console.WriteLine(l.ToString());
            return l;
        }
        // public IEnumerable<Object> GetUserPreferences(){
        //     IEnumerable<Object> m;
        //     // using (var reader = new StreamReader("wwwroot/tmdb_5000_movies.csv"))
        //     // using (var csv = new CsvReader(reader))
        //     // {
        //     //     //csv.Configuration.HasHeaderRecord = true;
        //     //     var records = csv.GetRecords<Movie>();
        //     m = (from movie in _context.Movies
        //             join credit in _context.Credits on movie.Id equals credit.Id
        //             where movie.Title.ToLower().Contains(text.ToLower()) || 
        //             (credit.Casts.Find(x=> x.Name.ToLower().Contains(text.ToLower())) != null ? true:false) ||
        //             (credit.Crews.Find(x=> x.Job =="Director" && x.Name.ToLower().Contains(text.ToLower())) != null ? true:false)
        //             select new
        //             {
        //                 Id = movie.Id,
        //                 Name = movie.Title,
        //                 Actor = credit.Casts.Find(x=> x.Order == 0),
        //                 Director = credit.Crews.Find(x=> x.Job == "Director")

        //             });
        //     //}

        //     return m;
        //     return null;
        // }
    }
}