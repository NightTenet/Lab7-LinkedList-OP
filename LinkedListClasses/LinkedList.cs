using System.Collections;

namespace Lab7.LinkedListClasses;

public class LinkedList : IEnumerable<float>
{
    private Node? _head;

    public LinkedList(Node? head)
    {
        _head = head;
    }

    public LinkedList() : this(null)
    {
    }

    public void AddToEnd(float value)
    {
        if (_head is null)
            _head = new Node(value);    
        else
        {
            Node currentNode = _head;
            while (currentNode.Next != null)
                currentNode = currentNode.Next;
            
            currentNode.Next = new Node(value);
        }
    }

    public Node? FindFirstElementThatGreaterThan(float parameter)
    {
        Node? currentNode = _head;
        while (currentNode != null)
        {
            if (currentNode.Value > parameter)
            {
                return currentNode;
            }
            currentNode = currentNode.Next;
        }
        return null;
    }

    public float FindSumOfLowerNumbers()
    {
        float negNumber = 0f;
        Node? currentNode = _head;

        while (currentNode != null)
        {
            if (currentNode.Value < 0f)
            {
                negNumber = currentNode.Value;
                break;
            }
            currentNode = currentNode.Next;
        }

        float sum = 0f;
        currentNode = _head;
        if (negNumber != 0f)
        {
            while (currentNode != null)
            {
                if (currentNode.Value < negNumber)
                    sum += currentNode.Value;
                currentNode = currentNode.Next;
            }
        }
        return sum;
    }

    public LinkedList? CreateNewList(float parameter)
    {
        LinkedList newList = new LinkedList();
        Node? currentNode = _head;
        
        while (currentNode != null)
        {
            if (currentNode.Value > parameter)
            {
                newList.AddToEnd(currentNode.Value);
            }
            currentNode = currentNode.Next;
        }
        return newList;
    }

    public void RemoveAtIndex(int index)
    {
        if (index < 0 || _head == null)
            throw new ArgumentException();
        
        if (index == 0)
        {
            _head = _head.Next;
        }
        else
        {
            Node? currentNode = _head;
            for (int i = 0; i < index - 1; i++)
            {
                if (currentNode == null)
                    throw new ArgumentOutOfRangeException();
                
                currentNode = currentNode.Next;
            }

            if (currentNode == null || currentNode.Next == null)
                throw new ArgumentNullException();

            currentNode.Next = currentNode.Next.Next;
        }
    }

    public float this[int index]
    {
        get
        {
            if (index < 0)
                throw new ArgumentOutOfRangeException();
            
            Node? currentNode = _head;

            for (int i = 0; i < index; i++)
            {
                if (currentNode == null)
                    throw new ArgumentNullException();
                currentNode = currentNode.Next;
            }

            if (currentNode == null)
                throw new ArgumentNullException();

            return currentNode.Value;
        }
    }

    public IEnumerator<float> GetEnumerator()
    {
        Node? currentNode = _head;

        while (currentNode != null)
        {
            yield return currentNode.Value;
            currentNode = currentNode.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}