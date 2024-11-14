using BusinessAPI.Models;
using CoreAPI;
using RestSharp;
using Serilog;

namespace BusinessAPI.Services
{
    public class DashboardService
    {
        private readonly ApiClient _apiClient;

        public DashboardService(string baseUrlApi, string token)
        {
            _apiClient = new ApiClient(baseUrlApi, token);
        }

        public int CreateDashbordAdnGetId(DashboardModel dashboard)
        {
            Log.Logger.Information($"Try to create the Dashboard");
            var response = _apiClient.SendRequest<DashboardModel>("dashboard", Method.Post, dashboard);
            if (!response.IsSuccessful && response.Data?.Id != 0)
                throw new InvalidOperationException($"Failed to create the Dashboard. Status code: {response.StatusCode}. Response: {response.Content}");
            Log.Logger.Information($"Dashboard created successfully with ID: {response.Data.Id}");
            return response.Data.Id;
        }

        public DashboardModel CreateDashbord(DashboardModel dashboard)
        {
            Log.Logger.Information("Try to create the Dashboard");
            Log.Logger.Information($"Dashboard model name is {dashboard.Name}, description is {dashboard.Id}");

            var response = _apiClient.SendRequest<DashboardModel>("dashboard", Method.Post, dashboard);

            if (!response.IsSuccessful && response.Data?.Id != 0)
            {
                throw new InvalidOperationException($"Failed to create the Dashboard. Status code: {response.StatusCode}. Response: {response.Content}");
            }

            Log.Logger.Information($"Dashboard created successfully with ID: {response.Data.Id}");

            return response.Data;
        }

        public RestResponse<DashboardModel> TryCreateDashbord(DashboardModel dashboard)
        {
            Log.Logger.Information($"Try to create the Dashboard");
            var response = _apiClient.SendRequest<DashboardModel>("dashboard", Method.Post, dashboard);
            return response;
        }

        public RestResponse<DashboardModel> GetDashboard(int dashboardId)
        {
            Log.Logger.Information($"Try to get data of the Dashboard");
            var response = _apiClient.SendRequest<DashboardModel>($"dashboard/{dashboardId}", Method.Get);
            if (!response.IsSuccessful && response.Data != null)
                throw new InvalidOperationException($"Error getting dashboard: {response.Content}");
            return response;
        }

        public bool IsDashboardDeleted(int dashboardId)
        {
            Log.Logger.Information($"Try to delete the Dashboard");
            var response = _apiClient.SendRequest<DashboardModel>($"dashboard/{dashboardId}", Method.Delete);
            return response.IsSuccessful;
        }
    }
}
