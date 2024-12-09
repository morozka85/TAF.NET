using CoreAPI;
using ModelsAPI;
using RestSharp;
using Serilog;

namespace ServicesAPI
{
    public class UserService
    {
        private readonly ApiClient _apiClient;

        public UserService(string baseUrlApi, string token)
        {
            _apiClient = new ApiClient(baseUrlApi, token);
        }

        public string GetUserId(UserdModel user)
        {
            Log.Logger.Information($"Try to get the userId");
            var response = _apiClient.SendRequest<UserdModel>("me", Method.Get);
            if (!response.IsSuccessful)
                throw new InvalidOperationException($"Failed to get the user. Status code: {response.StatusCode}. Response: {response.Content}");
            Log.Logger.Information($"User ID: {response.Data.Id}");
            return response.Data.Id;
        }
    }
}
