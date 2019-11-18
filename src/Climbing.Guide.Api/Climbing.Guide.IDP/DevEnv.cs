using IdentityServer4.Models;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Climbing.Guide.IDP {
   public static class DevEnv {
      public static List<TestUser> GetUsers() {
         return new List<TestUser>() {
            new TestUser() {
               SubjectId = "61C49A3B-1206-4F8D-B77F-5B27D65FD771",
               Username = "lyubo",
               Password = "pass123$",
               IsActive = true,
               Claims = new [] {
                  new Claim("given_name", "Lyuboslav"),
                  new Claim("family_name", "Asenov"),
                  new Claim("role", "super_admin"),
               }
            },
            new TestUser() {
               SubjectId = "B078ABE6-A4BA-4B33-838A-954BEE3CA726",
               Username = "ogi",
               Password = "pass123$",
               IsActive = true,
               Claims = new [] {
                  new Claim("given_name", "Ognyan"),
                  new Claim("family_name", "Asenov"),
                  new Claim("role", "climber"),
               }
            },
         };
      }

      public static IEnumerable<IdentityResource> GetIdentityResources() {
         return new IdentityResource[] {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile()
         };
      }

      public static IEnumerable<ApiResource> GetApiResources() {
         return new ApiResource[] {

         };
      }

      public static IEnumerable<Client> GetClients() {
         return new Client[] {

         };
      }
   }
}
