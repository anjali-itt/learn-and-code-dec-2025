//Assignment 2 – Floor of Mean of Subarray

using System;

class Program
{
    static void Main()
    {
        var input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

        int numberOfElements = input[0];
        int numberOfQueries = input[1];

        long[] arrayElements =
            Array.ConvertAll(Console.ReadLine().Split(), long.Parse);

        long[] prefixSum = new long[numberOfElements + 1];

        for (int index = 1; index <= numberOfElements; index++)
        {
            prefixSum[index] =
                prefixSum[index - 1] + arrayElements[index - 1];
        }

        for (int queryIndex = 0; queryIndex < numberOfQueries; queryIndex++)
        {
            var query =
                Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

            int leftIndex = query[0];
            int rightIndex = query[1];

            long subArraySum =
                prefixSum[rightIndex] - prefixSum[leftIndex - 1];

            long mean =
                subArraySum / (rightIndex - leftIndex + 1);

            Console.WriteLine(mean);
        }
    }
}