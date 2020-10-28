#addin nuget:?package=Cake.Figlet

var target = Argument("Target", "AllDefault");
var configuration = Argument("Configuration", "Release");
var cakeVersion = typeof(ICakeContext).Assembly.GetName().Version.ToString();
var distDirectory = Directory("./dist");

Information(Figlet("SIB.NET"));
Information(("Application: Sample API"));
Information($"Running target {target} in configuration {configuration}");
Information("Bulding using version {0} of cake", cakeVersion);

#region .: DotNetCore Tasks :.

// Deletes the contents of the Artifacts folder if it contains anything from a previous build.
Task("Clean")
    .Does(() =>
    {
        CleanDirectory(distDirectory);
    });

// Run dotnet restore to restore all package references.
Task("Restore")
    .Does(() =>
    {
        DotNetCoreRestore();
    });

// Build using the build configuration specified as an argument.
Task("Build")
    .Does(() =>
    {
        DotNetCoreBuild(".",
            new DotNetCoreBuildSettings()
            {
                Configuration = configuration,
                ArgumentCustomization = args => args.Append("--no-restore"),
            });
    });

// Look under a 'Tests' folder and run dotnet test against all of those projects.
// Then drop the XML test results file in the Artifacts folder at the root.
Task("Test")
    .Does(() =>
    {
        var projects = GetFiles("./test/**/*.csproj");
        foreach(var project in projects)
        {
            Information("Testing project " + project);
            DotNetCoreTest(
                project.ToString(),
                new DotNetCoreTestSettings()
                {
                    Configuration = configuration,
                    NoBuild = true,
                    ArgumentCustomization = args => args.Append("--no-restore"),
                });
        }
    });

// Publish the app to the /dist folder
Task("PublishWeb")
    .Does(() =>
    {
        var projects = GetFiles("./src/service/**/*.csproj");
        
        foreach(var project in projects)
        {
            DotNetCorePublish(
                project.ToString(),
                new DotNetCorePublishSettings()
                {
                    Configuration = configuration,
                    OutputDirectory = distDirectory,
                    ArgumentCustomization = args => args.Append("--no-restore")
                });
        }
    });

// A meta-task that runs all the steps to Build and Test the app
Task("BuildAndTest")
    .IsDependentOn("Clean")
    .IsDependentOn("Restore")
    .IsDependentOn("Build")
    .IsDependentOn("Test");

// The default task to run if none is explicitly specified. In this case, we want
// to run everything starting from Clean, all the way up to Publish.
Task("AllDefault")
    .IsDependentOn("BuildAndTest")
    .IsDependentOn("PublishWeb");

#endregion

RunTarget(target);