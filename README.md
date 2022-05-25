# .NET Agent Code Level Metrics Demo

This project uses the New Relic .NET agent to demonstrate the reporting of
code level metrics (CLM).

There is a .NET Core 3.1 ASP.NET Core MVC based web application contained in the `AspNetCoreMvc`
directory. This application is designed to create web transactions with custom instrumented segments.

By running the demo, the application will be launched and
daemonized and a `tester` shell script will perform [curl](https://curl.se/)
commands that generate web traffic to exercise all traced Ruby methods.

## Important Source Files

The following class files define methods that will be invoked and produce
code level metrics.

- `Controllers/AgentsController.cs`: A basic ASP.NET Core Controller
- `Helpers.cs`: A simple class that has a pair of static methods and instance methods that build a string that will be display in the MVC Views.

## Traced methods

### AgentsController

This class has 3 Controler Actions that are exercised by the demo, `create`, `destroy`, and `show`.

These produce the following transactions and metrics:

- `WebTransaction/MVC/Agents/Create`
  - `DotNet/AgentsController/Create`
  - `DotNet/AspNetCoreMvc.Helpers/CustomMethodOne`
  - `DotNet/AspNetCoreMvc.Helpers/CustomMethodTwo`
  - `DotNet/AspNetCoreMvc.Helpers/CustomStaticMethodOne`
  - `DotNet/AspNetCoreMvc.Helpers/CustomStaticMethodTwo`
- `WebTransaction/MVC/Agents/Destroy`
  - `DotNet/AgentsController/Destroy`
  - `DotNet/AspNetCoreMvc.Helpers/CustomMethodOne`
  - `DotNet/AspNetCoreMvc.Helpers/CustomMethodTwo`
  - `DotNet/AspNetCoreMvc.Helpers/CustomStaticMethodOne`
  - `DotNet/AspNetCoreMvc.Helpers/CustomStaticMethodTwo`
- `WebTransaction/MVC/Agents/Show`
  - `DotNet/AgentsController/Show`
  - `DotNet/AspNetCoreMvc.Helpers/CustomMethodOne`
  - `DotNet/AspNetCoreMvc.Helpers/CustomMethodTwo`
  - `DotNet/AspNetCoreMvc.Helpers/CustomStaticMethodOne`
  - `DotNet/AspNetCoreMvc.Helpers/CustomStaticMethodTwo`


### AspNetCoreMvc.Helpers

The `Helpers.cs` file defines the `AspNetCoreMvc.Helpers` class.
This class contains a few additional methods that are instrumented using the .NET Agent's API.

The custom helpers file defines 2 staic methods, `CustomStaticMethodOne` and
`CustomStaticMethodTwo`, and 2 instance methods, `CustomMethodOne`,
and `CustomMethodTwo`

Both *One methods call their respective *Two method to create a nested segment.

The 4 methods produce the following New Relic metric names:

- `DotNet/AspNetCoreMvc.Helpers/CustomMethodOne`
- `DotNet/AspNetCoreMvc.Helpers/CustomMethodTwo`
- `DotNet/AspNetCoreMvc.Helpers/CustomStaticMethodOne`
- `DotNet/AspNetCoreMvc.Helpers/CustomStaticMethodTwo`

## Running the Demo With Docker

This demo can be run in a few different ways:
- It has a dockerfile that will build and run the application on Linux
- It can be built in Visual Studio, published and run
- It can be built with `dotnet build`, published and run

### Software Prerequisites

- [Docker](https://www.docker.com/get-started/)
- [.NET Core 3.1 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/3.1)
- Visual Studio 
-

### Instructions for Docker

1. Clone this repository
2. Place an extracted copy of the Agent's files in the `newrelic` directory.
3. From `AspNetCoreMvc` directory the Run `docker build -t clm-aspnetcoremvc:latest .\`
4. After the build run `docker run -d --env NEW_RELIC_LICENSE_KEY=<YOUR_LICENSE_KEY> --env NEW_RELIC_APP_NAME=<YOUR_APP_NAME> -p <PORT_YOU_WANT>:80 clm-aspnetcoremvc:latest`
5. You can exercise the app by going to `https:/localhost:<PORT_YOU_WANT>` and browsing around the UI.

### Instructions for Visual Studio (Windows)

1. Clone this repository
2. Open the solution, `CodeLevelMetricsDemo\CodeLevelMetricsDemo.sln`
3. Rebuild the solution
4. Right-click on the `AspNetCoreMvc` project and select `Publish`
5. Publish the project using the `FolderProfile`
6. Install the agent from the test MSI
7. Start Powershell and change to the `CodeLevelMetricsDemo\publis\AspNetCoreMvc` directory (must be done AFTER installing the agent to pick up the env vars)
8. Run `AspNetCoreMvc.exe`
5. You can exercise the app by going to `https:/localhost:5001` and browsing around the UI.

### Instructions for Visual Studio (Windows)
1. Install the agent from the test MSI
2. Clone this repository
3. Run Powershell and change directory to the cloned repo
4. Run `dotnet publish .\CodeLevelMetricsDemo.sln`
5. Change to the `CodeLevelMetricsDemo\publis\AspNetCoreMvc` directory (must be done AFTER installing the agent to pick up the env vars)
6. Run `AspNetCoreMvc.exe`
7. You can exercise the app by going to `https:/localhost:5001` and browsing around the UI.