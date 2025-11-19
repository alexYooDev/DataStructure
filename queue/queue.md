# Queue

## Definition
Queue is a linear data structure symbolized by its First In First Out (FIFO) structure unlike Stack, which has a Last In First Out structure. Real world example of this is, number ticket system in a bank or a F&B venue. 

## How it works 
How does a queue remembers the next element to be processed (decides the operation's priority)?
Stack only needs to remember the first element entered and the last element to be processed to keep track of them.

Below are the key characteristics and operations a queue possesses:

1. Enqueue: Insert a new element at the end of a queue.
2. Dequeue: Remove/Dispense the last element, that was most previously stored in a queue.
3. Peek: Read an element at 'Front' (Most recent) position. Check which element entered last.
4. Front: The most recent position of an element entered.
5. Rear: The most previous position of an element to be removed next.


```csharp
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
```