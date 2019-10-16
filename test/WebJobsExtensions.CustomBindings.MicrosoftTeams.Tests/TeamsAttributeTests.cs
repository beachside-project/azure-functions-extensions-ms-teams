using Xunit;

namespace WebJobsExtensions.CustomBindings.MicrosoftTeams.Tests
{
    public class TeamsAttributeTests
    {
        [Fact]
        public void WebhookShouldSetCorrectly()
        {
            const string expected = "value";
            var attribute = new TeamsAttribute(expected);

            Assert.Equal(expected, attribute.WebhookUrl);
        }
    }
}