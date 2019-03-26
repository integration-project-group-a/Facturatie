using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TestAPI4
{
    class Client
    {
        public async System.Threading.Tasks.Task CreateClient()
        {
            var request = (HttpWebRequest)WebRequest.Create("http://10.3.56.22/api/v1/clients");

            request.ContentType = "application/json";
            request.Method = "POST";
            request.Headers.Add("X-Ninja-Token", "a0tibzaccmgeset77nx8bgo0q7o9rwlk");

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                //string json = "{\"name\":\"Client\",\"contact\":{\"email\":\"test@examplhseuhfue.com\"}}";

                string json = "{\"name\":\"Client\",\"contact\":{\"email\":\"michael1234567@test.com\",\"first_name\":\"Michael1\",\"last_name\":\"De Gauquier1\"}}";

                streamWriter.Write(json);
            }

            var response = (HttpWebResponse)request.GetResponse();
            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
            }
        }

        public async System.Threading.Tasks.Task GetClient(int id)
        {
            var request = (HttpWebRequest)WebRequest.Create($"http://10.3.56.22/api/v1/clients/{id}"); //geeft enkel op id

            request.ContentType = "application/json";
            request.Method = "GET";
            request.Headers.Add("X-Ninja-Token", "a0tibzaccmgeset77nx8bgo0q7o9rwlk");

            var response = (HttpWebResponse)request.GetResponse();
            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                Console.WriteLine(result);
            }
        }

        //id moet in de json string en de url van de api (http:://..../clients/38)
        public async System.Threading.Tasks.Task UpdateClient(int id)
        {
            var request = (HttpWebRequest)WebRequest.Create($"http://10.3.56.22/api/v1/clients/{id}");

            request.ContentType = "application/json";
            request.Method = "PUT";
            request.Headers.Add("X-Ninja-Token", "a0tibzaccmgeset77nx8bgo0q7o9rwlk");

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                //string json = "{\"name\":\"Client\",\"contact\":{\"email\":\"test@examplhseuhfue.com\"}}";

                string json = "\"name\":\"Client\",\"contact\":{\"email\":\"michaeldg2@test.com\",\"first_name\":\"Michael12\",\"last_name\":\"De Gauquier12\"}}";

                streamWriter.Write(json);
            }

            var response = (HttpWebResponse)request.GetResponse();
            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
            }
        }

        public async System.Threading.Tasks.Task ArchiveClient(int id)
        {
            var request = (HttpWebRequest)WebRequest.Create($"http://10.3.56.22/api/v1/clients/{id}?action=archive");

            request.ContentType = "application/json";
            request.Method = "PUT";
            request.Headers.Add("X-Ninja-Token", "a0tibzaccmgeset77nx8bgo0q7o9rwlk");

            var response = (HttpWebResponse)request.GetResponse();
            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
            }
        }

        public async System.Threading.Tasks.Task DeleteClient(int id)
        {
            var request = (HttpWebRequest)WebRequest.Create($"http://10.3.56.22/api/v1/clients/{id}?action=delete");

            request.ContentType = "application/json";
            request.Method = "PUT";
            request.Headers.Add("X-Ninja-Token", "a0tibzaccmgeset77nx8bgo0q7o9rwlk");

            var response = (HttpWebResponse)request.GetResponse();
            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
            }
        }

        public async System.Threading.Tasks.Task RestoreClient(int id)
        {
            var request = (HttpWebRequest)WebRequest.Create($"http://10.3.56.22/api/v1/clients/{id}?action=restore");

            request.ContentType = "application/json";
            request.Method = "PUT";
            request.Headers.Add("X-Ninja-Token", "a0tibzaccmgeset77nx8bgo0q7o9rwlk");

            var response = (HttpWebResponse)request.GetResponse();
            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
            }
        }

        public static void Main()
        {
            Client l1 = new Client();
            //Task task1 = l1.CreateClient();
            Task task1 = l1.GetClient(38);
            //Task task1 = l1.UpdateClient();
            //Task task1 = l1.ArchiveClient(38);
            //Task task1 = l1.DeleteClient(38);
            //Task task1 = l1.RestoreClient(38);
        }
    }
}
