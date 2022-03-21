using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Chat.ChatWebBrowser
{
    public class ChatHub:Hub
    {
        public decimal getPrice()
        {
            decimal price = 93.42m;
            return price;
        }
        public async Task SendMessage(string room,string user,string message)
        {
            var isAPIcall = message.Contains("/stock=");
            if (isAPIcall)
            {
                decimal price = getPrice();
                message = "APPL.US quote is $" + price.ToString("#.##") + " per share.";
            }
                
            await Clients.Group(room).SendAsync("ReceiveMessage",user, message);
        }

        public async Task AddToGroup(string room)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, room);
            //await Clients.Group(room.ToString()).SendAsync("ReceiveMessage",)
            await Clients.Group(room).SendAsync("ShowWho", $"Alguien se conecto{Context.ConnectionId}");

        }
    }
}
