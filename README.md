<h1 align="center">
  <img src="https://i.imgur.com/JnSjFjJ.png" width="75px">
  <br>
  GitGrabber
</h1>
<p align="center">Get data directly from the official GitHub API in a fast and practical way and use it directly in your .NET projects.</p>

## Development
| Version | Branch |
| --- | ----------- |
| Development | Main |
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
| Gihub User | Working ✔ Have Limitations ⚠ |
| Github User Followers | Working ✔ |
| Github User Repositories | Working ✔ |
| Github User Search | Working ✔ |
| Github User Detailed Search | Working ✔ |
| Github User Organizations | Working ✔ |
| 🔵 **Organizations** |
| Github Organization | Working ✔ |
| Github Organization Repositories | Working ✔ |
| 🔵 **Repositories** |
| Github Repository | Working ✔ Have Limitations ⚠ |
| 🔵 **Misc** |
| Github Emojis | Working ✔ |

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
## TODO
- Fix Problematic Model Fields in User/Repo
- Add Public Gists Fetch Support
- Add Authenticated User Operations Support
- Develop Command Line Interface utility
- Add Exception Handlers to Fetchers
