using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Facturatie
{
    class Invoice
    {
        public static void CreateInvoice(int id)
        {
            var request = (HttpWebRequest)WebRequest.Create("http://<url>/api/v1/invoices");

            request.ContentType = "application/json";
            request.Method = "POST";
            request.Headers.Add("X-Ninja-Token", "<token>");

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                string json = "{\"client_id\": \"" + id + "\", \"discount\": \"0\", \"due_date\": \"2020-05-12\", \"invoice_items\":[{\"id\": \"1\", \"product_key\": \"test\", \"cost\": \"12\", \"qty\": \"15\"}]}";

                streamWriter.Write(json);
            }

            var response = (HttpWebResponse)request.GetResponse();
            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
            }
        }

        public static void GetInvoice(int id)
        {
            var request = (HttpWebRequest)WebRequest.Create($"http://<url>/api/v1/invoices/{id}");

            request.ContentType = "application/json";
            request.Method = "GET";
            request.Headers.Add("X-Ninja-Token", "<token>");

            var response = (HttpWebResponse)request.GetResponse();
            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                Console.WriteLine(result);
            }
        }

        //Werkt niet
        /*
        public static void UpdateInvoice(int id)
        {
            var request = (HttpWebRequest)WebRequest.Create($"http://<url>/api/v1/invoices/{id}");

            request.ContentType = "application/json";
            request.Method = "PUT";
            request.Headers.Add("X-Ninja-Token", "<token>");

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                string json = "{\"id\": \"" + id + "\", \"discount\": \"0\", \"due_date\": \"2019-05-12\", \"invoice_items\":[{\"id\": \"1\", \"product_key\": \"test\", \"cost\": \"12\", \"qty\": \"15\"}]}";

                streamWriter.Write(json);
            }
        }
        */

        public static void DeleteInvoice(int id)
        {
            var request = (HttpWebRequest)WebRequest.Create($"http://<url>/api/v1/invoices/{id}?action=delete");

            request.ContentType = "application/json";
            request.Method = "PUT";
            request.Headers.Add("X-Ninja-Token", "<token>");

            var response = (HttpWebResponse)request.GetResponse();
            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
            }
        }
        public static void ArchiveInvoice(int id)
        {
            var request = (HttpWebRequest)WebRequest.Create($"http://<url>/api/v1/invoices/{id}?action=archive");

            request.ContentType = "application/json";
            request.Method = "PUT";
            request.Headers.Add("X-Ninja-Token", "<token>");

            var response = (HttpWebResponse)request.GetResponse();
            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
            }
        }
        public static void RestoreInvoice(int id)
        {
            var request = (HttpWebRequest)WebRequest.Create($"http://<url>/api/v1/invoices/{id}?action=restore");

            request.ContentType = "application/json";
            request.Method = "PUT";
            request.Headers.Add("X-Ninja-Token", "<token>");

            var response = (HttpWebResponse)request.GetResponse();
            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
            }
        }
    }
}

