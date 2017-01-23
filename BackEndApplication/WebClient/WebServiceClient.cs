using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace BackEndApplication.WebClient
{
    public class WebServiceClient : IWebServiceClient
    {
        readonly IHeaderProvider provider;

        public WebServiceClient(IHeaderProvider provider)
        {
            this.provider = provider;
        }

        public async Task<string> GetRequest(String resourceURL)
        {

            using (HttpClient httpClient = new HttpClient())
            {

                AddHeaders(httpClient);

                Task<HttpResponseMessage> responseTask = httpClient.GetAsync(new Uri(resourceURL));

                responseTask.Wait();

                HttpResponseMessage response = responseTask.Result;

                if (response.IsSuccessStatusCode)
                {
                    var responseStream = response.Content.ReadAsStringAsync();

                    responseStream.Wait();

                    return responseStream.Result;
                }

                return "";

            }
        }

        private void AddHeaders(HttpClient httpClient)
        {
            foreach (KeyValuePair<string, string> header in provider.GetHeaders())
            {
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation(header.Key, header.Value);
            }
        }
    }
}