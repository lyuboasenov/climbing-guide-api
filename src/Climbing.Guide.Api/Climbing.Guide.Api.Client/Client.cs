using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Climbing.Guide.Api.Client.Services;

namespace Climbing.Guide.Api.Client {
   public class Client {
      private readonly string _baseAddress;
      private readonly ConcurrentDictionary<Type, IService> _services = new ConcurrentDictionary<Type, IService>();
      private readonly IDictionary<Type, Type> _serviceTypeMap = new Dictionary<Type, Type>() {
         { typeof(IGradeService), typeof(GradeService) },
      };

      public Client(string baseAddress) {
         _baseAddress = baseAddress ?? throw new ArgumentNullException(nameof(baseAddress));
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
