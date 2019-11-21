using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Climbing.Guide.Api.Client.Services;
using IdentityModel.Client;

namespace Climbing.Guide.Api.Client {
   public class Client {
      private readonly string _baseAddress;
      private readonly string _idpAddress;
      private TokenResponse _tokenResponse;

      private readonly ConcurrentDictionary<Type, IService> _services = new ConcurrentDictionary<Type, IService>();
      private readonly IDictionary<Type, Type> _serviceTypeMap = new Dictionary<Type, Type>() {
         { typeof(IGradeService), typeof(GradeService) },
      };


      public Client(string idpAddress, string baseAddress) {
         _baseAddress = baseAddress ?? throw new ArgumentNullException(nameof(baseAddress));
         _idpAddress = idpAddress ?? throw new ArgumentNullException(nameof(idpAddress));
      }

      public async Task AuthenticateAsync(string username, string password) {
         // discover endpoints from metadata
         using (var client = new HttpClient()) {
            var disco = await client.GetDiscoveryDocumentAsync(_idpAddress);
            if (disco.IsError) {
               Console.WriteLine(disco.Error);
               throw disco.Exception;
            }

            // request token
            _tokenResponse = await client.RequestPasswordTokenAsync(new PasswordTokenRequest {
               Address = disco.TokenEndpoint,

               UserName = username,
               Password = password,
               Scope = "climbingguideapi"
            });

            if (_tokenResponse.IsError) {
               throw _tokenResponse.Exception;
            }

            Console.WriteLine(_tokenResponse.Json);
         }

      }

      public TService GetService<TService>() where TService : IService {
         return (TService) _services.GetOrAdd(typeof(TService), (type) => {

            if (!_serviceTypeMap.ContainsKey(typeof(TService))) {
               throw new ArgumentOutOfRangeException(nameof(type));
            }

            Type serviceType = _serviceTypeMap[type];

            return (TService) Activator.CreateInstance(serviceType, _baseAddress);
         });
      }
   }
}
