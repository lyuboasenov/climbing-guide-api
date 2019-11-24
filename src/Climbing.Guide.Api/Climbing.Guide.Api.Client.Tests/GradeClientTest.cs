using Climbing.Guide.Api.Client.Services;
using Climbing.Guide.Api.Services.Grades;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Climbing.Guide.Api.Client.Tests {
   public class GradeClientTest {
      private Client _client;
      private IGradesService _gradeService;

      [SetUp]
      public void Setup() {
         // TODO: FIX
         _client = new Client("https://localhost:5001", "https://localhost:5101");
         _gradeService = _client.GetService<IGradesService>();
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