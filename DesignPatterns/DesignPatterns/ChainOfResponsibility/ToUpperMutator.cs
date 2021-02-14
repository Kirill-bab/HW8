using System;

namespace DesignPatterns.ChainOfResponsibility
{
    public class ToUpperMutator : IStringMutator
    {
        private IStringMutator _nextMutator;
        public IStringMutator SetNext(IStringMutator next)
        {
            if (next == null) throw new ArgumentNullException(nameof(next));

            if (_nextMutator != null)
            {
                _nextMutator.SetNext(next);
            }
            else
            {
                _nextMutator = next;
            }
            return this;
        }

        public string Mutate(string str)
        {
            if (string.IsNullOrEmpty(str)) return "";

            str = str.ToUpper();

            if (_nextMutator != null)
            {
                return _nextMutator.Mutate(str);
            }

            return str;
        }
    }
}