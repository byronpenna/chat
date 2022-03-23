using Microsoft.AspNetCore.SignalR;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Chat.Entities.POCOEntities;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Chat.ChatWebBrowser
{

    public class ChatHub:Hub
    {
        private readonly IOptions<MyAPIConfig> _APIConfig;
        public ChatHub( IOptions<MyAPIConfig> config)
        {
            _APIConfig = config;
        }
        public decimal getPrice()
        {
            decimal price = 93.42m;
            return price;
        }
        public async Task SendMessage(string room,string user,string message)
        {
            var ses = Context.GetHttpContext().Session;
            var userID = Context.GetHttpContext().Session.GetString("userID");

            try
            {
                bool save = true;
                var isAPIcall = message.Contains("/stock=");
                if (isAPIcall)
                {
                    save = false;
                    int i = message.IndexOf("=");
                    string code = message.Substring(i + 1);
                    string url = this._APIConfig.Value.url + "User/get-stock-by-command?stockCode=" + code;
                    ApiHelper.InicializeClient();
                    using (HttpResponseMessage response = await ApiHelper.apiClient.GetAsync(url))
                    {
                        message = await response.Content.ReadAsStringAsync();
                    }
                    //decimal price = getPrice();
                    //message = "APPL.US quote is $" + price.ToString("#.##") + " per share.";
                }

                if (save)
                {
                    string url = this._APIConfig.Value.url + "User/save-message";
                    ApiHelper.InicializeClient();
                    Message messageToInsert = new Message()
                    {
                        content = message,
                        createdDate = DateTime.Now,
                        UserId = Convert.ToInt32(userID),
                        RoomId = Convert.ToInt32(room)
                    };
                    string jsonToSend = JsonConvert.SerializeObject(messageToInsert);
                    HttpContent content = new StringContent(jsonToSend, System.Text.Encoding.UTF8, "application/json");
                    string success = "";
                    using (HttpResponseMessage response = await ApiHelper.apiClient.PostAsync(url,content))
                    {
                        success = await response.Content.ReadAsStringAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                string y = "";
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
