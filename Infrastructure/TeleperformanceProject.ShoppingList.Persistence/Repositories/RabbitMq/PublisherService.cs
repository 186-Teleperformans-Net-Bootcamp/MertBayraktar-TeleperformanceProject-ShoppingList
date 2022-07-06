using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using RabbitMQ.Client;
using TeleperformanceProject.ShoppingList.Application.DTOs;
using TeleperformanceProject.ShoppingList.Application.Repositories.RabbitMq;
using TeleperformanceProject.ShoppingList.Domain.Entities;

namespace TeleperformanceProject.ShoppingList.Persistence.Repositories.RabbitMq
{
    public class PublisherService : IPublisherService
    {
        private readonly IRabbitMqConnection _rabbitMqConnection;

        public PublisherService(IRabbitMqConnection rabbitMqConnection) => _rabbitMqConnection = rabbitMqConnection;

        public void Publish(ShopListDto dto, string queueName, string routingKey)
        {
            
            using var connection = _rabbitMqConnection.GetRabbitMqConnection();
            using var channel = connection.CreateModel();

           
            channel.ExchangeDeclare(exchange: "direct.test", type: "direct", durable: false, autoDelete: false);
            channel.QueueDeclare(queue: queueName, durable: false, exclusive: false, autoDelete: true);

            
            channel.QueueBind(queue: queueName, exchange: "direct.test", routingKey: routingKey);

           
            var messageBody = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(dto));

            
            channel.BasicPublish(exchange: "direct.test", routingKey: routingKey, basicProperties: null, body: messageBody);
        }
    }
}
