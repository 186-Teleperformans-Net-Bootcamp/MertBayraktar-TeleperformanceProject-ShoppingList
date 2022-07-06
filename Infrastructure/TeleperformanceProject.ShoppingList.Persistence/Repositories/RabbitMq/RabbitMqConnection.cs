using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using TeleperformanceProject.ShoppingList.Application.Repositories.RabbitMq;

namespace TeleperformanceProject.ShoppingList.Persistence.Repositories.RabbitMq
{
    public class RabbitMqConnection : IRabbitMqConnection
    {
        public IConnection GetRabbitMqConnection()
        {
            return new ConnectionFactory()
            {
                HostName = "localhost",
                VirtualHost = "/",
                Port = 5672,
                UserName = "guest",
                Password = "guest"

            }.CreateConnection();
        }
    }
}
