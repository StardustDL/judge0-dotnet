# judge0-dotnet

![CI](https://github.com/StardustDL/judge0-dotnet/workflows/CI/badge.svg) ![CD](https://github.com/StardustDL/judge0-dotnet/workflows/CD/badge.svg) ![License](https://img.shields.io/github/license/StardustDL/judge0-dotnet.svg) ![downloads](https://img.shields.io/nuget/dt/Judge0)

Client SDK for Judge0 RESTful API.

- Tested Judge0 version: 1.18, 1.19

## Install

```sh
dotnet add package Judge0
```

## Usage

```csharp
var client = new HttpClient
{
    BaseAddress = new Uri("apiUri")
};
IJudge0Service service = new Judge0Service(client);

var result = await service.LanguagesService.Get();
foreach(Language lang in result.Result)
{
    Console.WriteLine(lang.name);
}
```
