
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Climbing.Guide.IDP {
   public class Startup {
      public IWebHostEnvironment Environment { get; }
      public IConfiguration Configuration { get; }

      public Startup(IWebHostEnvironment environment, IConfiguration configuration) {
         Environment = environment;
         Configuration = configuration;
      }

      public void ConfigureServices(IServiceCollection services) {
         services.AddControllersWithViews();

         services.AddIdentityServer(options => {
               options.Events.RaiseErrorEvents = true;
               options.Events.RaiseInformationEvents = true;
               options.Events.RaiseFailureEvents = true;
               options.Events.RaiseSuccessEvents = true;
            }).
            AddDeveloperSigningCredential().
            AddTestUsers(DevEnv.GetUsers()).
            AddInMemoryIdentityResources(DevEnv.GetIdentityResources()).
            AddInMemoryApiResources(DevEnv.GetApiResources()).
            AddInMemoryClients(DevEnv.GetClients());
      }

      // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
      public void Configure(IApplicationBuilder app) {
         if (Environment.IsDevelopment()) {
            app.UseDeveloperExceptionPage();
         }

         app.UseStaticFiles();

         app.UseRouting();
         app.UseIdentityServer();
         app.UseAuthorization();
         app.UseEndpoints(endpoints => {
            endpoints.MapDefaultControllerRoute();
         });
      }
   }
}
