namespace WebJobsExtensions.CustomBindings.MicrosoftTeams.Messages
{
    public interface ITeamsMessage
    {
        string Title { get; set; }

        string Text { get; set; }

        string ToJson();
    }
}