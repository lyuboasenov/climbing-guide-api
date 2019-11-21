using System.Threading.Tasks;

namespace Climbing.Guide.Api.Application.Interfaces {
   public interface IFsContext {
      Task WriteFileAsync(string path, byte[] content);
   }
}
