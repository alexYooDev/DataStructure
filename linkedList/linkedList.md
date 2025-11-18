# LinkedList

## Defintion
- a linear data structure with elements linked together using references instead of being stored in contiguous memory locations (linear list)

## Characteristics
- Nodes:
    - A unit for storing a single data.
    - Each node holds a value, and the reference to the next node.
- Non-contiguous Memory:
    - Unlike linear list, nodes can be scattered throughout memory, for the nodes are connected with references rather then physical memory locations.
- Dynamic Size:
    - Linked list can dynamically change its size during runtime, as memory is allocated for each node as it is added
- Efficient Manipulation:
    - Because the nodes are linked with references, addition and deletion of elements is efficient, either at the beginning or end of the list, or in the middle if you have a pointer to the preceding node.

## How it works
1. list initialization: 
    - A linked list starts with a pointer to the first node, often called the "head". If the list is empty, the head is null
2. Adding an element: 
    - A new node is created with its data. The new node is then linked to the existing next node, and the previous node updates to point to the newly created node.  
3. Traversing
    - To find an element, you must start at the head and follow the links (references) from one node to the next until you reach the desired node or the last node in the list.

## Variations
- Singly linked list: Each node points only to the next node in the sequence.
- Doubly linked list: Each node has a pointer to both the next node and the previous node.
- Circular linked list: The last node's link points back to the first node, creating a loop.

## Common Use
- Linked lists are often used as the underlying structure for stacks, queues, and other abstract data types. 
- They are ideal for situations where you need to add or remove elements frequently, such as in a playlist or a history function.

## Code example implementation

```csharp
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
```


