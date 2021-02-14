using DesignPatterns.Builder;
using System;

namespace DesignPatterns.ChainOfResponsibility
{
    public class InvertMutator : IStringMutator
    {
        private IStringMutator _nextMutator;
        public IStringMutator SetNext(IStringMutator next)
        {
            if (next == null) throw new ArgumentNullException(nameof(next));

            if(_nextMutator != null)
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

            var newStr = new CustomStringBuilder();
            for (int i = 0; i < str.Length; i++)
            {
                newStr.Append(str[str.Length - 1 - i]);
            }

            if(_nextMutator != null)
            {
                return _nextMutator.Mutate(newStr.Build());
            }

            return newStr.Build();
        }
    }
}