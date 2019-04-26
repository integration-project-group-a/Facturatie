using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace FacturatieLibrary.Sender
{
    public class SenderFacturatie
    {
        public static void Send()
        {
            var factory = new ConnectionFactory() { HostName = "10.3.56.27", Password = "ehb", UserName = "manager" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: "logs", type: "fanout");
                Int32 unixTimestamp = (Int32)(DateTime.Now.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                String xmlStr = @"<message>
	                                <header>
		                                <messageType>Visitor</messageType>
		                                <description>Creation of a visitor</description>
		                                <sender>front-end</sender><!-- front-end, crm, facturatie, kassa, control-room, planning -->
	                                </header>
	                                <datastructure>
		                                <UUID>x2de0z0d</UUID>
		                                <name>
			                                <firstname>Anthe</firstname>
			                                <lastname>Boets</lastname>
		                                </name>
		                                <email>anthe.boets1@student.ehb.be</email>
		                                <GDPR>true</GDPR>
		                                <timestamp>1555934040</timestamp>
		                                <version>1</version>
		                                <isActive>true</isActive>
		                                <banned>false</banned>
		                                <!-- Not required fields -->
		                                <geboortedatum>1999-04-30T00:00:00+00:00</geboortedatum>
		                                <btw-nummer>BE15656464654</btw-nummer>
		                                <gsm-nummer>015313164165468</gsm-nummer>
		                                <extraField></extraField>
	                                </datastructure>
                                </message>";

                var messagetest = XDocument.Parse(xmlStr);

                var body = Encoding.UTF8.GetBytes(xmlStr);
                channel.BasicPublish(exchange: "logs", routingKey: "", basicProperties: null, body: body);
            }
        }
    }
}
