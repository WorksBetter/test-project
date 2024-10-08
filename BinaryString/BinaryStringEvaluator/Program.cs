using System;

public class Program
{
    public static void Main(string[] args)
    {
        // Test cases
        Console.WriteLine(IsGoodBinaryString("1100")); // True
        Console.WriteLine(IsGoodBinaryString("0011")); // False
        Console.WriteLine(IsGoodBinaryString("101010")); // True
        Console.WriteLine(IsGoodBinaryString("111000")); // False
        Console.WriteLine(IsGoodBinaryString("111000111000")); // True
        Console.WriteLine(IsGoodBinaryString("")); // False
        Console.WriteLine(IsGoodBinaryString("0")); // False
        Console.WriteLine(IsGoodBinaryString("1")); // False
        Console.WriteLine(IsGoodBinaryString("111000111")); // False
        Console.WriteLine(IsGoodBinaryString("1110000011")); // False
    }

    public static bool IsGoodBinaryString(string binaryString)
    {
        // Early exit for null or empty string
        if (string.IsNullOrEmpty(binaryString)) return false;

        int countZeroes = 0, countOnes = 0;
        int n = binaryString.Length;

        // Single pass through the string
        foreach (char c in binaryString)
        {
            if (c == '0')
            {
                countZeroes++;
            }
            else if (c == '1')
            {
                countOnes++;
            }
            else
            {
                // If the string contains invalid characters, return false
                return false;
            }

            // Condition 2: At no point should the number of 1's be less than 0's
            if (countZeroes > countOnes)
            {
                return false;
            }
        }

        // Condition 1: Ensure that the number of 0's and 1's are equal
        return countZeroes == countOnes;
    }
}