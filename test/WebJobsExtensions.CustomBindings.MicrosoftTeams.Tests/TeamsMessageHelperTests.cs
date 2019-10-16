using System;
using Xunit;

namespace WebJobsExtensions.CustomBindings.MicrosoftTeams.Tests
{
    public class TeamsMessageHelperTests
    {
        private const string WebhookUrlParamName = "webhookUrl";

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("abc")]
        public void ValidationShouldThrowException(string value)
        {
            var sut = Assert.Throws<ArgumentException>(() => TeamsMessageHelper.GuardUrlString(value, WebhookUrlParamName));
            Assert.Equal(WebhookUrlParamName, sut.ParamName);
        }

        [Theory]
        [InlineData("http://abc")]
        [InlineData("https://abc")]
        public void ValidationShouldSuccess(string value)
        {
            var sut = Record.Exception(() => TeamsMessageHelper.GuardUrlString(value, WebhookUrlParamName));
            Assert.Null(sut);
        }
    }
}