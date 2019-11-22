using Climbing.Guide.Api.Client.Services;
using Climbing.Guide.Api.Services;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Climbing.Guide.Api.Client.Tests {
   public class CountriesClientTest {
      private Client _client;
      private ICountriesService _countriesService;

      [SetUp]
      public void Setup() {
         // TODO: FIX
         _client = new Client("https://localhost:5001", "https://localhost:5101");
         _countriesService = _client.GetService<ICountriesService>();
      }

      [Test]
      public async Task GetGradeSystemsAsync_ReturnsAllGradeSystems() {
         // ARRANGE


         // ACT
         var countries = await _countriesService.GetCountriesAsync(0, 1000);

         // ASSERT
         Assert.IsNotNull(countries);
         CollectionAssert.IsNotEmpty(countries.Countries);
      }
   }
}