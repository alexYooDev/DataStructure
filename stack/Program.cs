internal class Program
{
    public class CustomStack<T>
    {
        private T[] _items;

        /* The index of the top element */
        private int _top;

        public CustomStack(int capacity)
        {
            if (capacity <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity), "Capacity must be greater than zero.");
            }

            /* initialize with a fixed capacity */
            _items = new T[capacity];

            /* Empty Stack */
            _top = -1;
        }

        /* lambda function for stack capacity validation */
        public bool IsEmpty => _top == -1;

        public int Count()
        {
            return _top + 1;
        }

        public void Push(T item)
        {
            if (_top == _items.Length - 1)
            {
                // Dynamically resize the stack to double capacity
                Array.Resize(ref _items, _items.Length * 2);
            }

            _top++;
            _items[_top] = item;
        }

        public T Pop()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("No elements to pop.");
            }

            /* the element on the top of the stack */
            T item = _items[_top];

            /* move the index to the next item */
            _top--;

            return item;
        }

        public T Peek()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("No elements to peek");
            }

            T item = _items[_top];

            return item;
        }
    }

    private static void Main(string[] args)
    {
        CustomStack<int> stack = new CustomStack<int>(10);

        stack.Push(1);
        stack.Push(3);

        int top = stack.Pop();
        int nextTop = stack.Pop();
        // int anotherTop = stack.Pop();
        // int count = stack.Count();
        

        Console.WriteLine(top);
        Console.WriteLine(nextTop);
        Console.WriteLine(count);
        // Console.WriteLine(anotherTop);
        
    }
}