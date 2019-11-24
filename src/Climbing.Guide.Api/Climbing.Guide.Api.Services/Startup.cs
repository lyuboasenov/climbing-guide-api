using AutoMapper;
using Climbing.Guide.Api.Application;
using Climbing.Guide.Api.Application.Interfaces;
using Climbing.Guide.Api.Infrastructure;
using Climbing.Guide.Api.Services.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MediatR;

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

         services.AddAutoMapper(typeof(Startup).Assembly);

         services.AddScoped<ICurrentUserService, CurrentUserService>();

         services.AddInfrastructure(Configuration);
         services.AddApplication();

         _services = services;
      }

      // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
      public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
         if (env.IsDevelopment()) {
            app.UseDeveloperExceptionPage();
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
