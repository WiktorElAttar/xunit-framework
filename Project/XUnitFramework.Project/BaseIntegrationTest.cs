using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace XUnitFramework.Project;

public abstract class BaseIntegrationTest<TProgram>(
    IntegrationTestFactory<TProgram> factory) : IAsyncLifetime
    where TProgram : class
{
    protected readonly IntegrationTestFactory<TProgram> Factory = factory;
    protected readonly HttpClient Client = factory.CreateClient();
    protected readonly IServiceScope Scope = factory.Services.CreateScope();

    public virtual ValueTask InitializeAsync()
    {
        return ValueTask.CompletedTask;
    }

    public virtual ValueTask DisposeAsync()
    {
        // Clean up the scope at the end of the test
        Scope.Dispose();
        GC.SuppressFinalize(this);
        return ValueTask.CompletedTask;
    }
}
