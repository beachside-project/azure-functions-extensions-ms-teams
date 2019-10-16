# azure-functions-extensions-ms-teams
Azure Functions Custom Bindings for MS Teams

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