using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using NLog.Extensions.Logging;

using Microsoft.Extensions.Configuration;

using Microsoft.EntityFrameworkCore;
using Store.Api.Entities;
using Store.Api.Services;

namespace Store.Api
{
    public class Startup
    {
        public static IConfigurationRoot Configuration;

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appSettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appSettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddMvc()
                // adds output formatters for xml
                .AddMvcOptions(o => o.OutputFormatters.Add(
                    new XmlDataContractSerializerOutputFormatter()));
          


            // Adds StoreContext to use sql server / Gets from appSettings.json

            var connectionString = Startup.Configuration["connectionStrings:storeInfoDBConnectionString"];
            services.AddDbContext<StoreContext>(o => o.UseSqlServer(connectionString));
            services.AddScoped<IProductRepository, ProductRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, StoreContext storeContext)
        {
            loggerFactory.AddConsole();

            loggerFactory.AddDebug();

            //loggerFactory.AddProvider(new NLog.Extensions.Logging.NLogLoggerProvider());

            loggerFactory.AddNLog();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler();
            }

            storeContext.EnsureSeedDataForContext();

            app.UseStatusCodePages();

            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Models.ProductForCreationDto, Entities.Product>();
                cfg.CreateMap<Entities.Product, Models.ProductDto>();
                cfg.CreateMap<Models.ProductDto, Entities.Product>();
                cfg.CreateMap<Models.ProductForUpdateDto, Entities.Product>();
                cfg.CreateMap<Entities.Product, Models.ProductForUpdateDto>();
                //cfg.CreateMap<Entities.City, Models.CityDto>();
                //cfg.CreateMap<Entities.PointOfInterest, Models.PointOfInterestDto>();
                //cfg.CreateMap<Models.PointOfInterestForCreationDto, Entities.PointOfInterest>();
                //cfg.CreateMap<Models.PointOfInterestForUpdateDto, Entities.PointOfInterest>();
                //cfg.CreateMap<Entities.PointOfInterest, Models.PointOfInterestForUpdateDto>();
            });

            app.UseMvc();
            

            //app.Run((context) =>
            //{
            //    throw new Exception("Example Exception.");
            //});
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});
        }
    }
}

