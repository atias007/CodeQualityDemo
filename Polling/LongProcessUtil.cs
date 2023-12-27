namespace Polling
{
    public static class LongProcessUtil
    {
        private static Dictionary<Guid, Task> _allTasks = new Dictionary<Guid, Task>();

        public static Guid StartLongProcess(int seconds)
        {
            var id = Guid.NewGuid();
            var task = Task.Run(async () =>
            {
                await Task.Delay(seconds * 1000);
                _allTasks.Remove(id);
            });

            _allTasks.Add(id, task);
            return id;
        }

        public static bool IsLongProcessFinished(Guid id)
        {
            if (_allTasks.ContainsKey(id))
            {
                return false;
            }

            return true;
        }

        public static bool IsAllLongProcessFinished()
        {
            return !_allTasks.Any();
        }

        public static int Count => _allTasks.Count;
    }
}