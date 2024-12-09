using CoreUI.UIElements;
using OpenQA.Selenium;


namespace PageObjects
{
    public class PlayListsPage
    {
        public IButton CreationButton => new Button(By.XPath("//button[@aria-label='Create playlist or folder']"));
        public IButton PlaylistCreationButton => new Button(By.XPath("//div[@data-testid='context-menu']//span[contains(text(), 'Create a new playlist')]/.."));
        public IButton PlaylistFolderCreationButton => new Button(By.XPath("//div[@data-testid='context-menu']//span[contains(text(), 'Create a playlist folder')]/.."));
        public IButton FirstPlayListButton => new Button(By.XPath("//ul[@aria-label='Your Library']//li[@aria-posinset='1']//button[@data-testid='play-button']"));
        public IInputField SearchInput => new InputField(By.XPath("//input[@data-testid='search-input']"));
        public IButton SearchButton => new Button(By.XPath("//button[@aria-label='Search']"));
        public IButton PlayListMoreButton => new Button(By.XPath("//div[@data-testid='action-bar']//button[@data-testid='more-button']"));
        public IButton EditDetaisPlaylistButton => new Button(By.XPath("//span[text()='Edit details']/.."));
        public IButton DeletePlaylistButton => new Button(By.XPath("//span[text()='Delete']/.."));
        public IButton DeleteConfirmPlaylistButton => new Button(By.XPath("//div[contains(@role, 'dialog')]//button[contains(@aria-label, 'Delete')]"));
        public IInputField NamePlayListInput => new InputField(By.XPath("//input[@data-testid='playlist-edit-details-name-input']"));
        public IButton SaveEditedPlayListButton => new Button(By.XPath("//button[@data-testid='playlist-edit-details-save-button']"));
        public ITextField NamePlaylist => new TextField(By.XPath("//span[@data-testid='entityTitle']//h1"));
        public WebElementCollection PlaylistCollection => 
            new WebElementCollection(By.XPath("//ul[@aria-label='Your Library']//div[@role='button']"));


        public void SearchMusic(string word)
        {
            SearchInput.InputText(word);
            SearchButton.Click();
        }

        public void CreatePlaylist()
        {
            CreationButton.Click();
            PlaylistCreationButton.Click();
        }

        public string GetPlayListName()
        {
            var name = NamePlaylist.Text;
            return name;
        }

        public void EditPlayList(string newName)
        {
            FirstPlayListButton.Click();
            PlayListMoreButton.Click();
            EditDetaisPlaylistButton.Click();
            NamePlayListInput.InputText(newName);
            SaveEditedPlayListButton.Click();
        }

        public void DeletePlayList()
        {
            FirstPlayListButton.Click();
            PlayListMoreButton.Click();
            DeletePlaylistButton.Click();
            DeleteConfirmPlaylistButton.Click();
        }
    }
}
