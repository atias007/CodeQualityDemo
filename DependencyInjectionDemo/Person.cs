using Microsoft.Extensions.Logging;
using DependencyInjectionDemo.Loggers;
using System;

namespace DependencyInjectionDemo
{
    internal class Person1
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthOfDate { get; set; }

        public void Register()
        {
            try
            {
                // Do Something
            }
            catch (Exception ex)
            {
                var logger = new Logger();
                logger.Log<Person1>(LogLevel.Error, new EventId(-1),null, ex, null);
                throw;
            }
        }
    }

    internal class Person2
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthOfDate { get; set; }

        public void Register()
        {
            try
            {
                // Do Something
            }
            catch (Exception ex)
            {
                var logger = new ElasticLogger(null, null);
                logger.Log<Person1>(LogLevel.Error, new EventId(-1), null, ex, null);
                throw;
            }
        }
    }

    internal class Person3
    {
        private readonly Logger _logger;

        public Person3(Logger logger)
        {
            _logger = logger;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthOfDate { get; set; }

        public void Register()
        {
            try
            {
                // Do Something
            }
            catch (Exception ex)
            {
                _logger.Log<Person1>(LogLevel.Error, new EventId(-1), null, ex, null);
                throw;
            }
        }
    }
    
    internal class Person4
    {
        private readonly ILogger _logger;

        public Person4(ILogger logger)
        {
            _logger = logger;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthOfDate { get; set; }

        public void Register()
        {
            try
            {
                // Do Something
                _logger.LogInformation("Start do something");
                if(string.IsNullOrEmpty(FirstName))
                {
                    throw new ApplicationException("FirstName is null or empty");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Fail to do something");
                throw;
            }
        }
    }
}
