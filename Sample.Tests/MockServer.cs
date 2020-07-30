using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;

namespace Sample.Tests
{
    public class MockServer
    {
        public static TestServer Create()
        {
            var builder = new WebHostBuilder()
                .UseStartup<Sample.Startup>();
            return new TestServer(builder);
        }
    }
}
