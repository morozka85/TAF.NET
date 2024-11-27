using Core.Helpers;

namespace PageObjects
{
    public static class Pages
    {
        public static LoginPage LoginPage => ObjectFactory.Get<LoginPage>();
        public static PlayListsPage PlayListPage => ObjectFactory.Get<PlayListsPage>();
        public static HomePage HomePage => ObjectFactory.Get<HomePage>();
    }
}
