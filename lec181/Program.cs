using lec181;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();


// Single Page Application
// In first request, we will get only single html page
// After that, we will get only data from server
// We will use javascript to render data on client side
// We will use C# to write code on server side
// We will use SignalR to communicate between client and server
// We will use WebAssembly to run C# code on client side
// We will use Blazor to write C# code on client side
// We will use Razor to write C# code on server side
// We will use ASP.NET Core to write C# code on server side
// We will use .NET Core to write C# code on server side

// Blazor is a framework for building interactive client-side web UI with .NET
// Blazor is a feature of ASP.NET Core
// Blazor is a single page application framework
// Blazor is a web framework
// Blazor is a web UI framework
// Blazor is a web user interface framework
// Blazor is a web user interface library
// Blazor is a web user interface toolkit
// Blazor is a web user interface component library
// Blazor is a web user interface component toolkit


// Explain Blazor Server
// Explain Blazor WebAssembly

// WebAssembly - all browser can understand this.

// Proram.cs is the entry point
// In Index,html - we get #app id and work with this div
// App.razor is next after Program.cs
// it contains - Found * NotFound
// Found contains DefaultLayout - which is default Layout - MainLayout
// MainLayout - contains NavMenu and other things and @Body
// @page - to tell how to get to this component
// Single Component have three parts
//      1 - Page Directive - @page
//      2 - Markup Section - html
//      3 - Logic Section - c# code