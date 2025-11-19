using Microsoft.Extensions.DependencyInjection;
using Testcontainers.PostgreSql;
using XUnitFramework.Project;

namespace SampleApp.Tests;

public class SampleAppFactory : IntegrationTestFactory<Program>
{
    // Define your containers here
    private readonly PostgreSqlContainer _dbContainer = new PostgreSqlBuilder()
        .WithImage("postgres:15-alpine")
        .Build();

    public override async ValueTask InitializeAsync()
    {
        // Start containers before tests run
        await _dbContainer.StartAsync();
    }

    public override async ValueTask DisposeAsync()
    {
        await _dbContainer.DisposeAsync();
        await base.DisposeAsync();
        GC.SuppressFinalize(this);
    }

    protected override void ConfigureServices(IServiceCollection services)
    {
        // Configure your app to use the container's connection string
        // Example:
        // var connectionString = _dbContainer.GetConnectionString();
        // services.Configure<DbSettings>(options => options.ConnectionString = connectionString);
    }
}
