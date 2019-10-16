using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host.Config;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Net.Http;
using WebJobsExtensions.CustomBindings.MicrosoftTeams.Config;
using Xunit;

namespace WebJobsExtensions.CustomBindings.MicrosoftTeams.Tests
{
    public class TeamsBindingFunctionsStartupTest
    {
        private static readonly ServiceProvider Sut;
        static TeamsBindingFunctionsStartupTest()
        {
            var webJobsBuilder = new TestWebJobsBuilder();
            var customStartup = new TeamsBindingFunctionsStartup();
            customStartup.Configure(webJobsBuilder);
            Sut = webJobsBuilder.Services.BuildServiceProvider();
        }

        [Fact]
        public void V2HostServiceProviderShouldHaveIHttpClientFactory()
        {
            var httpClientFactory = Sut.GetService<IHttpClientFactory>();
            Assert.NotNull(httpClientFactory);
        }

        [Fact]
        public void V2HostServiceProviderShouldHaveITeamsClientFactory()
        {
            var teamsClientFactory = Sut.GetService<ITeamsClientFactory>();
            Assert.NotNull(teamsClientFactory);
        }

        [Fact]
        public void V2HostServiceProviderShouldHaveIExtensionConfigProviderAsTeamsExtensionConfigProvider()
        {
            var teamsExtensionConfigProvider = Sut.GetServices<IExtensionConfigProvider>().Single();
            Assert.NotNull(teamsExtensionConfigProvider);
            Assert.IsType<TeamsExtensionConfigProvider>(teamsExtensionConfigProvider);
        }

        private class TestWebJobsBuilder : IWebJobsBuilder
        {
            public TestWebJobsBuilder()
            {
                Services = new ServiceCollection();
            }

            public IServiceCollection Services { get; }
        }
    }
}