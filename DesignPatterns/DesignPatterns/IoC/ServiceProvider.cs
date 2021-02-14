using System;
using System.Collections.Generic;
using System.Linq;

namespace DesignPatterns.IoC
{
    class ServiceProvider : IServiceProvider
    {
        private readonly List<SomeSingleton> _singletonList;
        private readonly List<SomeTransient> _transientList;
        private readonly List<SomeSecondTransient> _secondTransientList;

        public ServiceProvider( List<SomeSingleton> singletonList,
            List<SomeTransient> transientList)
        {
            _singletonList = singletonList;
            _transientList = transientList;
        }

        public T GetService<T>()
        {
            var singleton = _singletonList.FirstOrDefault(s => s.GetInstance().GetType() == typeof(T));
            if (singleton != default(SomeSingleton))
            {
                return (T)singleton.GetInstance();
            }
            var transient = _transientList.FirstOrDefault(s => s.GetInstance().GetType() == typeof(T));
            if (transient != default(SomeTransient))
            {
                return (T)transient.GetInstance();
            }
            return default;
        }
    }
}
