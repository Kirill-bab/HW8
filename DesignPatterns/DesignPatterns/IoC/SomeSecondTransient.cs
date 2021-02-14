namespace DesignPatterns.IoC
{
    public class SomeSecondTransient
    {
        private readonly SomeSingleton _singleton;

        public SomeSecondTransient(SomeSingleton singleton)
        {
            _singleton = singleton;
        }

        public SomeSecondTransient()
        {
            _singleton = new SomeSingleton();
        }

        public int Counter => _singleton.Counter;
    }
}