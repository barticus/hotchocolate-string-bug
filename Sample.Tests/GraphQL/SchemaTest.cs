using System.Threading.Tasks;
using ApprovalTests;
using Microsoft.AspNetCore.TestHost;
using NUnit.Framework;

namespace Sample.Tests.GraphQL
{
    public class SchemaTest
    {
        public const string GraphqlPath = "graphql";

        protected TestServer Server { get; set; } = default!;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Server = MockServer.Create();
        }

        [Test]
        public async Task GetSchema()
        {
            // Arrange
            var req = Server.CreateRequest(GraphqlPath + "/schema");

            // Act
            var result = await req.GetAsync();

            // Assert
            Assert.AreEqual(200, (int)result.StatusCode);
            Approvals.Verify(await result.Content.ReadAsStringAsync());
        }
    }
}
