using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace WebJobsExtensions.CustomBindings.MicrosoftTeams.Messages
{
#pragma warning disable IDE0051
    public class TitleDescriptionViewMoreButtonMessage : ITeamsMessage
    {
        private readonly JsonSerializerSettings _settings = new JsonSerializerSettings()
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };

        public string Title { get; set; }

        public string Text { get; set; }

        public string LinkUri
        {
            get => PotentialAction[0].Targets[0].Uri;
            set
            {
                TeamsMessageHelper.GuardUrlString(value, nameof(LinkUri));
                PotentialAction[0].Targets[0].Uri = value;
            }
        }

        public string ThemeColor { get; set; } = "0072C6";

        [JsonProperty("@context")]
        private string Context => "https://schema.org/extensions";

        [JsonProperty("@type")]
        private string CardType => "MessageCard";

        [JsonProperty]
        private PotentialAction[] PotentialAction { get; } = { new PotentialAction() };

        public string ToJson() => JsonConvert.SerializeObject(this, settings: _settings);
    }

    internal class PotentialAction
    {
        [JsonProperty("@type")]
        private string Type => "OpenUri";

        [JsonProperty]
        private string Name => "View More";

        public Target[] Targets { get; } = { new Target() };
    }

    internal class Target
    {
        [JsonProperty]
        private string Os => "default";

        public string Uri { get; internal set; }
    }
}