using System;
using System.Collections.Generic;

public static class Arrays
{
    public static double[] MultiplesOf(double number, int length)
    {
        // PLAN:
        // 1. Create a new array of doubles with a size equal to the 'length' parameter.
        // 2. Set up a for loop that starts at index 0 and iterates 'length' times.
        // 3. Inside the loop, calculate the multiple by multiplying the starting 'number' by (index + 1).
        // 4. Assign the calculated result to the current index in the new array.
        // 5. After the loop finishes, return the populated array.

        double[] multiples = new double[length];

        for (int i = 0; i < length; i++)
        {
            multiples[i] = number * (i + 1);
        }

        return multiples;
    }

    public static void RotateListRight(List<int> data, int amount)
    {
        // PLAN:
        // 1. Calculate the starting index for the slice we need to move (data.Count - amount).
        // 2. Use the GetRange(index, count) method to extract the last 'amount' elements and save them in a new list.
        // 3. Use the RemoveRange(index, count) method to delete those same elements from the end of the original 'data' list.
        // 4. Use the InsertRange(index, list) method to insert the saved elements at the very beginning (index 0) of the original 'data' list.

        int splitIndex = data.Count - amount;
        
        List<int> tailElements = data.GetRange(splitIndex, amount);
        data.RemoveRange(splitIndex, amount);
        data.InsertRange(0, tailElements);
    }
}
