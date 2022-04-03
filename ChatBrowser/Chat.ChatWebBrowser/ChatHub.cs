using Microsoft.AspNetCore.SignalR;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Chat.Entities.POCOEntities;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Chat.ChatWebBrowser.RabbitMQ;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using Chat.ChatWebBrowser.Configurations;

namespace Chat.ChatWebBrowser
{

    public class ChatHub:Hub
    {
        private readonly IOptions<MyAPIConfig> _APIConfig;
        private readonly IOptions<RabbitMQConfig> _RabbitConfig;
        private Sender _rabbitMQSender;
        public ChatHub( 
            IOptions<MyAPIConfig> config,
            IOptions<RabbitMQConfig> rabbitConfig
            )
        {
            _APIConfig = config;
            _RabbitConfig = rabbitConfig;
            this._rabbitMQSender = new Sender(rabbitConfig);
        }
        public async Task SendMessage(string room,string user,string message)
        {
            var ses = Context.GetHttpContext().Session;
            var userID = Context.GetHttpContext().Session.GetString("userID");

            try
            {
                bool save = true;
                var isAPIcall = message.Contains("/stock=");

                //set to rabitMQ
                this._rabbitMQSender.Send(room+"-sender",message);

                /*if (isAPIcall)
                {
                    save = false;
                    int i = message.IndexOf("=");
                    string code = message.Substring(i + 1);

                    string url = string.Format(this._APIConfig.Value.stockMethod,code);
                    ApiHelper.InicializeClient();
                    using (HttpResponseMessage response = await ApiHelper.apiClient.GetAsync(url))
                    {
                        message = await response.Content.ReadAsStringAsync();
                    }
                }*/

                
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

                /*var factory = new ConnectionFactory
                {
                    HostName = "localhost",
                    UserName = "byronpenna",
                    Password = "byronpenna123"
                };
                using (var connection = factory.CreateConnection())
                {
                    using (var channel = connection.CreateModel())
                    {
                        channel.QueueDeclare("roomQueue", false, false, false, null);
                        var consumer = new EventingBasicConsumer(channel);
                        consumer.Received += (model, ea) =>
                        {
                            var body = ea.Body.Span;
                            message = Encoding.UTF8.GetString(body);

                        };

                        channel.BasicConsume("roomQueue", true, consumer);
                    }
                }*/

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
