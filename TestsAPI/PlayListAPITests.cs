using ModelsAPI;
using ServicesAPI;
using FluentAssertions;
using System.Net;

namespace TestsAPI
{
    public class PlayListApiTestss : BaseApiTest
    {
        private string UserId;
        private PlaylistModel _playlistModelExpected;
        private PlaylistModel _playlistModelActual;
        private UserdModel _userdModel;

        [SetUp]
        public void PlayListPrecondition()
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
            _playlistModelActual.Name.Should().Be(_playlistModelExpected.Name);
            _playlistModelActual.Description.Should().Be(_playlistModelExpected.Description);
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

        [Test]
        public void GetPlayListTest()
        {  
            var gotenPlaylist = PlayListService.GetPlaylistById(_playlistModelActual.Id);

            gotenPlaylist.Should().NotBeNull();
            _playlistModelActual.Name.Should().Be(_playlistModelActual.Name);
            _playlistModelActual.Description.Should().Be(_playlistModelActual.Description);
        }
    }
}
