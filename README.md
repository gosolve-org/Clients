# goSolve - Clients
This repository includes the client packages used for communicating from goSolve back-end services to other (goSolve or external) services. Clients can include HttpClients, SftpClients, BlobClients, etc.

## Adding a HttpClient to your project
To register a HttpClient in your Program.cs for dependency injection, use the following extension method (Book api as example):
```csharp
builder.Services.AddInternalHttpClient<IBookHttpClient, BookHttpClient>(builder.Configuration, "book");
```
And add the following to your appsettings.json and appsettings.Development.json:
```json
{
    "HttpClients": [
        {
            "Name": "book",
            "BaseAddressUri": "<base address of the api>", // Example: "https://localhost:5001/" (trailing slash is required!)
            "Accept": "application/json" // (Optional, default value: "application/json")
        }
    ]
}
```

## License
[![License: AGPL v3](https://img.shields.io/badge/License-AGPL_v3-blue.svg)](https://www.gnu.org/licenses/agpl-3.0)  
goSolve is open-source. We use the [GNU AGPLv3 licensing strategy](LICENSE).
