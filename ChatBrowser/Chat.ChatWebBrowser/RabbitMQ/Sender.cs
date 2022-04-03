using Chat.ChatWebBrowser.Configurations;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using System.Text;

namespace Chat.ChatWebBrowser.RabbitMQ
{
    public class Sender
    {
        private readonly IOptions<RabbitMQConfig> _RabbitConfig;
        public Sender(IOptions<RabbitMQConfig> config)
        {
            this._RabbitConfig = config;

        }
        public void Send(string queue,string msg)
        {
            var factory = new ConnectionFactory()
            {
                HostName = this._RabbitConfig.Value.Server,
                UserName = this._RabbitConfig.Value.UserName,
                Password = this._RabbitConfig.Value.Password
            };
            using (var connection = factory.CreateConnection())
            {
                using(var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue, false,false,false,null);
                    var body = Encoding.UTF8.GetBytes(msg);
                    channel.BasicPublish("",queue,null,body);
                    string y = "El mensaje fue enviado " + body;
                }

            }
        }
    }
}
