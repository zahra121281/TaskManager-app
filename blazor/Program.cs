using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using ToDoApiCli.Api ;
using ToDoApiCli.Client;
using ToDoApiCli.Model ;
using Microsoft.AspNetCore.SignalR.Client; 
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
public class Connection
{
    Configuration config = new Configuration {BasePath="http://localhost:5000" } ;
    public ToDoApi apiInstance {get ;set ;}
    public HubConnection hubConnection {get ;set ;}
    public Connection()
    {
        hubConnection = new HubConnectionBuilder() 
        .WithUrl("http://localhost:5000/HubServer").Build();  
        hubConnection.StartAsync() ;  
        apiInstance = new ToDoApi(config) ;
    }
    public ToDoApi objmake()
    {
        return apiInstance ; 
    }
    public static void Main()
    {

    }
}
