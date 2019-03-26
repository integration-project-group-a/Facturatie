using Newtonsoft.Json.Linq;
using System;

namespace Facturatie
{
    class Program
    {
        static void Main()
        {
            // Receiver test

            string xml =
                    @"<Message>
	                    <header>
		                    <!-- type of message -->
		                    <MessageType>Visitor</MessageType>
		                    <!--What your Message does -->
		                    <description>Invoice for visitor</description>
		                    <!--Who sent it-->
		                    <!--(fronted, crm, facturatie, kassa, monitor, planning, uuid) -->
		                    <sender></sender> <!-- kassa, crm, front-end -->
	                    </header>
	                    <datastructure>
		                    <!-- required fields = UUID name + email & hashing. -->
		                    <UUID>UUID1000</UUID><!-- id of the user -->
		                    <invoiceID>12</invoiceID>
		                    <name>
			                    <firstname>Jan</firstname>
			                    <lastname>Jansens</lastname>
		                    </name> <!-- kassa  , front-end  -->
		                    <email>jan@hotmail.com</email>
		                    <GDPR>true</GDPR>
		                    <timestamp>1552435145</timestamp>
		                    <version>1</version>
		                    <isActive>true</isActive>
		                    <hasInvoice>false</hasInvoice>
		                    <banned>false</banned>
		                    <!-- Not required fields -->
		                    <birthdate>1998-02-12</birthdate>
		                    <btw-number></btw-number>
		                    <phone/>
		                    <publicNotes/>
		                    <extraField/>
	                    </datastructure>
                    </Message>
                    ";

            string json = Receiver.XmlToJSON(xml);

            //Console.WriteLine(json);

            dynamic obj = JObject.Parse(json);

            string firstname = obj.Message.datastructure.name.firstname;
            string lastname = obj.Message.datastructure.name.lastname;
            string email = obj.Message.datastructure.email;
            string birthdate = obj.Message.datastructure.birthdate;

            //Client.CreateClient(firstname, email, firstname, lastname);


            Console.WriteLine(firstname);
            Console.WriteLine(lastname);
            Console.WriteLine(email);
            Console.WriteLine(birthdate);



            //-------------------------------------------


            // Sender test


            /*
            Rootobject obj = JsonConvert.DeserializeObject<Rootobject>(@"" + Rootobject.GetClient(38));

            Console.WriteLine(obj.contacts[0].first_name);
            */




            /*
            string json = Client.GetClient(38);

            dynamic obj = JObject.Parse(json);

            //Client user = JsonConvert.DeserializeObject<Client>(json);

            string first_name = obj.data.contacts[0].first_name;

            Console.WriteLine(first_name);
            */
        }
    }
}
