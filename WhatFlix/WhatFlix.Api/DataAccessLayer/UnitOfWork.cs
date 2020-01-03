using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using WhatFlix.Common;

namespace WhatFlix.DataAccessLayer
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICreditRepository Credits { get; }

        public IMovieRepositry Movies { get; }

        public UnitOfWork(IMovieRepositry _movies, ICreditRepository _credits)
        {
            //Credits = _credit;
            Movies = _movies;
            Credits = _credits;
            //Movies = new MovieRepository(context);
        }
        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}