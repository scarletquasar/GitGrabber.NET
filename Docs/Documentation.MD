# Documentation

## Abstractions
In GitGrabber, entities are abstracted to interfaces, which means that to use a given entity obtained from a method, 
you will have to perform an explicit conversion - since the same interface may, in the future, aggregate different entities.

**Example:**

```csharp
var myUser = (GithubUser)_connection.GetUser("octocat");
Console.WriteLine(myUser.Login);

//Output: "octocat"
```

## Setting up a GithubConnection
To connect to the Github API properly, it is necessary to instantiate a new GithubConnection using username and
[token](https://docs.github.com/en/authentication/keeping-your-account-and-data-secure/creating-a-personal-access-token).

You also need to instantiate a new GithubConnector.

Example:

```csharp
var _connector = new GithubConnector();
var _connection = new GithubConnection([username], [token], _connector);
```

## Retrieving informations
**GithubConnection** aggregates several methods to get data:

<details>

```csharp
(GithubUser) connection.GetUser(string username)
(GithubUser) await connection.GetUserAsync(string username)
```

```csharp
(List<GithubUser>) connection.GetUserFollowers(string username)
(List<GithubUser>) await connection.GetUserFollowersAsync(string username)
```

```csharp
(List<GithubUser>) connection.GetUserFollowing(string username)
(List<GithubUser>) await connection.GetUserFollowingAsync(string username)
```

```csharp
(List<GithubRepository>) connection.GetUserRepositories(string username)
(List<GithubRepository>) await connection.GetUserRepositoriesAsync(string username)
```

```csharp
(List<GithubOrganization>) connection.GetUserOrganizations(string username)
(List<GithubOrganization>) await connection.GetUserOrganizationsAsync(string username)
```

```csharp
(GithubOrganization) connection.GetOrganization(string organization)
(GithubOrganization) await connection.GetOrganizationAsync(string organization)
```

```csharp
(List<GithubRepository>) connection.GetOrganizationRepositories(string organization)
(List<GithubRepository>) await connection.GetOrganizationRepositoriesAsync(string organization)
```

```csharp
(GithubGist) connection.GetGist(long id)
(GithubGist) await connection.GetGistAsync(long id)
```

```csharp
(GithubRepository) connection.GetRepository(string ownerUsername, string repositoryName)
(GithubRepository) await connection.GetRepositoryAsync(string ownerUsername, string repositoryName)
```

```csharp
(List<GithubCommit>) connection.GetRepositoryCommits(string ownerUsername, string repositoryName)
(List<GithubCommit>) await connection.GetRepositoryCommitsAsync(string ownerUsername, string repositoryName)
```

```csharp
(GithubEmojis) connection.GetEmojis()
(GithubEmojis) await connection.GetEmojisAsync()
```
</details>

## Testing

You can change or execute the automated tests by yourself in GitGrabber.Tests, but you need to 
feed the "githubConfig.json" file with valid login informations in order to connect to the Github API.
