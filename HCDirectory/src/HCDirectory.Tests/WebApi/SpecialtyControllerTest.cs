using HCDirectory.Repository.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Xunit;

namespace HCDirectory.Tests.WebApi
{
    public class SpecialtyControllerTest
    {
        private const string URL_SERVICE = "http://localhost:53432";
        bool isSuccess;        

        [Fact]
        public async void Get_All_correct()
        {
            IEnumerable<Specialty> Model = null;            
            bool isSuccess = true;            

            string sService = "api/Specialty";

            Task<HttpResponseMessage> response = GetResponseApiRest(URL_SERVICE, sService, null, eTipeVerbose.GET);

            isSuccess = response.Result.IsSuccessStatusCode;
            if (isSuccess)
            {
                string messageJson;
                using (Stream responseStream = await response.Result.Content.ReadAsStreamAsync())
                    messageJson = new StreamReader(responseStream).ReadToEnd();

                Model = (IEnumerable<Specialty>)JsonConvert.DeserializeObject(messageJson, typeof(IEnumerable<Specialty>));
            }

            Assert.True(isSuccess);
            Assert.True(Model != null);
        }

        [Fact]
        public async void Get_Id_correct()
        {
            Specialty Model = null;
            bool isSuccess = true;           
            string sId = "11";
            
            string sService = string.Format("api/Specialty/{0}", sId);

            Task<HttpResponseMessage> response = GetResponseApiRest(URL_SERVICE, sService, null, eTipeVerbose.GET);
            isSuccess = response.Result.IsSuccessStatusCode;

            if (isSuccess)
            {
                string messageJson;
                using (Stream responseStream = await response.Result.Content.ReadAsStreamAsync())
                    messageJson = new StreamReader(responseStream).ReadToEnd();

                Model = (Specialty)JsonConvert.DeserializeObject(messageJson, typeof(Specialty));
            }

            Assert.True(isSuccess);
            Assert.True(Model != null);
        }

        [Fact]
        public void Post_Insert_correct()
        {
            bool isSuccess = true;
            Specialty model = new Specialty { SpecialtyName = "Test Insert Correct" };
            string sService = "api/Specialty";

            Task<HttpResponseMessage> response = GetResponseApiRest(URL_SERVICE, sService, model, eTipeVerbose.POST);
            isSuccess = response.Result.IsSuccessStatusCode;

            Assert.True(isSuccess);
        }

        [Fact]
        public void Put_Update_correct()
        {
            bool isSuccess = true;
            Specialty model = new Specialty { SpecialtyId = 12, SpecialtyName = "Test Put update correct" };          
            string sService = "api/Specialty";

            Task<HttpResponseMessage> response = GetResponseApiRest(URL_SERVICE, sService, model, eTipeVerbose.PUT);
            isSuccess = response.Result.IsSuccessStatusCode;

            Assert.True(isSuccess);
        }

        [Fact]
        public void Delete_correct()
        {
            bool isSuccess = true;
            string sId = "10";
            // Service      
            string sService = string.Format("api/Specialty/{0}", sId);

            Task<HttpResponseMessage> response = GetResponseApiRest(URL_SERVICE, sService, null, eTipeVerbose.DELETE);
            isSuccess = response.Result.IsSuccessStatusCode;          

            Assert.True(isSuccess);
        }

        enum eTipeVerbose
        {
            GET,
            POST,
            PUT,
            DELETE
        }

        private async Task<HttpResponseMessage> GetResponseApiRest(string url, string service, object obj, eTipeVerbose verbose)
        {
            HttpResponseMessage response = null;

            using (var client = new HttpClient())
            {
                // Url service.
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                ByteArrayContent byteContent =null;
                if (obj != null)
                {
                    var myContent = JsonConvert.SerializeObject(obj);
                    var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
                     byteContent = new ByteArrayContent(buffer);
                    byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                }

                switch (verbose)
                {
                    case eTipeVerbose.GET:
                         response = await client.GetAsync(service);
                        break;
                    case eTipeVerbose.POST:
                       response = client.PostAsync(service, byteContent).Result;
                        break;
                    case eTipeVerbose.PUT:
                         response = client.PutAsync(service, byteContent).Result;
                        break;
                    case eTipeVerbose.DELETE:
                         response = client.DeleteAsync(service).Result;
                        break;
                    default:
                        break;
                }              
            }

            return response;
        }
    }
}
