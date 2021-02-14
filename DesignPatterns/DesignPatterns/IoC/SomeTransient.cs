using System;

namespace DesignPatterns.IoC
{
    public class SomeTransient
    {
        private int _counter = 0;
        private Type _type;

        public SomeTransient()
        {
            _counter++;
        }

        public object GetInstance()
        {
            var a = Activator.CreateInstance(_type);
            return a;
        }

        public void SetInstance(Type type)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));

            if (_type == null) _type = type;
        }

        public int Counter => _counter;
    }
}