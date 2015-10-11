using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Assessment.BusinessLogic.Common
{
    //Super duper generic HTTP API request helper. Deserializes JSON from remote APIs to DTOs in this project as needed.
    internal static class HttpHelper<T>
    {
        internal static async Task<T> Request(string uri, string request)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(uri);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.GetAsync(request);
                    response.EnsureSuccessStatusCode();

                    if (response.IsSuccessStatusCode)
                    {
                        return await response.Content.ReadAsAsync<T>();
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                return default(T);
            }

            return default(T);
        }
    }
}
