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

namespace challengeProject
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

            var connection = Configuration["MySQLConnection:MySQLConnectionString"];
            services.AddDbContext<MySQLContext>(options => options.UseMySql(connection,
                                                                            new MySqlServerVersion(new Version(8, 0, 11))
                                                                            )
                                                );
            //vesionamento de apis
            services.AddApiVersioning();

            //injecao de dependencias
            //camada de negocios
            services.AddScoped<IEmployeeBusiness, EmployeeBusinessImplementation>();
            services.AddScoped<IProjectBusiness, ProjectBusinessImplementation>();
            services.AddScoped<IMembershipBusiness, MembershipBusinessImplementation>();
            
            //camada do banco
            services.AddScoped<IEmployeeRepository, EmployeeRepositoryImplementation>();
            services.AddScoped<IProjectRepository, ProjectRepositoryImplementation>();
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
            });
        }
    }
}
