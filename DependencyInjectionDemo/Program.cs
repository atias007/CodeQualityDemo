using DependencyInjectionDemo.Interfaces;
using DependencyInjectionDemo.Loggers;
using DependencyInjectionDemo.Utils;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace DependencyInjectionDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Demo1();

            #region Demo2
            
            var provider = InitializeDependencyInjection();
            Demo2(provider); 
            
            #endregion
        }

        public static void Demo1()
        {
            #region Person1

            var person1 = new Person1();
            person1.Register();

            #endregion

            #region Person2

            var person2 = new Person2();
            person2.Register();

            #endregion

            #region Person3

            var logger = new Logger();
            var person3_1 = new Person3(logger);
            person3_1.Register();

            var person3_2 = new Person3(logger);
            person3_2.Register();

            #endregion

            #region Person4

            var cacheUtil = new CacheUtil();
            var queueUtil = new QueueUtil();
            #region Redis
            var cahceUtil = new RedisCacheUtil();
            #endregion
            var logger2 = new ElasticLogger(cacheUtil, queueUtil);
            #region DifferentLogger
            // var logger2 = new Logger(); 
            #endregion

            var person4_1 = new Person4(logger2);
            person4_1.Register();

            #endregion
        }

        static void Demo2(IServiceProvider provider)
        {
            var person4 = provider.GetService<Person4>();
            person4.Register();
        }

        static IServiceProvider InitializeDependencyInjection()
        {
            IServiceCollection services = new ServiceCollection();
            RegisterServices(services);
            var result = services.BuildServiceProvider();
            return result;
        }

        static void RegisterServices(IServiceCollection services)
        {
            services.AddTransient<ICacheUtil, RedisCacheUtil>();
            services.AddTransient<IQueueUtil, QueueUtil>();
            services.AddSingleton<ILogger, ElasticLogger>();
        }
    }
}
