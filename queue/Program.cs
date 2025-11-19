internal class Program
{
    public class CustomQueue<T>
    {
        private readonly T[] _items;

        /* most recent position */
        private int _front;
        /* lastest position */
        private int _rear;
        private readonly int _size;

        public CustomQueue(int size)
        {
            _size = size;
            _items = new T[size];
        }

        public void Enqueue(T item)
        {
            if (_rear > _size)
            {
                throw new ArgumentOutOfRangeException("Queue overflow");
            }

            _items[_rear] = item;

            /* when entered element is the lastet item in the queue */
            if (_rear == _size)
            {
                _rear = 1;
            }

            /* push the lastest position to back */
            else
            {
                _rear++;
            }
        }

        public T Dequeue()
        {
            T item = _items[_front];

            if (_front == _size)
            {
                _front = 1;
            }
            else
            {
                _front++;
            }
            return item;
        }

        public T Peek()
        {
            return _items[_front];
        }

    }
    private static void Main(string[] args)
    {
        CustomQueue<int> queue = new CustomQueue<int>(10);

        queue.Enqueue(1);
        queue.Enqueue(7);

        int peeked = queue.Peek();
        Console.WriteLine("Initial => {0}", peeked);

        /* Shift out the lastest element */
        int shifted = queue.Dequeue();

        int peekedNext = queue.Peek();

        /* Shift out the next element */
        Console.WriteLine("Next => {0}", peekedNext);

        int nextShifted = queue.Dequeue();

        Console.WriteLine(shifted);
        Console.WriteLine(nextShifted);
    }
}