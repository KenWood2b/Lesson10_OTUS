using System.Collections;
using System.Collections.Generic;

namespace Code
{
    public sealed class StringEnumerable : IEnumerable<string>
    {
        private readonly string[] _strings;

        public StringEnumerable(string[] strings)
        {
            _strings = strings;
        }

        IEnumerator<string> IEnumerable<string>.GetEnumerator()
        {
            return new StringEnumerator(_strings);
        }

        public IEnumerator GetEnumerator()
        {
            return new StringEnumerator(_strings);
        }
    }
}