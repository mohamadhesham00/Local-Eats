using MediatR;
using RabbitMQ.Client;
using RestaurantManagementSystem.Core.Common.Contracts.Services.MessagePublisher;
using System.Text;

namespace RestaurantManagementSystem.Infrastructure.Common.Services.MessageQueue
{
    public class MessagePublisher : IMessagePublisher
    {
        private static  IConfiguration _configuration;

        public MessagePublisher(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void PublishRquestApproved(string message)
        {
            string ExchangeName = "Restaurant-User-Exchange";
            string RoutingKey = "Demo-Routing-Key";
            string QueueName = "Request-Approved-Queue";
            Publish(ExchangeName, RoutingKey, QueueName, message);
        }
        
        private void Publish(string exchangeName, string routingKey
            , string queueName, string message)
        {
            var factory = new ConnectionFactory
            {
                HostName = _configuration["RabbitMQ:HostName"],
                UserName = _configuration["RabbitMQ:UserName"],
                Password = _configuration["RabbitMQ:Password"]
                // Add other configuration properties as needed
            };
            IConnection connection = factory.CreateConnection();
            IModel channel = connection.CreateModel();
            channel.ExchangeDeclare(exchangeName, ExchangeType.Direct);
            channel.QueueDeclare(queueName, false, false, false, null);
            channel.QueueBind(queueName, exchangeName, routingKey, null);

            byte[] MessageInBytes = Encoding.UTF8.GetBytes(message);
            channel.BasicPublish(exchangeName, routingKey, null, MessageInBytes);
            connection.Close();
            channel.Close();
        }
    }
}
