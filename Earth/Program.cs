using RabbitMQ.Client;
using System.Text;

namespace Earth
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Earth");

            var factory = new ConnectionFactory()
            {
                HostName = "localhost",
            };

            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare("inbox",
                false,
                false,
                false,
                null);

            var message = " ";

            while (message != string.Empty)
            {
                Console.WriteLine("type Message :");

                message = Console.ReadLine();

                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish("",
                    "inbox",
                    null,
                  body);

                Console.WriteLine("sent from [Earth] : " + message);
            }

        }
    }
}