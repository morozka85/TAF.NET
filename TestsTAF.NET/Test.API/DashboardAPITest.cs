using FluentAssertions;
using Serilog;
using BusinessAPI.Models;
using System.Net;

namespace TestsTAF.NET.Test.API
{
    public class DashboardApiTests : BaseApiTest
    {
        [TestCase("API Test DashboardModel", "A test dashboard created via API.")]
        [TestCase("%%%===***", "Another example dashboard.")]
        public void CreateDashboardTest(string name, string description)
        {
            // Arrange
            var newDashboard = new DashboardModel { Name = name, Description = description };
            Log.Information($"Attempting to create a dashboard with Name: {name} and Description: {description}");

            // Act
            var reatedDashboardId = DashboardService.CreateDashbordAdnGetId(newDashboard);
            var getDashboard = DashboardService.GetDashboard(reatedDashboardId);
            var deleteResult = DashboardService.IsDashboardDeleted(reatedDashboardId);

            // Assert
            getDashboard.Data.Name.Should().Be(name, "The dashboard name should match");
            getDashboard.Data.Description.Should().Be(description, "The dashboard description should match");
            deleteResult.Should().BeTrue("The deletion of the dashboard should succeed");
        }

        [TestCase("API Test Duplicate Dashboard", "A test dashboard created via API.")]
        public void CheckValidationForDuplicatedDashboardTest(string name, string description)
        {
            // Arrange
            var duplicateDashboard = new DashboardModel { Name = name, Description = description };

            // Act 
            var firstCreateResult = DashboardService.TryCreateDashbord(duplicateDashboard);
            var secondCreateResult = DashboardService.TryCreateDashbord(duplicateDashboard);

            // Assert 
            secondCreateResult.StatusCode.Should().Be(HttpStatusCode.Conflict, "The dashboard already exists");
            secondCreateResult.Content.Should().Contain("already exists", "A duplicate should not be allowed");

            Log.Information($"First dashboard creation was successful with ID: {firstCreateResult.Data.Id}");
            Log.Information($"Attempt to create duplicate dashboard resulted in expected error: {secondCreateResult.Content}");

            DashboardService.IsDashboardDeleted(firstCreateResult.Data.Id).Should().BeTrue("The deletion of the dashboard should succeed");
        }
    }
}
