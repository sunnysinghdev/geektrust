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
    public class CreditRepository : Repository<Credit>, ICreditRepository
    {
        MovieContext _context;
        public CreditRepository(MovieContext context):base(context)
        {
            _context = context;
        }

        public IEnumerable<Credit> GetByActor(string text)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> GetByTitle(string text)
        {
            throw new NotImplementedException();
        }
    }
}