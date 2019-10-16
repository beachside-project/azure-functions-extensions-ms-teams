using System.Net.Http;
using System.Threading.Tasks;
using WebJobsExtensions.CustomBindings.MicrosoftTeams.Messages;

namespace WebJobsExtensions.CustomBindings.MicrosoftTeams.Client
{
    public class TeamsClient : ITeamsClient
    {
        private readonly HttpClient _httpClient;

        public TeamsAttribute ResolvedAttribute { get; set; }

        public TeamsClient(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        public async Task SendTeamsMessageAsync(ITeamsMessage teamsMessage)
        {
            var content = new StringContent(teamsMessage.ToJson());
            var response = await _httpClient.PostAsync(ResolvedAttribute.WebhookUrl, content);
            response.EnsureSuccessStatusCode();
        }
    }
}