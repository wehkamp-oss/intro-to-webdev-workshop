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

We have provided a placeholder project (two actually) that will be a suitable starting point, it has been provisioned with:

- A dotnet 8 configuration
- Targets and configurations to build a container on demand
- Some sample endpoints that do serve as placeholders
- Swagger so you get a nice test interface for free

You can run this as a container, or as an in-IDE binary and it will work all the same. During development it doesn't matter, but it has to be able to be produced as a container since that is what CI and CD in the real world is going to need, and it is what other teams you would collaborate with would also need.
Start the project and you should be provided with a running API endpoint that shows some demo project from Microsoft (likely the ToDo one).

This is where you will be adding the code for the workshop, and if needed, you can look at the code for the pre-built 'product' service for (limited) inspiration.

### Third Task: Start implementing!

The first thing we're going to do is build an API service that has a job that seems simple at first: given an order, find out if the order can actually be fulfilled.
A fake order might look like this:

```json
{
    "customer": "458212368",
    "salesSegment": 1,
    "orderLines": [
      {
        "productNumber": 17151519,
        "quantity": 2,
        "sizeCode": "001"

      },
      {
        "productNumber": 17151520,
        "quantity": 1,
        "sizeCode": "002"
      },
      {
        "productNumber": 17151524,
        "quantity": 1,
        "sizeCode": "001"
      }
    ]
}
```
You have to be able to ingest such a paylod in your API on an endpoint: `/order`.
This will then need to be input-validated by a method of your choice and then used to query the product API we provided for product information.

This is something you can also do using a method of your choice, but a simple HTTP client and some JSON handing might be simple enough.

When requesting information about a product, you will either get that information, or you will be informed the information is not available.
If the information is available, it will look like this:

```json
 {
    "name": "Adidas Ultraboost",
    "brand": "Adidas",
    "productNumber": "17151523",
    "sizeCode": "004",
    "salesSegment": 3,
    "ean": "5702017156064",
    "articleGroup": "Shoes",
    "supplierId": "e7a58e97-4b5e-4fff-bf41-46c803f35ade",
    "shippingMethod": 1,
    "purchasePrice": 90,
    "salesPrices": [
      {
        "salesSegment": 1,
        "salesPrice": 130
      },
      {
        "salesSegment": 2,
        "salesPrice": 150
      }
    ],
    "creationDateTime": "2024-09-23T22:39:58.243948+02:00",
    "mutationDateTime": "2024-09-29T23:19:58.243949+02:00"
}
```

You can use this information for each orderLine to check the following:

- If the product exists, is it valid for the salesSegment the customer is ordering for?
  - The salesSegment in the product is a sum of available salesSegments
  - The actual availability of a salesSegment is also described in the salesPrices array
- We can also see the shippingMethod, we have to keep track of which ones we have seen

If all produces listed in the order exist, and there are no mis-matches in the salesSegments, return your findings.

The findings must also be in JSON format, which looks like this for a bad order:

```json
 {
    "canOrder": false,
    "errors": [
      {
        "productNumber": 17151519,
        "reason": "product configuration does not exist"
      },
      {
        "productNumber": 17151520,
        "reason": "sales segment not available"
      }
    ]
}
```

and like this for an order we can process:

```json
 {
    "canOrder": true,
    "orders": [
      {
        "logisticsOrderNumber": 10000001,
        "shippingMethod": 1
      },
      {
        "logisticsOrderNumber": 10000002,
        "shippingMethod": 2
      }
    ]
}
```

For the `logisticsOrderNumber` you can make up any sequence you like at this stage.


### Extra Tasks: There is always more to explore

Imagine the following: while we now know if an order is in theory something we can process, we don't know if we can actually ship it, or in what shape.
There are some pieces missing:

- Stock information, keeping track of which items in which sizes we have in stock?
- Shipping capacity, which shipping methods are still available today?
- For both: can we do a split delivery where some parts are shipped now and other parts are shipped later?

Assume this information is managed by different teams with different dependencies and stakeholders.
They will want to manage their own information flows and processes:

- A service about stock and supplier input will not be owned by the team that does customer orders
- A logistics capacity planning service will be owned by the logistics center and nobody else

This means at least two extra services would need to be created. One to keep track of delivery options, another for stock.

## Common Mistakes

## Getting an error about some .NET SDK targeting

This solution has projects that are specifically asking for the Dot Net SDK 8, so if you have some other version you might see an error like this when you run the `restore` command:

````
Determining projects to restore...
/usr/local/share/dotnet/sdk/6.0.405/Sdks/Microsoft.NET.Sdk/targets/Microsoft.NET.TargetFrameworkInference.targets(144,5): error NETSDK1045: The current .NET SDK does not support targeting .NET 8.0.  Either target .NET 6.0 or lower, or use a version of the .NET SDK that supports .NET 8.0. [/Users/username/Documents/intro-to-webdev-workshop/src/WRG.Products.Service/WRG.Products.Service.csproj]
````

In this example, it's because the `dotnet` command from the older `6` version is used. Installing `8` or changing which command is used during the restore will mitigate this.
