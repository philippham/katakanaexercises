using System;
using System.Collections.Generic;

namespace FindPairWithGivenSum
{
    class Program
    {
        static void Main(string[] args)
        {
            var arrays = new[] { 1, 2, 4, 6, 9, 5, 5, -1, 11, -5, 5 };
            var sum = 10;

            var dict = new Dictionary<int, int>();

            Console.WriteLine("Arrays: ");
            foreach (var each in arrays)
            {
                Console.Write(each + " ");
                if (!dict.ContainsKey(each))
                    dict.Add(each, 0);
            }
            Console.WriteLine();

            foreach (var each in arrays)
            {
                var removeKey = sum - each;
                if (dict.ContainsKey(removeKey))
                {
                    dict.Remove(removeKey);
                    dict[each] = removeKey;
                }
                else
                    dict.Remove(each);
            }

            Console.WriteLine("Sum = " + sum);
            foreach (var each in dict)
                Console.WriteLine(each.Key + " <-> " + each.Value);

            Console.ReadKey();
        }
    }

}
