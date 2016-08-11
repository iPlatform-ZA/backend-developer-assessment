using System.Configuration;
using System.Net;

namespace MusicBrainsAPI
{
    internal class HttpCallProcessor
    {
        private static string _userAgent = "MusicBrainzWebApi";

        public static string Request(string url)
        {
            string response = null;
            bool retryRequest = false;
            int retriesToPerform = GetNumberOfRetriesToPerform();
            int requestCount = 0;
            int retryWaitPeriod = 1000; // in milliseconds the time to wait before trying the request again.

            do
            {
                try
                {
                    requestCount++;
                    retryRequest = requestCount < 1 + retriesToPerform;

                    response = GetResponseAsString(url);
                }
                catch (System.Net.WebException webEx)
                {
                    var webResponse = (HttpWebResponse)webEx.Response;
                    int statusCode = (int)webResponse.StatusCode;

                    if (statusCode.ToString() == "503" && retryRequest)
                    {
                        System.Threading.Thread.Sleep(retryWaitPeriod);
                        retryWaitPeriod += 1000; // add another second to the wait period
                    }
                    else
                    {
                        throw;
                    }
                }
            } while (response == null && retryRequest);


            return response;
        }

        private static string GetResponseAsString(string url)
        {
            using (System.Net.WebClient client = new System.Net.WebClient())
            {
                client.Headers.Add("User-Agent", _userAgent);

                return client.DownloadString(url);
            }
        }

        private static int GetNumberOfRetriesToPerform()
        {
            int retriesToPerform;

            var retryConfigValue = ConfigurationManager.AppSettings["MusicBrainzRetryAttempts"];

            if (!int.TryParse(retryConfigValue, out retriesToPerform))
            {
                retriesToPerform = 0;
            }

            return retriesToPerform;
        }
    }
}
