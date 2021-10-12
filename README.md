<h1 align="center">
  <img src="https://i.imgur.com/JnSjFjJ.png" width="75px">
  <br>
  GitGrabber
</h1>
<p align="center">Get data directly from the official GitHub API in a fast and practical way and use it directly in your .NET projects.</p>

## Usage
To get started with GitGrabber you have to install the package manually adding the `git-grabber.dll` in the project and
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

**Todo:**
- Develop Command Line Interface utility
- Add Exception Handlers to Fetchers
