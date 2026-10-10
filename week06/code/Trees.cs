using System;
using System.Collections.Generic;

public static class Trees
{
    public static BinarySearchTree CreateTreeFromSortedList(List<int> sortedList)
    {
        var tree = new BinarySearchTree();
        InsertMiddle(sortedList, 0, sortedList.Count - 1, tree);
        return tree;
    }

    // --- PROBLEMA 5: Insert Middle for Balanced Tree ---
    public static void InsertMiddle(List<int> sortedList, int first, int last, BinarySearchTree tree)
    {
        if (first > last)
        {
            return;
        }

        int middle = first + (last - first) / 2;
        tree.Insert(sortedList[middle]);

        // Mitad izquierda
        InsertMiddle(sortedList, first, middle - 1, tree);

        // Mitad derecha
        InsertMiddle(sortedList, middle + 1, last, tree);
    }
}
