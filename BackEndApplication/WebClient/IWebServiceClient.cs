using System;
using System.Threading.Tasks;
namespace BackEndApplication.WebClient
{
    public interface IWebServiceClient
    {
        Task<string> GetRequest(string resourceURL);
    }
}
