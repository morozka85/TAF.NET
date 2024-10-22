using TAF.Core.UI.UIElements;

namespace TAF.PageObjects
{
    public interface ILoginPage
    {
        public IInputField Login { get; }
        public IInputField Password { get; }
        public IButton LoginButton { get; }
        public ITextField TextErrorLogin { get; }
        public ITextField TextErrorPassword { get; }
    }

}
