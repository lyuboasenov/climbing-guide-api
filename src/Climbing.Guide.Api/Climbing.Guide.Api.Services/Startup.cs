using AutoMapper;
using Climbing.Guide.Api.Application;
using Climbing.Guide.Api.Application.Interfaces;
using Climbing.Guide.Api.Infrastructure;
using Climbing.Guide.Api.Services.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Climbing.Guide.Api.Services {
   public class Startup {
      private IServiceCollection _services;
      public Startup(IConfiguration configuration, IWebHostEnvironment environment) {
         Configuration = configuration;
         Environment = environment;
      }

      public IConfiguration Configuration { get; }
      public IWebHostEnvironment Environment { get; }

      // This method gets called by the runtime. Use this method to add services to the container.
      // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
      public void ConfigureServices(IServiceCollection services) {
         services.AddGrpc();
         services.AddAuthorization();
         services.AddAuthentication();

         // HACK: Workaround one time automapper registering issues.
         services.AddAutoMapper(
            typeof(Startup).Assembly,
            typeof(Application.DependencyInjection).Assembly);

         services.AddScoped<ICurrentUserService, CurrentUserService>();

         services.AddInfrastructure(Configuration);
         services.AddApplication();

         _services = services;
      }

      // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
      public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
         if (env.IsDevelopment()) {
            app.UseDeveloperExceptionPage();

            var optionsBuilder = new DbContextOptionsBuilder<Infrastructure.DbContext>();
            optionsBuilder
               .UseSqlServer(Configuration.GetConnectionString("ClimbingGuideConnectionString"))
               .EnableDetailedErrors()
               .EnableSensitiveDataLogging();

            using (var seedingContext = new Infrastructure.DataSeed.DataSeedingContext(optionsBuilder.Options)) {
               seedingContext.Database.EnsureCreated();
               seedingContext.SaveChanges();
            }
         }

         app.UseRouting();

         app.UseAuthentication();
         app.UseAuthorization();

         app.UseEndpoints(endpoints => {
            endpoints.MapGrpcService<GradesService>();
            endpoints.MapGrpcService<CountriesService>();

            endpoints.MapGet("/", async context => {
               await context.Response.WriteAsync("Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");
            });
         });
      }
   }
}
