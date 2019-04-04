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
                String xmlStr = "<!DOCTYPE Message SYSTEM \"messageError.dtd\"><MessageError><header><MessageType>MessageError</MessageType><description>Give information about errors with or in the rabbit MQ messages</description><sender>monitor</sender></header><datastructure><UUID>1</UUID><sendersystem>Invoice</sendersystem><destination>all</destination><error>404</error><importance>yes</importance><timestamp>" + unixTimestamp + "</timestamp><version>1</version><extraField></extraField></datastructure></MessageError>";

                var messagetest = XDocument.Parse(xmlStr);

                var body = Encoding.UTF8.GetBytes(xmlStr);
                channel.BasicPublish(exchange: "logs", routingKey: "", basicProperties: null, body: body);
            }
        }
    }
}
