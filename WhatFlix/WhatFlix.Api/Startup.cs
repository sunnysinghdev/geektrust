using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using FileContextCore;
using WhatFlix.DataAccessLayer;
using WhatFlix.Common;

namespace WhatFlix.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContextPool<MovieContext>(options => {
            //options.UseModel(Cache.Movies_cache);
            options.UseInMemoryDatabase("sunny");
            });
            services.AddScoped<IMovieRepositry, MovieRepository>();
            services.AddScoped<ICreditRepository, CreditRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePagesWithReExecute("/Error/StatusHandler");

            }
            else{
                app.UseStatusCodePagesWithRedirects("/Error/StatusHandler");
            }
            //app
            app.UseHttpsRedirection();
            //----------index.html-----------------
            app.UseDefaultFiles();
            app.UseStaticFiles();
        
            //-------------------------------------
            
            
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
