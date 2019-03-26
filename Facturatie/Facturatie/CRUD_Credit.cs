using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace brolTest
{
    class Credit
    {
        public async System.Threading.Tasks.Task CreateCredit(int id)
        {
            var request = (HttpWebRequest)WebRequest.Create("http://<url>/api/v1/credits");

            request.ContentType = "application/json";
            request.Method = "POST";
            request.Headers.Add("X-Ninja-Token", "<token>");

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                string json = "{\"amount\": \"10\", \"private_notes\": \"money money money\",\"public_notes\": \"just give me money\",\"client_id\": \"" + id + "\"}";

                streamWriter.Write(json);
            }

            var response = (HttpWebResponse)request.GetResponse();
            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
            }
        }

        public async System.Threading.Tasks.Task GetCredit(int id)
        {
            var request = (HttpWebRequest)WebRequest.Create($"http://<url>/api/v1/credits/{id}");

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

        public async System.Threading.Tasks.Task UpdateCredit(int id)
        {
            var request = (HttpWebRequest)WebRequest.Create($"http://<url>/api/v1/credits/{id}");

            request.ContentType = "application/json";
            request.Method = "PUT";
            request.Headers.Add("X-Ninja-Token", "<token>");

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                string json = "{\"amount\":\"15\",\"private_notes\":\"money³\",\"public_notes\":\"just give me money\",\"client_id\":\"2\"}";

                streamWriter.Write(json);
            }
        }
        public async System.Threading.Tasks.Task DeleteCredit(int id)
        {
            var request = (HttpWebRequest)WebRequest.Create($"http://<url>/api/v1/credits/{id}?action=delete");

            request.ContentType = "application/json";
            request.Method = "PUT";
            request.Headers.Add("X-Ninja-Token", "<token>");

            var response = (HttpWebResponse)request.GetResponse();
            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
            }
        }
        public async System.Threading.Tasks.Task ArchiveCredit(int id)
        {
            var request = (HttpWebRequest)WebRequest.Create($"http://<url>/api/v1/credits/{id}?action=archive");

            request.ContentType = "application/json";
            request.Method = "PUT";
            request.Headers.Add("X-Ninja-Token", "<token>");

            var response = (HttpWebResponse)request.GetResponse();
            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
            }
        }
        public async System.Threading.Tasks.Task RestoreCredit(int id)
        {
            var request = (HttpWebRequest)WebRequest.Create($"http://<url>/api/v1/credits/{id}?action=restore");

            request.ContentType = "application/json";
            request.Method = "PUT";
            request.Headers.Add("X-Ninja-Token", "<token>");

            var response = (HttpWebResponse)request.GetResponse();
            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
            }
        }

        //public static void Main()
        //{
        //    Credit I1 = new Credit();
        //    //Task task1 = I1.CreateCredit(38); //ok
        //    //Task task1 = I1.GetCredit(1); //ok
        //    Task task1 = I1.UpdateCredit(2);
        //    //Task task1 = I1.ArchiveCredit(1); //ok
        //    //Task task1 = I1.DeleteCredit(1); //ok
        //    //Task task1 = I1.RestoreCredit(2); //ok
        //}
    }
}