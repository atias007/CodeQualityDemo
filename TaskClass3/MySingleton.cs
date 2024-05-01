namespace TaskClass3
{
    internal class MySingleton
    {
        private MySingleton()
        { }

        private static MySingleton _instance = null!;

        private static readonly object _lock = new object();

        public static MySingleton GetInstance(string value)
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new MySingleton();
                        _instance.Value = value;
                    }
                }
            }

            return _instance;
        }

        public string? Value { get; set; }
    }
}