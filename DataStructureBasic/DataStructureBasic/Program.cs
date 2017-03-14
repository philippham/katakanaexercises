using System;

namespace DataStructureBasic
{
    class Program
    {
        static void Main(string[] args)
        {
            var postfixCalculator = new PostfixCalculator("567*+1-");
            Console.WriteLine(postfixCalculator.Calculate());
            Console.ReadKey();
        }
    }
}
