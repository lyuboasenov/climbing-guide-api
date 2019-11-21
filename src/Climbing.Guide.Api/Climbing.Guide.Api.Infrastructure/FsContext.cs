using Climbing.Guide.Api.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Climbing.Guide.Api.Infrastructure {
   public class FsContext : IFsContext {
      private const string BASE_DIRECTORY_SETTINGS_KEY = "FsBaseDirectory";
      private readonly string _baseDirectory;
      public FsContext(IConfiguration configuration) {
         _baseDirectory = (configuration ?? throw new ArgumentNullException(nameof(configuration)))
            .GetSection(BASE_DIRECTORY_SETTINGS_KEY)?.Value ?? throw new ArgumentOutOfRangeException(BASE_DIRECTORY_SETTINGS_KEY);
      }

      public Task WriteFileAsync(string path, byte[] content) {
         return File.WriteAllBytesAsync(Path.Combine(_baseDirectory, path), content);
      }
   }
}
