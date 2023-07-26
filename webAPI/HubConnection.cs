using Microsoft.AspNetCore.SignalR;

public class HubConnection : Hub
{
    public async Task HubServer()
    {
        await Clients.All.SendAsync("Notify") ; 
    }
}