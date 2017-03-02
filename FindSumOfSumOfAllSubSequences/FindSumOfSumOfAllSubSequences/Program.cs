using System;

namespace FindSumOfSumOfAllSubSequences
{
    class Program
    {
        static void Main(string[] args)
        {

            var array = new[] { 6, 8, 5 };

            var sum = 0;
            var n = array.Length;

            for (var i = 0; i < n; i++)
                sum += array[i];

            var answer = sum * Math.Pow(2, n - 1);

            Console.WriteLine(answer);

            Console.ReadKey();
        }
    }
}
