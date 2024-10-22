using System;

namespace TAF.Core.Helpers
{
    public static class ObjectFactory
    {
        public static T Get<T>(params object[] args) => (T)Activator.CreateInstance(typeof(T), args);

        public static T Get<T>(Type type, params object[] args) => (T)Activator.CreateInstance(type, args);
    }
}
