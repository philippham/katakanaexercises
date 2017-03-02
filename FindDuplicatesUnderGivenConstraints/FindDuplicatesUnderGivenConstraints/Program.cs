using System;

namespace FindDuplicatesUnderGivenConstraints
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstArray = new[] { 1, 1, 1, 1, 1, 5, 7, 10, 20, 30 };
            var secondArray = new[] { 1, 2, 3, 3, 3, 3, 3, 5, 9, 10 };

            Console.WriteLine(FindDuplicate(firstArray));
            Console.WriteLine(FindDuplicate(secondArray));

            Console.ReadKey();
        }

        static int FindDuplicate(int[] numbers) // 10 elements
        {
            if (numbers[3] == numbers[4])
                return numbers[3];
            if (numbers[4] == numbers[5])
                return numbers[4];
            return numbers[5];
        }
    }
}
