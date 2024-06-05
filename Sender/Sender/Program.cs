using RabbitMQ.Client;
using Sender;
using System.Text;
using System.Text.Json;

var factory = new ConnectionFactory { HostName = "localhost" };
using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();

channel.QueueDeclare(queue: "transferencia",
    durable: false,
    exclusive: false,
    autoDelete: false,
    arguments: null);

while (true)
{
    string message = Console.ReadLine();

    if (string.IsNullOrEmpty(message))
        break;

    var aluno = new Aluno { ID = 0, Name = "Aluno 1" };
    
    message = JsonSerializer.Serialize(aluno);

    var body = Encoding.UTF8.GetBytes(message);

    channel.BasicPublish(exchange: string.Empty,
        routingKey: "transferencia",
        basicProperties: null,
        body: body);

    Console.WriteLine($"Mensagem enviada >>> {message}");
}

