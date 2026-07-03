public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Plan:
        // 1. Create a new array of doubles with size 'length' to hold the result.
        // 2. Loop through indexes 0 to length - 1.
        // 3. At each index i, the value we want is 'number' multiplied by (i + 1),
        //    because index 0 should hold the 1st multiple (number * 1),
        //    index 1 should hold the 2nd multiple (number * 2), and so on.
        // 4. Store that calculated value into the array at index i.
        // 5. Once the loop is done, return the filled array.

        var result = new double[length];
        for (var i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);
        }
        return result;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Plan:
        // 1. The last 'amount' elements of the list need to move to the front.
        //    Find the index where that tail section starts: data.Count - amount.
        // 2. Use GetRange to copy that tail section (the last 'amount' elements) into
        //    a separate temporary list.
        // 3. Remove that tail section from the original list using RemoveRange, since
        //    we've already saved a copy of it in step 2.
        // 4. Insert the saved tail section back at the beginning (index 0) of the
        //    now-shortened list using InsertRange.
        // 5. Since 'data' is a List (reference type) and we're modifying it directly,
        //    no return value is needed - the caller's list is rotated in place.

        var splitIndex = data.Count - amount;
        var tail = data.GetRange(splitIndex, amount);
        data.RemoveRange(splitIndex, amount);
        data.InsertRange(0, tail);
    }
}
