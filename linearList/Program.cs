internal class Program
{
    private static void Main(string[] args)
    {
        int LIST_SIZE = 10;

        int[] linearList = new int[LIST_SIZE];
        int numOfData = 0;

        void add(int data)
        {
            if (numOfData == LIST_SIZE)
            {
                Console.WriteLine("The list is full");
                return;
            }
            else
            {
                linearList[numOfData++] = data;
                return;
            }
        }

        int search(int targetData)
        {
            if (numOfData == 0)
            {
                Console.WriteLine("The list is empty");
                return -1;
            }

            for (int i = 0; i < numOfData; i++)
            {
                if (linearList[i] == targetData)
                {
                    return i;
                }
            }

            // Target doesn't exist
            return -1;
        }

        void update(int targetData, int newData)
        {
            if (numOfData == 0)
            {
                Console.WriteLine("The list is empty");
            }

            for (int i = 0; i < numOfData; i++)
            {
                if (linearList[i] == targetData)
                {
                    linearList[i] = newData;
                    return;
                }
            }

            Console.WriteLine("The target data doesn't exist");
            return;
        }

        void deleteData(int targetData)
        {
            if (numOfData == 0)
            {
                Console.WriteLine("The list is empty");
                return;
            }

            for (int i = 0; i < numOfData; i++)
            {
                if (linearList[i] == targetData)
                {
                    for (int j = i; j < numOfData - 1; j++)
                    {
                        linearList[j] = linearList[j + 1];
                    }
                    numOfData -= 1;
                    i -= 1;
                }
            }
        }

        void printAll()
        {
            for (int i = 0; i < numOfData; i++)
            {
                Console.Write(linearList[i]);
                if (i != numOfData - 1)
                {
                    Console.Write(", ");
                }
                else
                {
                    Console.Write("\n");
                }
            }
        }

        add(1);
        add(2);
        add(3);

        printAll();

        deleteData(2);

        int target = search(1);
        Console.WriteLine(target);

        printAll();
    }
    
}