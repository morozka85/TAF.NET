using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;


namespace CoreAPI
    {
    public class ApiClient
    {
        private readonly RestClient _client;

        public ApiClient(string baseUrlApi, string token)
        {
            var options = new RestClientOptions(baseUrlApi);
            _client = new RestClient(options, configureSerialization: s => s.UseNewtonsoftJson());
            _client.AddDefaultHeader("Authorization", $"Bearer {token}");
        }

        public RestResponse<T> SendRequest<T>(string resource, Method method, object body = null)
        {
            var request = new RestRequest(resource, method);
            request.AddHeader("Content-Type", "application/json");

            if (body != null)
                request.AddJsonBody(body);

            var response = _client.Execute<T>(request);
            return response;
        }
    }
}
