using System.Threading.Tasks;
using Xunit;

namespace GtMotive.Estimate.Microservice.FunctionalTests.Infrastructure
{
#pragma warning disable CA1515

    [Collection(TestCollections.Functional)]
    public abstract class FunctionalTestBase(CompositionRootTestFixture fixture) : IAsyncLifetime
    {
        public const int QueueWaitingTimeInMilliseconds = 1000;

        public CompositionRootTestFixture Fixture { get; } = fixture;

        public async Task InitializeAsync()
        {
            await Task.CompletedTask;
        }

        public async Task DisposeAsync()
        {
            await Task.CompletedTask;
        }
    }
#pragma warning restore CA1515

}
