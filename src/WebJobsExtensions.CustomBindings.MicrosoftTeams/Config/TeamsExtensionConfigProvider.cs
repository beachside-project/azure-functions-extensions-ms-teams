using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host.Config;
using System;
using System.Collections.Generic;
using System.Net.Http;
using WebJobsExtensions.CustomBindings.MicrosoftTeams.Client;

namespace WebJobsExtensions.CustomBindings.MicrosoftTeams.Config
{
    public class TeamsExtensionConfigProvider : IExtensionConfigProvider

    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ITeamsClientFactory _teamsClientFactory;

        public TeamsExtensionConfigProvider(IHttpClientFactory httpClientFactory,ITeamsClientFactory teamsClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _teamsClientFactory = teamsClientFactory;
        }

        public void Initialize(ExtensionConfigContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));

            var rule = context.AddBindingRule<TeamsAttribute>();
            rule.AddValidator(ValidateTeamsAttribute);
            rule.BindToCollector<TeamsBindingOpenType>(typeof(TeamsAsyncCollectorConvertor), this);
        }

        internal ITeamsClient CreateTeamsClient(TeamsAttribute attribute) => _teamsClientFactory.Create(_httpClientFactory, attribute);

        internal void ValidateTeamsAttribute(TeamsAttribute attribute, Type pramType)
        {
            TeamsMessageHelper.GuardUrlString(attribute.WebhookUrl, nameof(attribute.WebhookUrl));
        }

        private class TeamsBindingOpenType : OpenType.Poco
        {
            public override bool IsMatch(Type type, OpenTypeMatchContext context)
            {
                if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(IEnumerable<>)) return false;
                if (type.FullName == "System.Object") return true;

                return base.IsMatch(type, context);
            }
        }
    }
}