using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace Chat.ChatWebBrowser.RabbitMQ
{
    public class Receiver
    {
        public string method()
        {
            var message = "";
            var factory = new ConnectionFactory
            {
                HostName = "localhost",
                UserName = "byronpenna",
                Password = "byronpenna123"
            };
            using (var connection = factory.CreateConnection())
            {
                using(var channel = connection.CreateModel())
                {
                    channel.QueueDeclare("roomQueue", false, false, false, null);
                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += (model, ea) =>
                    {
                        var body = ea.Body.Span;
                        message = Encoding.UTF8.GetString(body);

                    };

                    channel.BasicConsume("roomQueue",true,consumer);
                }
            }
            return message;
        }
    }
}
