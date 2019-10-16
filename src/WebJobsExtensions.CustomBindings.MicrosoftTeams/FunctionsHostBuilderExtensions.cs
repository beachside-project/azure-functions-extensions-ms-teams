using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Azure.WebJobs.Host.Config;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using WebJobsExtensions.CustomBindings.MicrosoftTeams.Config;

namespace WebJobsExtensions.CustomBindings.MicrosoftTeams
{
    public static class FunctionsHostBuilderExtensions
    {
        public static IFunctionsHostBuilder AddTeamsBinding(this IFunctionsHostBuilder builder)
        {
            if (builder == null) throw new ArgumentException(nameof(builder));

            builder.Services.AddHttpClient();
            builder.Services.AddSingleton<ITeamsClientFactory, DefaultTeamsClientFactory>();
            builder.Services.TryAddEnumerable(ServiceDescriptor.Singleton<IExtensionConfigProvider, TeamsExtensionConfigProvider>());

            return builder;
        }
    }
}