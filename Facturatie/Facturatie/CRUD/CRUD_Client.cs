using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Facturatie
{
    class Client
    {
        public static void CreateClient(string name = "", string email = "", string firstname = "", string lastname = "")
        {
            var request = (HttpWebRequest)WebRequest.Create("http://10.3.56.22/api/v1/clients");

            request.ContentType = "application/json";
            request.Method = "POST";
            request.Headers.Add("X-Ninja-Token", "a0tibzaccmgeset77nx8bgo0q7o9rwlk");

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                //string json = "{\"name\":\"Client\",\"contact\":{\"email\":\"michael1234567@test.com\",\"first_name\":\"Michael1\",\"last_name\":\"Johnson\"}}";

                string json = "{\"name\":\"" + name + "\",\"contact\":{\"email\":\"" + email + "\",\"first_name\":\"" + firstname + "\",\"last_name\":\"" + lastname + "\"}}";

                streamWriter.Write(json);
            }

            var response = (HttpWebResponse)request.GetResponse();
            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
            }
        }

        public static void GetClient(int id)
        {
            var request = (HttpWebRequest)WebRequest.Create($"http://<url>/api/v1/clients/{id}"); //geeft enkel op id

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

        //id moet in de json string en de url van de api (http://..../clients/38)
        public static void UpdateClient(int id)
        {
            var request = (HttpWebRequest)WebRequest.Create($"http://<url>/api/v1/clients/{id}");

            request.ContentType = "application/json";
            request.Method = "PUT";
            request.Headers.Add("X-Ninja-Token", "<token>");

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                string json = "\"name\":\"Client\",\"contact\":{\"email\":\"michaeldg2@test.com\",\"first_name\":\"Michael12\",\"last_name\":\"Johnson\"}}";

                streamWriter.Write(json);
            }

            var response = (HttpWebResponse)request.GetResponse();
            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
            }
        }

        public static void ArchiveClient(int id)
        {
            var request = (HttpWebRequest)WebRequest.Create($"http://<url>/api/v1/clients/{id}?action=archive");

            request.ContentType = "application/json";
            request.Method = "PUT";
            request.Headers.Add("X-Ninja-Token", "<token>");

            var response = (HttpWebResponse)request.GetResponse();
            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
            }
        }

        public static void DeleteClient(int id)
        {
            var request = (HttpWebRequest)WebRequest.Create($"http://<url>/api/v1/clients/{id}?action=delete");

            request.ContentType = "application/json";
            request.Method = "PUT";
            request.Headers.Add("X-Ninja-Token", "<token>");

            var response = (HttpWebResponse)request.GetResponse();
            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
            }
        }

        public static void RestoreClient(int id)
        {
            var request = (HttpWebRequest)WebRequest.Create($"http://<url>/api/v1/clients/{id}?action=restore");

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
