using Chat.ChatWebBrowser.Configurations;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace Chat.ChatWebBrowser.RabbitMQ
{
    public class Receiver
    {
        private readonly IOptions<RabbitMQConfig> _RabbitConfig;
        public Receiver(IOptions<RabbitMQConfig> config)
        {
            this._RabbitConfig = config;
        }
        public string Receive(string queue)
        {
            var factory = new ConnectionFactory()
            {
                HostName = this._RabbitConfig.Value.Server,
                UserName = this._RabbitConfig.Value.UserName,
                Password = this._RabbitConfig.Value.Password
            };
            string msg = "";
            using (var connection = factory.CreateConnection())
            {
                using(var channel = connection.CreateModel())
                {
                    channel.QueueDeclare("roomQueue", false, false, false, null);
                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += (model, ea) =>
                    {
                        var body = ea.Body.Span;
                        msg = Encoding.UTF8.GetString(body);

                    };

                    channel.BasicConsume(queue,true,consumer);
                }
            }
            return msg;
        }
    }
}
