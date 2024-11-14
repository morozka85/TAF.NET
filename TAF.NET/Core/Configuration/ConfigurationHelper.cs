using Microsoft.Extensions.Configuration;
using TAF.Core.Helpers;

namespace TAF.Core.Configuration
{
    public static class ConfigurationHelper
    {
        public static IConfigurationRoot GetConfiguration()
        {
            return new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddJsonFile("appsettings.local.json", true)
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