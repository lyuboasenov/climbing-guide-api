using Grpc.Core;
using Grpc.Net.Client;
using System;

namespace Climbing.Guide.Api.Client.Services {
   internal class Service<TClient> where TClient : ClientBase<TClient> {
      private readonly object _creationLock = new object();
      private readonly string _baseAddress;
      private readonly GrpcChannelOptions _channelOptions;
      private TClient _client;

      protected TClient Client {
         get {
            lock (_creationLock) {
               if (_client is null) {
                  var channel = _channelOptions is null ? GrpcChannel.ForAddress(_baseAddress) : GrpcChannel.ForAddress(_baseAddress, _channelOptions);
                  _client = (TClient) Activator.CreateInstance(typeof(TClient), channel);
               }
            }

            return _client;
         }
      }

      protected CallOptions CallOptions {
         get {
            return new CallOptions();
         }
      }

      protected Service(string baseAddress) {
         _baseAddress = baseAddress ?? throw new ArgumentNullException(nameof(baseAddress));
      }

      protected Service(string baseAddress, GrpcChannelOptions channelOptions) : this(baseAddress) {
         _channelOptions = channelOptions ?? throw new ArgumentNullException(nameof(channelOptions));
      }
   }
}
