#addin "nuget:?package=Cake.Sonar"
#tool "nuget:?package=MSBuild.SonarQube.Runner.Tool"

///////////////////////////////////////////////////////////////////////////////
// ARGUMENTS
///////////////////////////////////////////////////////////////////////////////

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");

//////////////////////////////////////////////////////////////////////
// PREPARATION
//////////////////////////////////////////////////////////////////////
var buildDir = Directory("./Homologador/bin") + Directory(configuration);

///////////////////////////////////////////////////////////////////////////////
// SETUP / TEARDOWN
///////////////////////////////////////////////////////////////////////////////

Setup(ctx =>
{
   // Executed BEFORE the first task.
   Information("Running tasks...");
});

Teardown(ctx =>
{
   // Executed AFTER the last task.
   Information("Finished running tasks.");
});

///////////////////////////////////////////////////////////////////////////////
// TASKS
///////////////////////////////////////////////////////////////////////////////

Task("Clean")
    .Does(() =>
{
    CleanDirectory(buildDir);
});

Task("Restore-NuGet-Packages")
    .IsDependentOn("Clean")
    .Does(() =>
{
    NuGetRestore("./Homologador.sln");
});

Task("Build")
    .IsDependentOn("Restore-NuGet-Packages")
    .Does(() =>
{
    if(IsRunningOnWindows())
    {
      // Use MSBuild
      MSBuild("./Homologador.sln", settings =>
        settings.SetConfiguration(configuration));
    }
    else
    {
      // Use XBuild
      XBuild("./Homologador.sln", settings =>
        settings.SetConfiguration(configuration));
    }
});

Task("Sonar")
  .IsDependentOn("SonarBegin")
  .IsDependentOn("Build")
  .IsDependentOn("SonarEnd");
 
Task("SonarBegin")
  .Does(() => {
     SonarBegin(new SonarBeginSettings {
        Url = "http://localhost:8090",
        Name = "Homologador",
        Key = "default",
        Login = "admin",
        Password = "admin",
        Verbose = true
     });
  });

Task("SonarEnd")
  .Does(() => {
     SonarEnd(new SonarEndSettings {
        Login = "admin",
        Password = "admin",
     });
  });

Task("Default")
    .IsDependentOn("build");

RunTarget(target);