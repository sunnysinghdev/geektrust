using System;
using System.Collections.Generic;
using CsvHelper.Configuration.Attributes;
using WhatFlix.Common;
namespace WhatFlix.Api.Model
{
    public class Movie
    {
        [Name("id")]
        public int Id {get; set;}
        [Name("title")]
        public string Title { get; set; }
        // public string Director { get; set; }
        // public string Actor { get; set; }
        // public string Language { get; set; }
    }
}