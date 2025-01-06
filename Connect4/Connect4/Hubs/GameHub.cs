using Microsoft.AspNetCore.SignalR;

namespace Connect4.Hubs;

public class GameHub : Hub
{
    public async Task PlayerMovement(string user, string message)
    {
        await Clients.All.SendAsync("ReceiveMessage", user, message);
    }
}