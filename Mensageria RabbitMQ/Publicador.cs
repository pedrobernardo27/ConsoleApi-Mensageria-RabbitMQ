using System.Text;
using RabbitMQ.Client;

namespace Mensageria_RabbitMQ
{
    public class Publicador
    {
        public void Publicar()
        {
            try
            {
                var factory = new ConnectionFactory
                {
                    HostName = "localhost"
                };

                using (var connection = factory.CreateConnection())
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "teste",
                                    durable: false,
                                    exclusive: false,
                                    autoDelete: false,
                                    arguments: null);

                    const string message = "Hello World!";
                    var body = Encoding.UTF8.GetBytes(message);

                    channel.BasicPublish(exchange: string.Empty,
                                         routingKey: "teste",
                                         basicProperties: null,
                                         body: body);
                    Console.WriteLine($" [x] Sent {message}");
                }

                Console.WriteLine(" Press [enter] to exit.");
                Console.ReadLine();
            }

            catch (Exception ex)
            {

                throw new Exception($"{ex.Message}");
            }
        }
    }
}
