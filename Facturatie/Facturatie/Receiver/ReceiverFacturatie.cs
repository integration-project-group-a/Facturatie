using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Facturatie.Receiver
{
    class ReceiverFacturatie
    {
        public static void Receive()
        {
            var factory = new ConnectionFactory() { HostName = "10.3.56.27", Password = "ehb", UserName = "manager"};
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: "logs", type: "fanout");

                var queueName = channel.QueueDeclare().QueueName;
                channel.QueueBind(queue: queueName,
                                  exchange: "logs",
                                  routingKey: "");

                Console.WriteLine(" [*] Waiting for logs.");

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body;
                    var message = Encoding.UTF8.GetString(body);

                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(message);

                    string jsonText = JsonConvert.SerializeXmlNode(doc, Newtonsoft.Json.Formatting.None, true);

                    Console.WriteLine(jsonText);

                    dynamic obj = JObject.Parse(jsonText.ToLower());      //Json to JObject

                    string name = obj.datastructure.name.firstname;
                    string firstname = obj.datastructure.name.firstname;
                    string lastname = obj.datastructure.name.lastname;
                    string email = obj.datastructure.email;

                    Client.CreateClient(name, email, firstname, lastname); //enkel voor create client voorlopig
                };
                channel.BasicConsume(queue: queueName, autoAck: true, consumer: consumer);
                Console.ReadLine();
            }
        }
    }
}
