using System;

namespace DesignPatterns.ChainOfResponsibility
{
    public class RemoveNumbersMutator : IStringMutator
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

            for (int i = 0; i < str.Length; i++)
            {
                if(int.TryParse(str[i].ToString(), out _))
                {
                    if (i < str.Length - 3 &&
                        ",.".Contains(str[i + 1]) &&
                        int.TryParse(str[i + 2].ToString(), out _))
                    {
                        str = str.Remove(i, 3);
                    }
                    else
                    {
                       str = str.Remove(i, 1);
                    }
                }
            }

            if (_nextMutator != null)
            {
                return _nextMutator.Mutate(str);
            }

            return str;
        }
    }
}