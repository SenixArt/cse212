using System.Collections;
using System.Collections.Generic;

public class BinarySearchTree : IEnumerable<int>
{
    public Node? Root { get; set; }

    /// <dt>Insert a new value to the tree.</dt>
    public void Insert(int value)
    {
        if (Root is null)
            Root = new Node(value);
        else
            Root.Insert(value);
    }

    /// <dt>Check if the tree contains a value.</dt>
    public bool Contains(int value)
    {
        return Root != null && Root.Contains(value);
    }

    /// <dt>Get the height of the tree.</dt>
    public int GetHeight()
    {
        return Root?.GetHeight() ?? 0;
    }

    // Traverse forward (In-Order: Left -> Root -> Right)
    public IEnumerator<int> GetEnumerator()
    {
        var numbers = new List<int>();
        TraverseForward(Root, numbers);
        foreach (var number in numbers)
        {
            yield return number;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    private void TraverseForward(Node? node, List<int> values)
    {
        if (node is not null)
        {
            TraverseForward(node.Left, values);
            values.Add(node.Value);
            TraverseForward(node.Right, values);
        }
    }

    // --- PROBLEMA 3: Traverse Backwards (Reversed) ---
    public IEnumerable<int> Reversed()
    {
        var values = new List<int>();
        TraverseBackward(Root, values);
        return values;
    }

    private void TraverseBackward(Node? node, List<int> values)
    {
        if (node is not null)
        {
            TraverseBackward(node.Right, values);
            values.Add(node.Value);
            TraverseBackward(node.Left, values);
        }
    }
}
