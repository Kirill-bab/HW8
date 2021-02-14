using System;

namespace DesignPatterns.IoC
{
    public class SomeSingleton
    {
        private int _counter = 0;
        private object _instance;

        public SomeSingleton()
        {
            _counter++;
        }

        public SomeSingleton(object instance)
        {
            SetInstance(instance);
        }
        public object GetInstance()
        {
            if(_instance == null)
            {
                _instance =  new SomeSingleton();
            }
            return _instance;
        }

        private void SetInstance(object instance)
        {
            if (instance == null) throw new ArgumentNullException(nameof(instance));

            if (_instance == null) _instance = instance;
        }
        
        public int Counter => _counter;
    }
}
