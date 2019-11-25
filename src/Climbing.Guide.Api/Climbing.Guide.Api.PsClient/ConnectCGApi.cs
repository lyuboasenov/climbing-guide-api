using System;
using System.Management.Automation;

namespace Climbing.Guide.Api.PsClient {
   [Cmdlet("Connect", "CGApi")]
   public class ConnectCGApi : PSCmdlet {
      private const string PARAMETER_SET_SINGLE_SERVER = "SingleServer";
      private const string PARAMETER_SET_MULTI_SERVER = "MultiServer";
      [Parameter(ParameterSetName = PARAMETER_SET_SINGLE_SERVER, Mandatory = true, Position = 0)]
      public string Server { get; set; }

      [Parameter(ParameterSetName = PARAMETER_SET_SINGLE_SERVER, Mandatory = true, Position = 1)]
      public int IdentityPort { get; set; }
      [Parameter(ParameterSetName = PARAMETER_SET_SINGLE_SERVER, Mandatory = true, Position = 2)]
      public int ApiPort { get; set; }



      [Parameter(ParameterSetName = PARAMETER_SET_MULTI_SERVER, Mandatory = true, Position = 0)]
      public string IdentityServer { get; set; }
      [Parameter(ParameterSetName = PARAMETER_SET_MULTI_SERVER, Mandatory = true, Position = 1)]
      public string ApiServer { get; set; }

      protected override void ProcessRecord() {
         base.ProcessRecord();

         UriBuilder identityServerUriBuilder = null;
         UriBuilder apiServerUriBuilder = null;

         if (ParameterSetName == PARAMETER_SET_SINGLE_SERVER) {
            identityServerUriBuilder = new UriBuilder("https", Server, IdentityPort);
            apiServerUriBuilder = new UriBuilder("https", Server, ApiPort);
         } else if (ParameterSetName == PARAMETER_SET_MULTI_SERVER) {
            identityServerUriBuilder = new UriBuilder("https", IdentityServer);
            apiServerUriBuilder = new UriBuilder("https", ApiServer);
         } else {
            throw new ArgumentOutOfRangeException(nameof(ParameterSetName));
         }

         WriteObject(new ClimbingGuideApiConnection() {
            Client = new Client.Client(identityServerUriBuilder.ToString(), apiServerUriBuilder.ToString())
         });
      }
   }
}
