# azure-functions-extensions-ms-teams
[![Build Status](https://dev.azure.com/beachside/nuget-feed/_apis/build/status/beachside-project.azure-functions-extensions-ms-teams?branchName=master)](https://dev.azure.com/beachside/nuget-feed/_build/latest?definitionId=16&branchName=master)
[![WebJobsExtensions.CustomBindings.MicrosoftTeams package in beachside-nuget feed in Azure Artifacts](https://feeds.dev.azure.com/beachside/_apis/public/Packaging/Feeds/4b0a92c6-28ec-45d8-b044-b37411c9af60/Packages/46ad9dc0-3479-4997-9361-7ef2007cf850/Badge)](https://dev.azure.com/beachside/nuget-feed/_packaging?_a=package&feed=4b0a92c6-28ec-45d8-b044-b37411c9af60&package=46ad9dc0-3479-4997-9361-7ef2007cf850&preferRelease=true)  
(Feed on Azure Artifacts private)

Azure Functions Custom Bindings for MS Teams.

## Prerequisites: Teams settings

- add **Incoming Webhook** and get webhook url. See [official document](https://docs.microsoft.com/ja-jp/microsoftteams/platform/concepts/connectors/connectors-using?redirectedfrom=MSDN#setting-up-a-custom-incoming-webhook).  
  more detail: [my blog post](https://blog.beachside.dev/entry/2019/10/02/212000)

## Prerequisites: Functions App settings

Functions App use environment valiable "TeamsWebhookUri", so need to set it.

### For local debug

- add `local.settings.json` file.
- add following json

```json
{
  "IsEncrypted": false,
  "Values": {
    "AzureWebJobsStorage": "UseDevelopmentStorage=true",
    "FUNCTIONS_WORKER_RUNTIME": "dotnet",
    "TeamsWebhookUri": "<teams webhook url !!!! >"
  }
}
```

### For Running on Azure

- Set "TeamsWebhookUri" key and value to Application settings.


## How to use

> WIP: add description



## How to add card

> WIP: add description
