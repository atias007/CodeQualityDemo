using DependencyInjectionDemo.Interfaces;
using Microsoft.Extensions.Logging;
using System;

namespace DependencyInjectionDemo.Loggers
{
    internal class ElasticLogger : ILogger
    {
        public ElasticLogger(ICacheUtil cache, IQueueUtil queue)
        {

        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            throw new NotImplementedException();
        }

        #region ILogger Members

        public IDisposable BeginScope<TState>(TState state)
        {
            throw new NotImplementedException();
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
