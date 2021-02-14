using System.Collections.Generic;

namespace DesignPatterns.Builder
{
    public class CustomStringBuilder : ICustomStringBuilder
    {
        private readonly List<string> _str;
        public CustomStringBuilder()
        {
            _str = new List<string>();
        }

        public CustomStringBuilder(string text)
        {
            _str = new List<string>() { text };
        }

        public ICustomStringBuilder Append(string str)
        {
            _str.Add(str);
            return this;
        }

        public ICustomStringBuilder Append(char ch)
        {
            _str.Add(ch.ToString());
            return this;
        }

        public ICustomStringBuilder AppendLine()
        {
            _str.Add("\n");
            return this;
        }

        public ICustomStringBuilder AppendLine(string str)
        {
            Append(str);
            AppendLine();
            return this;
        }

        public ICustomStringBuilder AppendLine(char ch)
        {
            Append(ch);
            AppendLine();
            return this;
        }

        public string Build()
        {
            return string.Join("", _str);
        }
    }
}