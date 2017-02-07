using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace CodeAndComedy.Website.Utils
{
    public class CognitiveServicesRequest
    {
        public async Task<string> MakeRequest(string url, string subscriptionKey, object requestObject)
        {
            HttpResponseMessage response;
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", subscriptionKey);

            var jss = new JavaScriptSerializer();
            var byteData = Encoding.UTF8.GetBytes(jss.Serialize(requestObject));

            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                response = await client.PostAsync(url, content);
            }
            return await response.Content.ReadAsStringAsync();
        }


        public object CreateImageRequestObject(string imageUrl)
        {
            var requestObject = new
            {
                Url = imageUrl
            };

            return requestObject;
        }

        public object CreateTextRequestObject(string textString)
        {
            var textRequest = new
            {
                documents = new List<object>
                {
                    new
                    {
                        id = "0",
                        text = textString
                    }
                }.ToArray()
            };

            return textRequest;
        }
/*

        public async Task<string> MakeRequest(string url, string subscriptionKey, string imageUrl)
        {
            HttpResponseMessage response;
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", subscriptionKey);
            


            JavaScriptSerializer jss = new JavaScriptSerializer();

            byte[] byteData = Encoding.UTF8.GetBytes(jss.Serialize(requestObject));

            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                response = await client.PostAsync(url, content);
            }
            return await response.Content.ReadAsStringAsync();
        }




        public async Task<string> MakeRequestTxt(string url, string subscriptionKey, string textString)
        {
            HttpResponseMessage response;
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", subscriptionKey);





            JavaScriptSerializer jss = new JavaScriptSerializer();

            byte[] byteData = Encoding.UTF8.GetBytes(jss.Serialize(textRequest));

            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                response = await client.PostAsync(url, content);
            }
            return await response.Content.ReadAsStringAsync();
        }
*/
    }
}

