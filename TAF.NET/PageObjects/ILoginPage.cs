using TAF.Core.UI.UIElements;

namespace TAF.PageObjects
{
    public interface ILoginPage
    {
        public InputField Login { get; }
        public InputField Password { get; }
        public Button LoginButton { get; }
        public TextField TextErrorLogin { get; }
        public TextField TextErrorPassword { get; }
    }

}
