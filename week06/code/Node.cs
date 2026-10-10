public class Node
{
    public int Value { get; set; }
    public Node? Left { get; set; }
    public Node? Right { get; set; }

    public Node(int value)
    {
        Value = value;
    }

    // Problema 1: Insert Unique Values Only
    public void Insert(int value)
    {
        if (value < Value)
        {
            if (Left is null)
            {
                Left = new Node(value);
            }
            else
            {
                Left.Insert(value);
            }
        }
        else if (value > Value)
        {
            if (Right is null)
            {
                Right = new Node(value);
            }
            else
            {
                Right.Insert(value);
            }
        }
        // Si value == Value, no hace nada (ignora duplicados)
    }

    // Problema 2: Contains
    public bool Contains(int value)
    {
        if (value == Value)
        {
            return true;
        }
        else if (value < Value)
        {
            return Left != null && Left.Contains(value);
        }
        else
        {
            return Right != null && Right.Contains(value);
        }
    }

    // Problema 4: Tree Height
    public int GetHeight()
    {
        int leftHeight = Left?.GetHeight() ?? 0;
        int rightHeight = Right?.GetHeight() ?? 0;

        return 1 + Math.Max(leftHeight, rightHeight);
    }
}
