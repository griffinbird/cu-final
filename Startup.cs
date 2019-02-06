using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ContosoUniversity.Data;
using Microsoft.EntityFrameworkCore;

namespace ContosoUniversity
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
        string dbHost = Environment.GetEnvironmentVariable("DATABASE_SERVICE_HOST");
        string dbDatabase = Environment.GetEnvironmentVariable("MSSQL_DATABASE");
        string dbUser = Environment.GetEnvironmentVariable("MSSQL_USER");
        string dbPassword = Environment.GetEnvironmentVariable("MSSQL_PASSWORD");
        string dbConnString = Environment.GetEnvironmentVariable("MSSQL_CONN");
        //string dbConnString = $"Server={dbHost};Database={dbDatabase};User Id={dbUser};Password={dbPassword}";
        string connString;
        if ( dbConnString !=null) {
            connString = dbConnString;
        } else {
            connString = Configuration.GetConnectionString("DefaultConnection");
        }
            services.AddDbContext<SchoolContext>(options =>
                options.UseSqlServer(connString));
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
