using OpenQA.Selenium;

namespace CoreUI.UIElements
{
    public class WebElementCollection : BaseUIElement
    {
        public WebElementCollection(By locator) : base(locator) { }

        public int CountElements()
        {
            if (WebElements == null)
            {
                return 0;
            }
            int count = WebElements.Count;
            return count;
        }
    }
}
