namespace TAF.Core.UI.UIElements
{
    public interface IInputField : IBaseUIElement
    {
        string Text { get; }
        void InputText(string text);
    }
}
