namespace CoreUI.UIElements
{
    public interface IButton
    {
        void Click();
        bool IsDisplayed();
        string GetAttributeValue(string attribute);
    }
}
