namespace Lab7.LinkedListClasses;

public class Node
{
    private float _value;
    private Node? _next;

    public Node(float value)
    {
        Value = value;
        _next = null;
    }

    public float Value
    {
        get => _value;
        init
        {
            _value = value;
        }
    }

    public Node? Next
    {
        get => _next;
        set
        {
            _next = value;
        }
    }
}