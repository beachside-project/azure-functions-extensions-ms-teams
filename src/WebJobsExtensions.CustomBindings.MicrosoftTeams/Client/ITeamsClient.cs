using System.Threading.Tasks;
using WebJobsExtensions.CustomBindings.MicrosoftTeams.Messages;

namespace WebJobsExtensions.CustomBindings.MicrosoftTeams.Client
{
    public interface ITeamsClient
    {
        Task SendTeamsMessageAsync(ITeamsMessage teamsMessage);
    }
}