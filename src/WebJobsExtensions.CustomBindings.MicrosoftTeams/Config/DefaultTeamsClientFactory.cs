using System.Net.Http;
using WebJobsExtensions.CustomBindings.MicrosoftTeams.Client;

namespace WebJobsExtensions.CustomBindings.MicrosoftTeams.Config
{
    internal class DefaultTeamsClientFactory : ITeamsClientFactory
    {
        public ITeamsClient Create(IHttpClientFactory httpClientFactory, TeamsAttribute attribute)
        {
            return new TeamsClient(httpClientFactory)
            {
                ResolvedAttribute = attribute
            };
        }
    }
}