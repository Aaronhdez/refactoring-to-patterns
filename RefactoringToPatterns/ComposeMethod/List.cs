using System;
using System.Linq;
using System.Web;

namespace RefactoringToPatterns.ComposeMethod
{
    public class List
    {

        private readonly bool _readOnly;
        private int _size;
        private object[] _elements;

        public List(bool readOnly)
        {
            _readOnly = readOnly;
            _size = 0;
            _elements = new object[_size];
        }

        public void Add(object element)
        {
            if (_readOnly) return;
            var newSize = _size + 1;

            if(newSize > _elements.Length) {
                var newElements = new object[_elements.Length + 10];

                for (var i = 0; i < _size; i++)
                    newElements[i] = _elements[i];

                _elements = newElements;
            }

            _elements[_size++] = element;
        }

        public object[] Elements()
        {
            return _elements;
        }

    }

}