using Xunit;

namespace GtMotive.Estimate.Microservice.InfrastructureTests.Infrastructure
{
#pragma warning disable CA1515
    [Collection(TestCollections.TestServer)]
    public abstract class InfrastructureTestBase(GenericInfrastructureTestServerFixture fixture)
    {
        public GenericInfrastructureTestServerFixture Fixture { get; } = fixture;
    }
#pragma warning restore CA1515
}
