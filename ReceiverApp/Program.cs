using System.Text;
using RabbitMQ.Client;

var factory = new ConnectionFactory(){ HostName = "localhost" };
using(var connection = factory.CreateConnection())
using(var channel = connection.CreateModel())
{
    channel.QueueDeclare(queue: "firstQueue", 
                        durable: false,
                        autoDelete: false,
                        exclusive: false,
                        arguments: null);

    string message = "MDC Uzbekistan";
    var body = Encoding.UTF8.GetBytes(message);

    channel.BasicPublish(exchange: "",
                        routingKey: "firstQueue",
                        basicProperties: null,
                        body: body);
    Console.WriteLine("[x] sent {0}", message);
}
Console.WriteLine(" Press [enter] to exit.");
Console.ReadLine();
