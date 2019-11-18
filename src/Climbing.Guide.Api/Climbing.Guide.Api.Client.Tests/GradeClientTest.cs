using Climbing.Guide.Api.Client.Services;
using Climbing.Guide.Api.Services;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Climbing.Guide.Api.Client.Tests {
   public class GradeClientTest {
      private Client _client;
      private IGradeService _gradeService;

      [SetUp]
      public void Setup() {
         _client = new Client("https://localhost:5001");
         _gradeService = _client.GetService<IGradeService>();
      }

      [Test]
      public async Task GetGradeSystemsAsync_ReturnsAllGradeSystems() {
         // ARRANGE


         // ACT
         var systems = await _gradeService.GetGradeSystemsAsync();

         // ASSERT
         CollectionAssert.IsNotEmpty(systems);
      }

      [Test]
      public async Task GetGradeSystems() {
         // ARRANGE


         // ACT
         var fontGrades = await _gradeService.GetGradesAsync(GradeSystemType.Font);

         // ASSERT
         CollectionAssert.IsNotEmpty(fontGrades);
      }
   }
}