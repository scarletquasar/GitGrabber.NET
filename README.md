<h1 align="center">
  <img src="https://i.imgur.com/JnSjFjJ.png" width="75px">
  <br>
  GitGrabber
</h1>

<center>
<p align="center">
Get data directly from the official GitHub API in a fast and practical way and use it directly in your .NET projects.

[![CodeFactor](https://www.codefactor.io/repository/github/eternalquasar0206/git-grabber/badge/main)](https://www.codefactor.io/repository/github/eternalquasar0206/git-grabber/overview/main) <img src="https://shields.io/github/v/tag/EternalQuasar0206/git-grabber" />

</p>
</center>

## Support
| Version | Target |
| --- | ----------- |
| Development | .NET Standard 2.0+ |
| 1.x.x | .NET Standard 2.0+ |

## Development

Warning: You may use the last stable release <img src="https://shields.io/github/v/tag/EternalQuasar0206/git-grabber" /> to prevent several issues and problems, the main branch is focused in development and tests.

| Version | Branch |
| --- | ----------- |
| Development | Main |
| 1.1.0 | ver1.1.0 |
| 1.0.0 | ver1.0.0 |

## Usage
To get started with GitGrabber you have to install the package manually adding the `git-grabber.dll` (of /out/ folder in the repository) in the project and
a reference in the *.csproj:
```html
<ItemGroup>
  <Reference Include="git-grabber">
    <HintPath>git-grabber.dll</HintPath>
    <SpecificVersion>False</SpecificVersion> 
  </Reference>
</ItemGroup>
```

## Features
| Feature | State |
| --- | ----------- |
| 🔵 **User** |
| Gihub User | Working ✔ |
| Github User Followers | Working ✔ |
| Github User Repositories | Working ✔ |
| Github User Search | Working ✔ |
| Github User Detailed Search | Working ✔ |
| Github User Organizations | Working ✔ |
| Github User Gists | Working ✔ |
| 🔵 **Organizations** |
| Github Organization | Working ✔ |
| Github Organization Repositories | Working ✔ |
| 🔵 **Repositories** |
| Github Repository | Working ✔ |
| 🔵 **Misc** |
| Github Emojis | Working ✔ |
| 🔵 **Gists** |
| Gihub Gist + Public Gists List | Working ✔ |
| Gihub Gist by id | Working ✔ |

## Functions
The purpose of the library is to provide ways to quickly deserialize information from the Github API, in this way you just use a function and the data is automatically converted into usable object instances.

### Importing GitGrabber
You can import GitGrabber to your code file using the namespace imports:

```cs
using GitGrabber;
using GitGrabber.Models;
```

### Using GitGrabber
To connect to the Github API you must instantiate a new `GitGrabConnection` and use the `Connect()` functionality.

```cs
GitGrabConnection GitConnection = new();
GitConnection.Connect();
```

### GitGrabber Methods
Currently the methods available in GitGrabber are:

```cs
//Returns the Github API default lobby object
GithubApiResponse ApiResponse = GitConnection.GithubApi(); 
```
```cs
//Returns a Github User as object
GithubUser MyUser = GitConnection.GetUser("username"); 
```

```cs
//Returns the Github User list of Gists
List<GithubGist> UserPublicGists = GitConnection.GetGists(); 
```

```cs
//Returns a Github Repository as object
GithubRepo MyRepo = GitConnection.GetRepo("Owner username", "Repo name"); 
```

```cs
//Returns a Github Organization as object
GithubOrg MyOrg = GitConnection.GetOrg("Org name");
```

```cs
//Performs a quick search and brings up the results in a GithubUser list
List<GithubUser> UserSearch = GitConnection.SearchUser("search");
```

```cs
//Performs a detailed search and brings up the results in a GithubUser list
List<GithubUser> UserSearch = GitConnection.SearchUser("search", (int)"max results/page", (int)"page");
```

```cs
//Return emoji links directly from Github api
Dictionary<string, string> Emojis = GitConnection.Emojis();
```

```cs
//Get the list of public gists (managed by API)
List<GithubGist> PublicGists = GitConnection.GetPublicGists();
```

```cs
//Get a Github Gist by id
GithubGist GistById = GitConnection.GetGist("id");
```
## Changelog
- Added User Gists Fetcher
- Added Gist By Id Fetcher
- Added Public Gists Fetcher (General)
- Enabled field "owner" from GithubRepo model as `Dictionary<string, dynamic>`
- Enabled "hireable" and "email" from GithubUser model as nullable beings

## TODO
- Add Authenticated User Operations Support
- Develop Command Line Interface utility
- Add Exception Handlers to Fetchers
