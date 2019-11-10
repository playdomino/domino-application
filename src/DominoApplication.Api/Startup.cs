using System.Reflection;
using DominoApplication.Api.Filter;
using DominoApplication.Application.Hubs;
using DominoApplication.Application.Infrastructure;
using DominoApplication.Domain.Entities;
using DominoApplication.Persistence;
using DominoApplication.Persistence.Initializer;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Mongo.Migration.Startup.DotNetCore;

namespace DominoApplication.Api
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
            // Add MediatR
            services.AddMediatR(typeof(RequestValidationBehavior<,>).GetTypeInfo().Assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

            // Add DbContext
            services.AddSingleton(new MongoDbSettings
            {
                ServerUrl = Configuration.GetConnectionString("Games"),
                Database = Const.DataBase,
            });
            services.AddScoped<IMongoDbContext, MongoDbContext>();
            services.Configure<MongoMigrationSettings>(options =>
            {
                using (var provider = services.BuildServiceProvider())
                {
                    var setting = provider.GetService<MongoDbSettings>();
                    options.ConnectionString = setting.ConnectionString();
                    options.Database = setting.Database;
                }
            });
            services.AddMigration();

            // Add document
            services.AddOpenApiDocument(document =>
            {
                document.Title = "api";
            });

            services.AddMvc(options => options.Filters.Add(typeof(CustomExceptionFilterAttribute)))
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining(typeof(RequestValidationBehavior<,>)));

            // Customise default API behavour
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.AddTransient<DbContextInitializer>();
           
            services.AddSignalR();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, DbContextInitializer dbInitializer)
        {
            dbInitializer.Initial();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseSwagger();
            app.UseSwaggerUi3();


            app.UseSignalR(routes =>
            {
                routes.MapHub<ObjectMoveHub>("/objectMove");
                routes.MapHub<RoomHub>("/room");
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

        }
    }
}
