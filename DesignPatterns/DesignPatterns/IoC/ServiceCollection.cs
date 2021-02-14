using System;
using System.Collections.Generic;
using System.Linq;

namespace DesignPatterns.IoC
{
    public class ServiceCollection : IServiceCollection
    {
        private readonly List<SomeSingleton> _singletonList = new List<SomeSingleton>();
        private readonly List<SomeTransient> _transientList = new List<SomeTransient>();

        public IServiceCollection AddTransient<T>()
        {
            var transient = new SomeTransient();
            transient.SetInstance(typeof(T));

            CheckIfTransientAlreadyExists<T>();

            _transientList.Add(transient);
            return this;
        }

        public IServiceCollection AddTransient<T>(Func<T> factory)
        {
            var transient = new SomeTransient();
            transient.SetInstance(factory().GetType());

            CheckIfTransientAlreadyExists<T>();

            _transientList.Add(transient);
            return this;
        }

        public IServiceCollection AddTransient<T>(Func<IServiceProvider, T> factory)
        {
            var transient = new SomeTransient();
            transient.SetInstance(factory(new ServiceProvider(
                _singletonList,
                _transientList)).GetType());

            CheckIfTransientAlreadyExists<T>();

            _transientList.Add(transient);
            return this;
        }

        public IServiceCollection AddSingleton<T>()
        {
            //var singleton = new SomeSingleton();
            //singleton.SetInstance(Activator.CreateInstance<T>());

            CheckIfSingletonAlreadyExists<T>();

            _singletonList.Add(new SomeSingleton(Activator.CreateInstance<T>()));
            return this;
        }

        public IServiceCollection AddSingleton<T>(T service)
        {
            var singleton = new SomeSingleton(service);

            CheckIfSingletonAlreadyExists<T>();

            _singletonList.Add(singleton);
            return this;
        }

        public IServiceCollection AddSingleton<T>(Func<T> factory)
        {
            var singleton = new SomeSingleton(factory());

            CheckIfSingletonAlreadyExists<T>();

            _singletonList.Add(singleton);
            return this;
        }

        public IServiceCollection AddSingleton<T>(Func<IServiceProvider, T> factory)
        {
            var singleton = new SomeSingleton(factory(new ServiceProvider(
                _singletonList,
                _transientList)));

            CheckIfSingletonAlreadyExists<T>();

            _singletonList.Add(singleton);
            return this;
        }

        public IServiceProvider BuildServiceProvider()
        {
            return new ServiceProvider(_singletonList, _transientList);
        }

        private void CheckIfSingletonAlreadyExists<T>()
        {
            if (_singletonList.Where(s => s.GetInstance() is T).ToList().Count != 0)
            {
                _singletonList
                    .RemoveAt(_singletonList.FindIndex(s => s.GetInstance() is T));
            }
        }
        private void CheckIfTransientAlreadyExists<T>()
        {
            if (_transientList.Where(s => s.GetInstance() is T).ToList().Count != 0)
            {
                _transientList
                    .RemoveAt(_transientList.FindIndex(s => s.GetInstance() is T));
            }
        }
    }
}