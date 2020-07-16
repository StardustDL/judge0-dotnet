# judge0-dotnet

![CI](https://github.com/StardustDL/judge0-dotnet/workflows/CI/badge.svg) ![CD](https://github.com/StardustDL/judge0-dotnet/workflows/CD/badge.svg) ![License](https://img.shields.io/github/license/StardustDL/judge0-dotnet.svg) [![Judge0](https://buildstats.info/nuget/Judge0)](https://www.nuget.org/packages/Judge0/)

Client SDK for [Judge0](https://github.com/judge0/api) RESTful API.

## Features

- Authentication
- Authorization
- Submissions
- Statuses and Languages
- System and Configuration
- Statistics
- Health Check
- Information

## Versions

Judge0 version supported status:

- [x] 1.9.0
- [x] 1.8.0
- [x] 1.7.1
- [x] 1.7.0
- [x] 1.6.0

## Install

```sh
dotnet add package Judge0
```

## Usage

### Create Service

```csharp
var client = new HttpClient
{
    BaseAddress = new Uri("apiUri")
};
IJudge0Service service = new Judge0Service(client);
```

### Authentication & Authorization

```csharp
public async Task AuthenticateAndAuthorize()
{
    var result = await service.AuthenticationService.Authenticate("token");
    Assert.IsTrue(result.IsSuccessStatusCode);

    result = await service.AuthenticationService.Authorize("user");
    Assert.IsTrue(result.IsSuccessStatusCode);
}
```


### Submission

```csharp
public async Task CreateGetAndDelete()
{
    var result = await service.SubmissionsService.Create(new Submission
    {
        source_code = "#include <stdio.h>\n\nint main(void) {\n  char name[10];\n  scanf(\"%s\", name);\n  printf(\"hello, %s\\n\", name);\n  return 0;\n}",
        stdin = "world",
        language_id = 50,
    });
    Assert.IsTrue(result.IsSuccessStatusCode);
    string token = result.Result.token;

    while (true)
    {
        await Task.Delay(TimeSpan.FromSeconds(1));
        var res = await service.SubmissionsService.Get(token);
        Assert.IsTrue(res.IsSuccessStatusCode);
        if(res.Result.status?.id > 2)
        {
            Assert.IsNotNull(res.Result.stdout);
            StringAssert.StartsWith(res.Result.stdout, "hello, world");
            break;
        }
    }

    var del = await service.SubmissionsService.Delete(token);
    Assert.IsTrue(del.IsSuccessStatusCode);
}

public async Task CreateWaitGetAndDelete()
{
    var result = await service.SubmissionsService.CreateAndWait(new Submission
    {
        source_code = "#include <stdio.h>\n\nint main(void) {\n  char name[10];\n  scanf(\"%s\", name);\n  printf(\"hello, %s\\n\", name);\n  return 0;\n}",
        stdin = "world",
        language_id = 50,
    });
    Assert.IsTrue(result.IsSuccessStatusCode);
    string token = result.Result.token;

    Assert.IsNotNull(result.Result.stdout);
    StringAssert.StartsWith(result.Result.stdout, "hello, world");

    var del = await service.SubmissionsService.Delete(token);
    Assert.IsTrue(del.IsSuccessStatusCode);
}

public async Task GetPaging()
{
    var result = await service.SubmissionsService.GetPaging();
    Assert.IsTrue(result.IsSuccessStatusCode);
}

public async Task Batch()
{
    var result = await service.SubmissionsService.BatchCreate(new SubmissionBatch
    {
        submissions = new[]{
            new Submission
    {
        source_code = "#include <stdio.h>\n\nint main(void) {\n  char name[10];\n  scanf(\"%s\", name);\n  printf(\"hello, %s\\n\", name);\n  return 0;\n}",
        stdin = "world",
        language_id = 50,
    },
            new Submission
    {
        source_code = "#include <stdio.h>\n\nint main(void) {\n  char name[10];\n  scanf(\"%s\", name);\n  printf(\"hello, %s\\n\", name);\n  return 0;\n}",
        stdin = "world",
        language_id = 50,
    }
            }
    });
    Assert.IsTrue(result.IsSuccessStatusCode);
    var getres = await service.SubmissionsService.BatchGet(result.Result.Select(x => x.token));
    Assert.IsTrue(getres.IsSuccessStatusCode);
}
```

### Language

```csharp
public async Task Get()
{
    var result = await service.LanguagesService.Get();
    Assert.IsTrue(result.IsSuccessStatusCode);
}

public async Task GetById()
{
    var result = await service.LanguagesService.Get(50);
    Assert.IsTrue(result.IsSuccessStatusCode);
}

public async Task GetAll()
{
    var result = await service.LanguagesService.GetAll();
    Assert.IsTrue(result.IsSuccessStatusCode);
}
```

### Status

```csharp
public async Task Get()
{
    var result = await service.StatusesService.Get();
    Assert.IsTrue(result.IsSuccessStatusCode);
}
```

### System & Configuration & Statistics & Health Check & Information

```csharp
public async Task GetSystemInfo()
{
    var result = await service.SystemService.GetSystemInfo();
    Assert.IsTrue(result.IsSuccessStatusCode);
}

public async Task GetAbout()
{
    var result = await service.SystemService.GetAbout();
    Assert.IsTrue(result.IsSuccessStatusCode);
}

public async Task GetConfigInfo()
{
    var result = await service.SystemService.GetConfigInfo();
    Assert.IsTrue(result.IsSuccessStatusCode);
}

public async Task GetIsolate()
{
    var result = await service.SystemService.GetIsolate();
    Assert.IsTrue(result.IsSuccessStatusCode);
}

public async Task GetLicense()
{
    var result = await service.SystemService.GetLicense();
    Assert.IsTrue(result.IsSuccessStatusCode);
}

public async Task GetStatistics()
{
    var result = await service.SystemService.GetStatistics();
    Assert.IsTrue(result.IsSuccessStatusCode);
}

public async Task GetWorkerHealthCheck()
{
    var result = await service.SystemService.GetWorkerHealthCheck();
    Assert.IsTrue(result.IsSuccessStatusCode);
}

public async Task GetVersion()
{
    var result = await service.SystemService.GetVersion();
    Assert.IsTrue(result.IsSuccessStatusCode);
}
```

## Status

![](https://buildstats.info/github/chart/StardustDL/judge0-dotnet?branch=master)