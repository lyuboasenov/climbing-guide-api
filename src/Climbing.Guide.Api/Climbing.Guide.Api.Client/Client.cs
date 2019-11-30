using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Climbing.Guide.Api.Client.Services;
using IdentityModel.Client;

namespace Climbing.Guide.Api.Client {
   public class Client {
      private readonly string _serviceAddress;
      private readonly string _idpAddress;
      private TokenResponse _tokenResponse;

      private readonly ConcurrentDictionary<Type, IService> _services = new ConcurrentDictionary<Type, IService>();
      private readonly IDictionary<Type, Type> _serviceTypeMap = new Dictionary<Type, Type>() {
         { typeof(IGradesService), typeof(GradesService) },
         { typeof(ICountriesService), typeof(CountriesService) },
         { typeof(IAreasService), typeof(AreasService) },
      };


      public Client(string idpAddress, string serviceAddress) {
         _serviceAddress = serviceAddress ?? throw new ArgumentNullException(nameof(serviceAddress));
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
         return (TService) GetService(typeof(TService));
      }

      public IService GetService(Type serviceType) {
         if (!typeof(IService).IsAssignableFrom(serviceType)) {
            throw new ArgumentOutOfRangeException(nameof(serviceType));
         }

         return _services.GetOrAdd(serviceType, (type) => {

            if (!_serviceTypeMap.ContainsKey(type)) {
               throw new ArgumentOutOfRangeException(nameof(type));
            }

            Type serviceType = _serviceTypeMap[type];

            return (IService) Activator.CreateInstance(serviceType, _serviceAddress);
         });
      }

      public IEnumerable<Type> GetAvailableServices() {
         return _serviceTypeMap.Keys;
      }
   }
}
