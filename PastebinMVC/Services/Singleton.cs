namespace PastebinMVC.Services
{
    internal class Singleton<T> where T : class, new()
    {
        private static T instance = null;
        private static object initLock = new object();

        protected Singleton()
        {
        }

        internal static T Instance
        {
            get
            {
                lock (initLock)
                {
                    if (instance == null)
                    {
                        instance = new T();
                    }
                }

                return instance;
            }
        }
    }
}