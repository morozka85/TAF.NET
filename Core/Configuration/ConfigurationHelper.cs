using Microsoft.Extensions.Configuration;
using Core.Helpers;

namespace Core.Configuration
{
    public static class ConfigurationHelper
    {
        public static IConfigurationRoot GetConfiguration()
        {
            return new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddJsonFile("appsettings.local.json", optional: true, reloadOnChange: true)
                .Build();
        }

        public static T GetApplicationConfiguration<T>()
        {
            var configuration = ObjectFactory.Get<T>();
            var iConfig = GetConfiguration();
            iConfig.GetSection(typeof(T).Name)
                .Bind(configuration);
            return configuration;
        }
    }
}