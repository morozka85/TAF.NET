using FluentAssertions;
using PageObjects;
using SeleniumExtras.WaitHelpers;

namespace TestsUI
{
    public class PlaylistTest : BaseUITestWithLogin
    {
        [Test]
        public void CreatePlaylist()
        {
            int playListCollectionCount = Pages.PlayListPage.PlaylistCollection.CountElements();
            Pages.PlayListPage.CreatePlaylist();
            Wait.Until(_ => Pages.PlayListPage.PlaylistCollection.CountElements() == playListCollectionCount + 1);
            string playListFinalNumber = Pages.PlayListPage.PlaylistCollection.CountElements().ToString();
            Pages.PlayListPage.GetPlayListName().Should().Be($"My Playlist #{playListFinalNumber}");

        }

        [Test]
        [TestCase("New Name")]
        public void EditNamePlaylistTest(string newName)
        {
            int playListCollectionCount = Pages.PlayListPage.PlaylistCollection.CountElements();
            Pages.PlayListPage.CreatePlaylist();
            Wait.Until(_ => Pages.PlayListPage.PlaylistCollection.CountElements() == playListCollectionCount + 1);
            Pages.PlayListPage.EditPlayList(newName);
            Wait.Until(ExpectedConditions.TextToBePresentInElementLocated(
                Pages.PlayListPage.NamePlaylist.Locator, newName));
            Pages.PlayListPage.GetPlayListName().Should().Be(newName);
        }

        [Test]
        public void DeletePlaylistTest()
        {
            int playListCollectionCount = Pages.PlayListPage.PlaylistCollection.CountElements();
            Pages.PlayListPage.CreatePlaylist();
            Wait.Until(_ => Pages.PlayListPage.PlaylistCollection.CountElements() == playListCollectionCount + 1);
            Pages.PlayListPage.DeletePlayList();
            Wait.Until(_ => Pages.PlayListPage.PlaylistCollection.CountElements() == playListCollectionCount);
            Pages.PlayListPage.PlaylistCollection.CountElements().Should().Be(playListCollectionCount);
        }
    }
}
