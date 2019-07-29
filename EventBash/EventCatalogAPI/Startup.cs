using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventCatalogAPI.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace EventCatalogAPI
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
            //var connectionString = Configuration["ConnectionString"]; //uncomment for IIS express
           var server = Configuration["DatabaseServer"]; //uncomment for Docker
            var database = Configuration["DatabaseName"]; //uncomment for Docker
            var user = Configuration["Databaseuser"]; //uncomment for Docker
            var password = Configuration["DatabaseUserPassword"]; //uncomment for Docker
            var connectionString = $"Server={server};Database={database};User ID={user};Password={password}"; //uncomment for Docker
            services.AddDbContext<EventContext>(options =>
                        options.UseSqlServer(connectionString));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
