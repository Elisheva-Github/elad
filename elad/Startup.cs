//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Builder;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.HttpsPolicy;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Hosting;
//using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Hosting;
using BL;
using DL;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
//using Microsoft.OpenApi.Models;
//using AutoMapper;

namespace elad
{
    public class Startup
    {
       // private readonly ILogger<Startup> _logger;
        //public Startup(IConfiguration configuration, ILogger<Startup> logger)
               public Startup(IConfiguration configuration )

        {
            Configuration = configuration;
            //_logger = logger;
        }


        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            //_logger.LogInformation("Enter to the store ");
            services.AddControllers();
            services.AddScoped<IUserBL, UserBL>();
            services.AddScoped<IUserDL, UserDL>();
            //services.AddScoped<ICategoryBL, CategoryBL>();
            //services.AddScoped<ICategoryDL, CategoyryDL>();
            //services.AddScoped<IProductBL, ProductBL>();
            //services.AddScoped<IProductDL, ProductDL>();
            //services.AddScoped<IOrderBL, OrderBL>();
            //services.AddScoped<IOrderDL, OrderDL>();
            //services.AddScoped<IRatingBL, RatingBL>();
            //services.AddScoped<IRatingDL, RatingDL>();

            services.AddDbContext<My_StoreContext>(options => options.UseSqlServer(
              //"Server=D1;Database=My_Store;Trusted_Connection=True;"
              Configuration.GetConnectionString("MyString")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
        

            app.UseStaticFiles();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
