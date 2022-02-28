# Documentation
This is the official GitGrabber.NET documentation, in it you will find method definitions and usage steps.

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

