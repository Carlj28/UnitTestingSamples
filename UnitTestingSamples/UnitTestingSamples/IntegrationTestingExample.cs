using System.Net.Http;
using System.Threading.Tasks;
using Demo.WebApplication;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Xunit;

namespace UnitTestingSamples
{
    public class IntegrationTestingExample
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public IntegrationTestingExample()
        {
            // Arrange
            _server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());

            _client = _server.CreateClient();
        }

        [Fact]
        [Trait("Category", "IntegrationTests")]
        public async Task ReturnHelloWorld()
        {
            // Act
            var response = await _client.GetAsync("/api/values");
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.Equal("Hello World!", responseString);
        }
    }
}
