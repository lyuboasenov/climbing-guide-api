using Climbing.Guide.Api.Application.Interfaces;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading.Tasks;

namespace Climbing.Guide.Api.Infrastructure {
   public class ImageUtil : IImageUtil {
      public Task<Stream> GetThumbAsync(Stream imageStream, int maxDimension) {
         using (Image image = Image.FromStream(imageStream)) {
            float ratio = image.Width / image.Height;
            var newSize = new SizeF(
               ratio > 1 ? maxDimension : maxDimension * ratio
               , ratio < 1 ? maxDimension : maxDimension * ratio);
            image.GetThumbnailImage((int) newSize.Width, (int) newSize.Height, () => false, IntPtr.Zero);

            var result = new MemoryStream();
            image.Save(result, ImageFormat.Jpeg);
            result.Seek(0, SeekOrigin.Begin);

            return Task.FromResult((Stream)result);
         }


      }

      public async Task<byte[]> GetThumbAsync(byte[] image, int maxDimension) {
         using (var stream = new MemoryStream(image)) {
            using (var resultStream = await GetThumbAsync(stream, maxDimension)) {
               return stream.ToArray();
            }
         }
      }
   }
}
