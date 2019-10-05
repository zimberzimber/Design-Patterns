namespace Design_Patterns.Creational
{
    sealed class Singleton
    {
        private static object _locker;
        private static Singleton _instance;
        public static Singleton Instance
        {
            get
            {
                lock (_locker)
                    if (_instance == null)
                        _instance = new Singleton();
                return _instance;
            }
        }

        private Singleton() { }
    }
}
