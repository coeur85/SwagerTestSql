using FluentAssertions;
using PdaHub.Test.Acceptance.Brokers;
using System.Threading.Tasks;
using Xunit;

namespace PdaHub.Test.Acceptance.Controllers
{
    public class StockController
    {

        private readonly ApiBroker _api;
        private readonly string relevantUrl;

        public StockController()
        {
            _api = new ApiBroker();
            relevantUrl = "stock";
        }

        [Fact]
        public async Task ShouldReturnStringAsync()
        {
            //given
            string excpectedString = "Stock Controller Get method";

            // when
            string outputString = await _api.GetAsync(relevantUrl);

            // then
            outputString.Should().BeEquivalentTo(excpectedString);
        }
    }
}
