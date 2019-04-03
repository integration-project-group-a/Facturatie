using Facturatie.Receiver;
using Facturatie.Sender;
using Newtonsoft.Json.Linq;
using System;

namespace Facturatie
{
    class Program
    {
        static void Main()
        {
            ReceiverFacturatie.Receive();

            //SenderFacturatie.Send();
        }
    }
}
