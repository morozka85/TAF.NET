using FluentAssertions;
using Serilog;
using BusinessAPI.Models;
using System.Net;

namespace TestsTAF.NET.Test.API
{
    public class DashboardApiTests : BaseApiTest
    {
        private List<int> _dashboardIds = new List<int>();
        private DashboardModel _dashboardModelExpected;
        private DashboardModel _dashboardModelActual;

        [SetUp]
        public void CreateDashboardPrecondition()
        {
            var name = "Name" + Guid.NewGuid(); // some randow value;
            var description = "Desciprition"; // some randow value;
            _dashboardModelExpected = new DashboardModel { Name = name, Description = description };

            _dashboardModelActual = DashboardService.CreateDashbord(_dashboardModelExpected);
            _dashboardIds.Add(_dashboardModelActual.Id);
        }

        [Test]
        public void CreateDashboardTest()
        {
            // Arrange

            //// Act
            //var reatedDashboardId = DashboardService.CreateDashbordAdnGetId(newDashboard);
            //_dashboardIds.Add(reatedDashboardId);
            //var getDashboard = DashboardService.GetDashboard(reatedDashboardId);
            //var deleteResult = DashboardService.IsDashboardDeleted(_dashboardModel.Id);

            // Assert
            _dashboardModelActual.Name.Should().Be(_dashboardModelExpected.Name, "The dashboard name should match");
            _dashboardModelActual.Description.Should().Be(_dashboardModelExpected.Description, "The dashboard description should match");
            //deleteResult.Should().BeTrue("The deletion of the dashboard should succeed");
        }

        [Test]
        public void CheckValidationForDuplicatedDashboardTest()
        {
            //// Arrange
            //var duplicateDashboard = new DashboardModel { Name = name, Description = description };

            // Act 
            //var firstCreateResult = DashboardService.CreateDashbord(_);
            var secondCreateResult = DashboardService.TryCreateDashbord(_dashboardModelExpected);

            // Assert 
            secondCreateResult.StatusCode.Should().Be(HttpStatusCode.Conflict, "The dashboard already exists");
            secondCreateResult.Content.Should().Contain("already exists", "A duplicate should not be allowed");

            Log.Information($"Attempt to create duplicate dashboard resulted in expected error: {secondCreateResult.Content}");

            //DashboardService.IsDashboardDeleted(firstCreateResult.Data.Id).Should().BeTrue("The deletion of the dashboard should succeed");
        }

        [OneTimeTearDown]
        public void CleanupDashboards()
        {
            //Cleanup;
        }

    }
}
