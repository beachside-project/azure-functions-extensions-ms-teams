using Microsoft.Azure.Functions.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(WebJobsExtensions.CustomBindings.MicrosoftTeams.TeamsBindingFunctionsStartup))]

namespace WebJobsExtensions.CustomBindings.MicrosoftTeams
{
    public class TeamsBindingFunctionsStartup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.AddTeamsBinding();
        }
    }
}