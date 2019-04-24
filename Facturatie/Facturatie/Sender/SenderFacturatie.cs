using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace Facturatie.Sender
{
    class SenderFacturatie
    {
        public static void Send()
        {
            var factory = new ConnectionFactory() { HostName = "10.3.56.27", Password = "ehb", UserName = "manager" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: "logs", type: "fanout");
                Int32 unixTimestamp = (Int32)(DateTime.Now.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                String xmlStr = @"<Visitor>
                                <header>
                                        <!-- type of message -->
                                        <MessageType>Visitor</MessageType>
                                        <!--What your Message does -->
                                        <description>Creation of a visitor</description>
                                        <!--Who sent it-->
                                        <!--(fronted, crm, facturatie, kassa, monitor, planning, uuid) -->
                                        <sender></sender> <!-- kassa, crm, front-end -->
                                </header>
                                <datastructure>
                                        <!-- required fields = UUID name + email & hashing. -->
                                        <UUID/> <!-- id of the user -->
                                        <name>
                                                <firstname>lol</firstname>
                                                <lastname>lol</lastname>
                                        </name> <!-- kassa  , front-end  -->
                                        <email>www.dfef@dada.com</email>
                                        <timestamp/>
                                        <version/>
                                        <isActive/>
                                        <banned/>
                                        <!-- Not required fields -->
                                        <geboortedatum/>
                                        <btw-nummer/>
                                        <gsm-nummer/>
                                        <GDPR/>
                                        <extraField/>
                                </datastructure>
                        </Visitor>";

                var messagetest = XDocument.Parse(xmlStr);

                var body = Encoding.UTF8.GetBytes(xmlStr);
                channel.BasicPublish(exchange: "logs", routingKey: "", basicProperties: null, body: body);
            }
        }
    }
}
