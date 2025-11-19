using Xunit;
using XUnitFramework.Project;

namespace SampleApp.Tests;

[Collection("SampleApp Collection")]
public abstract class SampleAppTestBase(IntegrationTestFactory<Program> factory)
    : BaseIntegrationTest<Program>(factory);
