using Consumer.RabbitMq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;



var host = Host.CreateDefaultBuilder().ConfigureServices((services) =>
        services.AddScoped<IConsumerService, ConsumerService>())
    .Build();



var _consumer = host.Services.GetRequiredService<IConsumerService>();


_consumer.Consume(queueName: "direct.email", IsAcknowledgeAuto: false);

host.Run();
