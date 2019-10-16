using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using WebJobsExtensions.CustomBindings.MicrosoftTeams;
using WebJobsExtensions.CustomBindings.MicrosoftTeams.Messages;

namespace TeamsBindingFunctionAppSample
{
    public static class HttpTriggerFunctionSample
    {
        [FunctionName("link-button-card")]
        public static async Task Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] TitleDescriptionViewMoreButtonMessage teamsMessage,
            [Teams("%TeamsWebhookUri%")] IAsyncCollector<ITeamsMessage> asyncCollector,
            ILogger log)
        {
            await asyncCollector.AddAsync(teamsMessage);
        }

        [FunctionName("text")]
        public static async Task SendSimpleMessage(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] SimpleMessage teamsMessage,
            [Teams("%TeamsWebhookUri%")] IAsyncCollector<ITeamsMessage> asyncCollector,
            ILogger log)
        {
            await asyncCollector.AddAsync(teamsMessage);
        }
    }
}