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
            if (IsReadOnly()) return;
            if (ElementsExceedSize(IncreaseSizeByOne())) ExpandList();
            AddElement(element);
        }
        
        private void AddElement(object element)
        {
            _elements[_size++] = element;
        }

        private bool IsReadOnly()
        {
            return _readOnly;
        }

        private bool ElementsExceedSize(int newSize)
        {
            return newSize > _elements.Length;
        }

        private int IncreaseSizeByOne()
        {
            return _size + 1;
        }
        
        private void ExpandList()
        {
            var newElements = new object[_elements.Length + 10];
            for (var i = 0; i < _size; i++)
                newElements[i] = _elements[i];
            _elements = newElements;
        }

        public object[] Elements()
        {
            return _elements;
        }

    }

}