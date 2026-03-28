### SunamoOctokit

A .NET wrapper around the [Octokit](https://github.com/octokit/octokit.net) library providing simplified GitHub API access with authentication helpers and repository management.

## Features

- Basic credentials and token-based authentication
- Repository listing and creation
- Result wrapper with exception handling

## Usage

```csharp
var helper = new OctokitHelper();
helper.Initialize("MyApp").TokenAuthenticate("your-token");

// List repositories
var repositories = await helper.GetAccountRepositories("username", isIncludingPrivate: false);

// Create a repository
var result = helper.CreateRepository("NewRepoName");
if (result.ExceptionText != null)
{
    Console.WriteLine($"Error: {result.ExceptionText}");
}
```

## Links

- [NuGet](https://www.nuget.org/profiles/sunamo)
- [GitHub](https://github.com/sunamo/PlatformIndependentNuGetPackages)
- [Developer site](https://sunamo.cz)

## Target Frameworks

**TargetFrameworks:** `net10.0;net9.0;net8.0`

Request for new features / bug report / etc: [Mail](mailto:radek.jancik@sunamo.cz) or on GitHub
