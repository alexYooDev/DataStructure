# LinearList 

## Definition

- A datastructure that consecutively stores data in linear order (1, 2, 3, 4, 5,...)
- Commonly implemented with array (a list without a gap between values it holds, has index for each value)
- The elements' logical order corresponds to the physical order in memory.

## The pros of LinearList

- Enables fast search of its elemnents with its index (its position in the linearlist)
- The elements exists in linear sequence, so they are easy to manage

## The cons of LinearList

- It is difficult and costly to delete elements in a linear list since they have fixed position in the memory.
- Also, because of the fixed size of the linear list, there may be an issue with redundancy of the memory space.


## Example code implementation

```
# fixed size
LIST_SIZE = 10

# define a linear list with fixed size
int[] linearList = new int[LIST_SIZE];
int numOfData = 0;

void add(int data) 
{
    if (numOfData < LIST_SIZE) 
    {
        linearList[++numOfData] = data;
        return;
    } 
    else 
    {
        System.WriteLine("The linear list is full");
        return;
    }
}

int search(int data) 
{
    if (numOfData == 0) 
    {
        # no data exist in the list
        return -1;
    }    

    for (int i = 0; i < numOfData; i++) 
    {
        if (linearList[i] == data) 
        {
            return i;
        }
    }

    # the target data doesn't exist in the list
    return -1
}

void update (int targetData, int newData) 
{
    if (numOfData == 0) 
    {
        Console.WriteLine("No data exist in the list");
        return;
    }

    for (int i = 0; i < numOfData; i++)
    {
        if (linearList[i] == targetData)
        {
            linearList[i] = newData;
            return;
        }
    }
}

void DeleteData(int targetData)
{
    if (numOfData == 0) 
    {
        Console.WriteLine("The linear list is empty");
        return;
    }

    for (int i = 0; i < numOfData; i++)
    {
        if (linearList[i] == targetData)
        {
            for (j = i; j >= numOfData; j--) 
            {
                linearList[j] = linearList[j-1];
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
        Console.WriteLine(linearList[i]);
    }
}
```