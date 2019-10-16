using Newtonsoft.Json;

namespace WebJobsExtensions.CustomBindings.MicrosoftTeams.Messages
{
    public class SimpleMessage : ITeamsMessage
    {

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        public string ToJson() => JsonConvert.SerializeObject(this);
    }
}