using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Code
{
    public sealed class StringEnumerator : IEnumerator<string>
    {
        public string Current => _strings[_currentIndex];
        
        object IEnumerator.Current => Current;

        private readonly string[] _strings;

        private int _currentIndex = -1;
        private string _current;

        public StringEnumerator(string[] strings)
        {
            Debug.Log("Create Enumerator");
            _strings = strings;
        }

        public bool MoveNext()
        {
            _currentIndex++;

            if (_currentIndex > _strings.Length - 1)
            {
                Reset();
                return false;
            }

            return true;
        }

        public void Reset()
        {
            Debug.Log("Reset");
            _currentIndex = -1;
        }

        public void Dispose()
        {
            Debug.Log("Dispose");
        }
    }
}