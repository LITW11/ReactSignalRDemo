# ReactSignalRDemo

To get started with SignalR, there are a few bits of setup we need to do.

First, in the `ClientApp/vite.config.js` file, add the following line:

```
ws: true
```

See here: https://github.com/LITW11/ReactSignalRDemo/blob/master/ReactSignalRDemo.Web/ClientApp/vite.config.js#L14

Then, create a class in the root of your application that inherits from `Hub`. You'll have to add a `using` statement at the top of your class (`using Microsoft.AspNetCore.SignalR;`). See my sample here:

https://github.com/LITW11/ReactSignalRDemo/blob/master/ReactSignalRDemo.Web/TestHub.cs

Then, in your `Program.cs` you need the following two lines:

https://github.com/LITW11/ReactSignalRDemo/blob/master/ReactSignalRDemo.Web/Program.cs#L10

and

https://github.com/LITW11/ReactSignalRDemo/blob/master/ReactSignalRDemo.Web/Program.cs#L23

For the second one, it doesn't have to be `/api/test` it can be whatever you want, just make sure it starts with `/api/` (because of how our Vite application and proxy is set up).

For the JavaScript side of things, you'll need to install the following npm package into your `ClientApp`:

```
npm i @microsoft/signalr
```

A few notes:

To get access to the Hub from within a controller, you can have it injected into the constructor of the controller:

https://github.com/LITW11/ReactSignalRDemo/blob/master/ReactSignalRDemo.Web/Controllers/PeopleController.cs#L38-L43

Also, if you need access to the currently logged in user from within the `Hub`, you can do `Context.User.Identity.Name`:

https://github.com/LITW11/ReactSignalRDemo/blob/master/ReactSignalRDemo.Web/TestHub.cs#L29

Lastly, if you need the connection string in the hub, you can have the `IConfiguration` injected into the constructor of the Hub:

https://github.com/LITW11/ReactSignalRDemo/blob/master/ReactSignalRDemo.Web/TestHub.cs#L10-L13
