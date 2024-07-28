using RabbitMQ.Client;
using System.Text;

while (true)
{
    Thread.Sleep(1000);

    var factory = new ConnectionFactory() { HostName = "localhost" };
    using (var connection = factory.CreateConnection())
    using (var channel = connection.CreateModel())
    {
        channel.QueueDeclare(
            queue: "test",
            durable: false,
            autoDelete: false,
            arguments: null);

        var message = "Hello world!";

        var body = Encoding.UTF8.GetBytes(message);

        channel.BasicPublish(
            exchange: string.Empty,
            routingKey: "test",
            basicProperties: null,
            body: body);

        Console.WriteLine("Message have been sent!");
    }
}