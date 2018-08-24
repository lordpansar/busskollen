using System.Net.Http;

namespace BussKollen.Services
{
    public class HttpClientHelper
    {
        static HttpClientHelper _instance;
        static HttpClient client;

        public HttpClientHelper()
        {
            client = new HttpClient();
        }

        public static HttpClient Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new HttpClientHelper();
                }
                return client;
            }
        }
    }
}
