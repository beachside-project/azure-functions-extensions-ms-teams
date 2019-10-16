using Microsoft.Azure.WebJobs;
using System.Threading;
using System.Threading.Tasks;
using WebJobsExtensions.CustomBindings.MicrosoftTeams.Client;
using WebJobsExtensions.CustomBindings.MicrosoftTeams.Messages;

namespace WebJobsExtensions.CustomBindings.MicrosoftTeams.Bindings
{
    public class TeamsAsyncCollector : IAsyncCollector<ITeamsMessage>
    {
        private readonly ITeamsClient _teamsClient;

        public TeamsAsyncCollector(ITeamsClient teamsClient)
        {
            _teamsClient = teamsClient;
        }

        public async Task AddAsync(ITeamsMessage teamsMessage, CancellationToken cancellationToken = new CancellationToken())
        {
            await _teamsClient.SendTeamsMessageAsync(teamsMessage);
        }

        public Task FlushAsync(CancellationToken cancellationToken = new CancellationToken()) => Task.CompletedTask;
    }
}