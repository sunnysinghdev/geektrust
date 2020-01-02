using System;
using System.Collections.Generic;
namespace WhatFlix.Api.Model
{
    public class User {
        public int Id {get; set;}
        public string Name {get; set;}

        public Preference Preference {get; set;}


    }
    public class Preference
    {
        public List<string> Languages { get; set;}
        public List<string> Movies {get; set;}
        public List<string> Directors {get; set;}

    }
}