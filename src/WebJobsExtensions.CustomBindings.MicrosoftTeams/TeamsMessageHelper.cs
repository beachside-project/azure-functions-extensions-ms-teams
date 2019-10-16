using System;

namespace WebJobsExtensions.CustomBindings.MicrosoftTeams
{
    public static class TeamsMessageHelper
    {
        public static void GuardUrlString(string value, string parameterName)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException($"The parameter {parameterName} cannot be null or empty", parameterName);
            //TODO: implement url validation
            if (!value.StartsWith("htt"))
                throw new ArgumentException($"The parameter {parameterName} is invalid url format(value: {value}).", parameterName);
        }

        public static void GuardString(string value, string parameterName)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException($"The parameter {parameterName} cannot be null or empty", parameterName);
        }
    }
}