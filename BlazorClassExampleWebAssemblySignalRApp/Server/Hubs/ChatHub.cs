using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace BlazorClassExampleWebAssemblySignalRApp.Server.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
        public async Task SendMessageToCaller(string user, string message)
        {
            await Clients.Caller.SendAsync("ReceiveMessage", user, message);
        }
        public async Task SendMessageToOthers(string user, string message)
        {
            await Clients.Others.SendAsync("ReceiveMessageOthers", user, message);
        }
        public async Task SendPingToOthers(string user)
        {
            await Clients.Others.SendAsync("PingUsers", user);
        }
        public async Task SendPingToCaller(string user)
        {
            var rand = new Random();
            int numberFromServer = rand.Next(1000);
            // the number of values sent back to the client doesn't always have to be the same number as the values it received
            // We received 1 value (user), and sent 2 back (user and a random number)
            await Clients.Caller.SendAsync("PingMyself", user, numberFromServer);
        }

    }
}