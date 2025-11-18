using System;
using System.Collections.Generic;

internal class Program
{
    public class Node<T>
    {
        public T Data { get; set; }
        public Node<T>? Next { get; set; }

        public Node(T data)
        {
            Data = data;

            /* reference to the next node */
            Next = null; // Initially node points to null in the empty list.
        }
    }


    public class LinkedList<T>
    {
         // Reference to the first node in the list
        private Node<T>? _head;

        public LinkedList()
        {
            _head = null;
        }

        public void AddLast(T data)
        {
            Node<T> newNode = new Node<T>(data);

            // if it's the first node to be created in the list
            if (_head == null)
            {
                _head = newNode;
            }
            else
            {
                /* first node */
                Node<T> current = _head!; // _head is not null here

                /* if the first node has the next node pointing */
                while (current.Next != null)
                {
                    // Traverse to the last node
                    current = current.Next;
                }

                // link the last node to the new node
                current.Next = newNode;
            }
        }

        public void AddFirst(T data)
        {
            Node<T> newNode = new Node<T>(data);

            /* first new node points to the previous head */
            newNode.Next = _head;

            /* new node becomes the head */
            _head = newNode;
        }

        public void Update(T target, T data)
        {
            Node<T>? current = _head;

            while (current != null)
            {
                if (EqualityComparer<T>.Default.Equals(current.Data, target))
                {
                    // update the stored data in the found node
                    current.Data = data;
                    return;
                }

                // advance to next node
                current = current.Next;
            }
        }

        public Node<T>? Find(T data)
        {
            Node<T>? current = _head;

            while (current != null)
            {
                if (EqualityComparer<T>.Default.Equals(current.Data, data))
                {
                    return current;
                }
                current = current.Next;
            }
            return null;
        }

        public void Remove(T data)
        {
            /* if the list is empty */
            if (_head == null)
            {
                return;
            }

            if (_head.Data.Equals(data))
            {
                _head = _head.Next; // If head is the target, update head
                return;
            }

            Node<T> current = _head;

            /* target is the element in the middle (neither first nor last) */
            while (current.Next != null && !current.Next.Data.Equals(data))
            {
                current = current.Next;
            }
            
            if (current.Next != null)
            {
                current.Next = current.Next.Next;
            }
        }

        public void Display()
        {
            Node<T>? current = _head;
            while (current != null)
            {
                Console.Write($"{current.Data} -> ");
                current = current.Next;
            }
            Console.WriteLine("Null");
        }
    }
    
    private static void Main(string[] args)
    {
        var linkedList = new LinkedList<int>();

        linkedList.AddFirst(1);
        linkedList.AddLast(3);
        linkedList.AddFirst(2);
        linkedList.AddFirst(2);

        linkedList.Update(3, 7);

        linkedList.Display();
    }
}