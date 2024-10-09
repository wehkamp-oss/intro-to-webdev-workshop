# intro-to-webdev-workshop

This repository contains a sample application and setup to follow along with the containerized web development workshop. It is currently based on .NET 8 and uses containers for the fixtures service and the to-be-built service.

# Requirements

To follow along you will need at least the following:

- A working .NET 8 SDK
- An editor (like Visual Studio Code, Rider or Visual Studio, but vim also works)
- A container runtime (for desktop users, Rancher Desktop, Podman Desktop and Docker Desktop works)
- A browser (mostly for Swagger, you can use curl or wget if you want to)

This has been tested on macOS, Linux and Windows and works purely on the command line as well as with a GUI.

# Scenario

We have a set of products, and we would like to make sure we can only sell products that are actually sellable to the customer that is asking for it. Some limits on products might be:

- Product is only available as a combination
- Product requires specific logistical handling which must be available
- Only a specific store is allowed to sell the product

A project and working container that runs the API for you is provided, including a Swagger test page.
This API will give you products (all of them, if you specify nothing), but it doesn't know anything about what you're intending to do with it.

## First Task: Setup

To start off, we will validate that everything runs as-is. This is going to make sure that we are ready to make changes.

1. Since you are reading this, you have access to the repository, so clone it to a location of your choice (`git clone <URL>`)
2. Open a shell (i.e. a `bash` or `zsh` shell, but `PowerShell` might work -- untested!) and navigate to the cloned repository
3. Make sure the container runtime of your choice is active (i.e. `Rancher Desktop` is started and ready), you can check by running `docker ps` and if it shows no errors, you are good to go (uncluding if it shows no running containers or some pre-existing containers)

Once you have completed those steps, you can already run the project without doing anything in an editor:

`docker compose up `

As a reminder, this has to be executed from a shell that has the docker command available, a runtime that will execute those commands, and you have to be inside the directoy this README file lives in (usually the cloned repository).

You should see some output from container processes starting and running, and it will remain in the foreground while it is running.

Navigating to `http://localhost:8080/swagger/index.html` in a browser will yield the Swagger UI.

If all of this was successful, we can continue to the next step. If not, you must troubleshoot and repair before you can continue.

### Second Task: Get the secondary project running

Since we will be following a scenario that requires us to create a service that talks to the existing API but does something the existing API cannot do on its own, we will need a working secondary project.

We have provided a placeholder project that will be a suitable starting point, it has been provisioned with:

- A dotnet 8 configuration
- Targets and configurations to build a container on demand
- Some sample endpoints that do serve as placeholders
- Swagger so you get a nice test interface for free

## Common Mistakes

## Getting an error about some .NET SDK targeting

This solution has projects that are specifically asking for the Dot Net SDK 8, so if you have some other version you might see an error like this when you run the `restore` command:

````
Determining projects to restore...
/usr/local/share/dotnet/sdk/6.0.405/Sdks/Microsoft.NET.Sdk/targets/Microsoft.NET.TargetFrameworkInference.targets(144,5): error NETSDK1045: The current .NET SDK does not support targeting .NET 8.0.  Either target .NET 6.0 or lower, or use a version of the .NET SDK that supports .NET 8.0. [/Users/username/Documents/intro-to-webdev-workshop/src/WRG.Products.Service/WRG.Products.Service.csproj]
````

In this example, it's because the `dotnet` command from the older `6` version is used. Installing `8` or changing which command is used during the restore will mitigate this.
