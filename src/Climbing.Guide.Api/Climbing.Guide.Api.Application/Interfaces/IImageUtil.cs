using System.IO;
using System.Threading.Tasks;

namespace Climbing.Guide.Api.Application.Interfaces {
   public interface IImageUtil {
      Task<Stream> GetThumbAsync(Stream image, int maxDimension);
      Task<byte[]> GetThumbAsync(byte[] image, int maxDimension);
   }
}
