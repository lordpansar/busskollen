using System.Net.Http;

namespace BussKollen.Services
{
    public class HttpClientHelper
    {
        static HttpClientHelper _instance;
        HttpClient client;

        public HttpClientHelper()
        {
            client = new HttpClient();
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
        public HttpClient Client => client;
    }
}
