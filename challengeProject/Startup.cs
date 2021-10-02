using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using challengeProject.Model.Context;
using challengeProject.Business;
using challengeProject.Business.Implementations;
using Microsoft.EntityFrameworkCore;
using challengeProject.Repository;
using challengeProject.Repository.Implementations;
using Serilog;
using Serilog.Core;
using challengeProject.Repository.Generic;
using Microsoft.Net.Http.Headers;
using challengeProject.Hypermedia.Filters;
using challengeProject.Hypermedia.Enricher;

namespace challengeProject
{
    public class Startup
    {
        public IWebHostEnvironment Environment { get; }
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;

            Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddControllers();

            var connection = Configuration["MySQLConnection:MySQLConnectionString"];
            services.AddDbContext<MySQLContext>(options => options.UseMySql(connection,
                                                                            new MySqlServerVersion(new Version(8, 0, 11))
                                                                            )
                                                );

            if (Environment.IsDevelopment())
            {
                MigrateDatabase(connection);
            }

            //Aplicacao trabalha com xml alem de json
            services.AddMvc(options =>
            {
                options.RespectBrowserAcceptHeader = true;

                options.FormatterMappings.SetMediaTypeMappingForFormat("xml", MediaTypeHeaderValue.Parse("application/xml"));

                options.FormatterMappings.SetMediaTypeMappingForFormat("json", MediaTypeHeaderValue.Parse("application/json"));

            })
            .AddXmlSerializerFormatters();

            var filterOptions = new HyperMediaFilterOptions();
            filterOptions.ContentResponseEnricherList.Add(new EmployeeEnricher());
            filterOptions.ContentResponseEnricherList.Add(new ProjectEnricher());

            services.AddSingleton(filterOptions);

            //versionamento de apis
            services.AddApiVersioning();

            //injecao de dependencias
            //camada de negocios
            services.AddScoped<IEmployeeBusiness, EmployeeBusinessImplementation>();
            services.AddScoped<IProjectBusiness, ProjectBusinessImplementation>();
            services.AddScoped<IMembershipBusiness, MembershipBusinessImplementation>();
            
            //camada do banco
            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IMembershipRepository, MembershipRepositoryImplementation>();
            
            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new OpenApiInfo { Title = "challengeProject", Version = "v1" });
            //});
        }

       

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseSwagger();
               //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "challengeProject v1"));
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapControllerRoute("DefaultApi", "{controller=values}/{id?}");
            });
        }

        private void MigrateDatabase(string connection)
        {
            try
            {
                var evolveConnection = new MySql.Data.MySqlClient.MySqlConnection(connection);
                var evolve = new Evolve.Evolve(evolveConnection, msg => Log.Information(msg))
                {
                    Locations = new List<string> { "db/migrations", "db/dataset" },
                    IsEraseDisabled = true,
                };
                evolve.Migrate();


            }
            catch (Exception ex)
            {
                Log.Error("Database Migration Error", ex);
                throw;
            }
        }
    }
}
