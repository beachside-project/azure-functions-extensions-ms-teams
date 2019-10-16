using Microsoft.Azure.WebJobs;
using WebJobsExtensions.CustomBindings.MicrosoftTeams.Bindings;
using WebJobsExtensions.CustomBindings.MicrosoftTeams.Messages;

namespace WebJobsExtensions.CustomBindings.MicrosoftTeams.Config
{
    public class TeamsAsyncCollectorConvertor : IConverter<TeamsAttribute, IAsyncCollector<ITeamsMessage>>
    {
        private readonly TeamsExtensionConfigProvider _configProvider;

        public TeamsAsyncCollectorConvertor(TeamsExtensionConfigProvider configProvider)
        {
            _configProvider = configProvider;
        }

        public IAsyncCollector<ITeamsMessage> Convert(TeamsAttribute attribute)
        {
            var context = _configProvider.CreateTeamsClient(attribute);
            return new TeamsAsyncCollector(context);
        }
    }
}