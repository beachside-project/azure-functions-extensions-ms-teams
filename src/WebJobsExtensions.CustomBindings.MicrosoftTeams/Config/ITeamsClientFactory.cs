using System.Net.Http;
using WebJobsExtensions.CustomBindings.MicrosoftTeams.Client;

namespace WebJobsExtensions.CustomBindings.MicrosoftTeams.Config
{
    public interface ITeamsClientFactory
    {
        ITeamsClient Create(IHttpClientFactory httpClientFactory, TeamsAttribute attribute);
    }
}