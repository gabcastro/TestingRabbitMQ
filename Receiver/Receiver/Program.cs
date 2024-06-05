using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Receiver;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

var factory = new ConnectionFactory { HostName = "localhost" };
using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();

channel.QueueDeclare(queue: "transferencia",
    durable: false,
    exclusive: false,
    autoDelete: false,
    arguments: null);

var consumer = new EventingBasicConsumer(channel);
consumer.Received += (model, ea) =>
{
    var body = ea.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);

    var aluno = JsonSerializer.Deserialize<Aluno>(message);

    Console.WriteLine($"Dado recebido >>> {message}");
};

channel.BasicConsume(queue: "transferencia",
    autoAck: false,
    consumer: consumer);

Console.WriteLine("Aperte enter para sair");
Console.ReadLine();