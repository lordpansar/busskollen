using System.Net.Http;

namespace BussKollen.Services
{
    public class HttpClientHelper
    {
        static HttpClientHelper _instance;

        public HttpClientHelper()
        {
            Client = new HttpClient();
        }

        public static HttpClientHelper Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new HttpClientHelper();
                }
                return _instance;
            }
        }
        public HttpClient Client { get; }
    }
}
