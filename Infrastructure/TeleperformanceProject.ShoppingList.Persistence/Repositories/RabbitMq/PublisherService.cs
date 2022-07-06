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
            //Creating the RabbitMQ connection with Using Because it must close connection when it send the message!
            using var connection = _rabbitMqConnection.GetRabbitMqConnection();
            using var channel = connection.CreateModel();

            //Creating exchanges and queues
            channel.ExchangeDeclare(exchange: "direct.test", type: "direct", durable: false, autoDelete: false);
            channel.QueueDeclare(queue: queueName, durable: false, exclusive: false, autoDelete: true);

            //Binding the exchanges and queues created into eachother with routingkey
            channel.QueueBind(queue: queueName, exchange: "direct.test", routingKey: routingKey);

            //User is an object, for that changing that into Bytes..
            var messageBody = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(dto));

            //At last, we are publishing the message.
            channel.BasicPublish(exchange: "direct.test", routingKey: routingKey, basicProperties: null, body: messageBody);
        }
    }
}
