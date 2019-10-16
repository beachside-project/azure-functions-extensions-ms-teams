using Microsoft.Azure.WebJobs.Description;
using System;
using WebJobsExtensions.CustomBindings.MicrosoftTeams.Messages;

namespace WebJobsExtensions.CustomBindings.MicrosoftTeams
{
    [AttributeUsage(AttributeTargets.Parameter)]
    [Binding]
    public class TeamsAttribute : Attribute
    {
        public TeamsAttribute(string webhookUrl)
        {
            WebhookUrl = webhookUrl;
        }

        [AutoResolve]
        public string WebhookUrl { get; set; }
    }
}