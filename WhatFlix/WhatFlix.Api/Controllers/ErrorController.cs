using System;
using System.IO;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

//using Newtonsoft.Json;
using WhatFlix.Api.Model;


namespace WhatFlix.Api.Controllers
{
    [ApiController]
    [Route("Error")]
    public class ErrorController : ControllerBase
    {
        private readonly ILogger<ErrorController> _logger;

        public ErrorController(ILogger<ErrorController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public JsonResult Get()
        {
            string s="Fail";//
            using(StreamReader sr = new StreamReader("wwwroot/user_preferences.json")){
                s = sr.ReadToEnd();
                
            }
            return new JsonResult(s);
        }
        [HttpGet("StatusHandler")]
        public Error StatusHandler()
        {
            var er = new Error(){Status=404, Message="Page Not Found!"};
            return er;
        }
    }
}