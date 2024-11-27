using ModelsAPI;
using ServicesAPI;
using FluentAssertions;
using System.Net;

namespace TestsAPI
{
    public class PlayListAPITestss : BaseApiTest
    {
        private string UserId;
        private PlaylistModel _playlistModelExpected;
        private PlaylistModel _playlistModelActual;
        private UserdModel _userdModel;

        [SetUp]
        public void CreatePlayListPrecondition()
        {
            var name = "Name" + Guid.NewGuid();
            var description = "Desciprition";
            _playlistModelExpected = new PlaylistModel { Name = name, Description = description, Public = false };

            _userdModel = new UserdModel();
            UserId = UserService.GetUserId(_userdModel);
            _playlistModelActual = PlayListService.CreatePlaylist(_playlistModelExpected, UserId);
        }

        [Test]
        public void CreatePlayListTest()
        {
            _playlistModelActual.Name.Should().Be(_playlistModelExpected.Name, "The playlist name should match");
            _playlistModelActual.Description.Should().Be(_playlistModelExpected.Description, "The dashboard description should match");
        }

        [Test]
        public void UpdatePlayListTest()
        {
            string updatedName = _playlistModelActual.Name + "_Updated";
            string updatedDescription = _playlistModelActual.Description + "_Updated";

            _playlistModelActual.Name = updatedName;
            _playlistModelActual.Description = updatedDescription;

            var updatedPlaylistResponse = PlayListService.UpdatePlaylist(_playlistModelActual, _playlistModelActual.Id);

            updatedPlaylistResponse.Should().NotBeNull();
            updatedPlaylistResponse.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
