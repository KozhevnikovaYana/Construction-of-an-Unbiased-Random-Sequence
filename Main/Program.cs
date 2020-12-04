using System;
using Math.Functions;

namespace BernoulliSource
{
    internal static class Program
    {
       
        private static void Main(string[] args)
        {
            int[] x = {1, 0, 0, 1};
            PFunction function = new PFunction(x, 4, 1, 2);
            Console.Out.WriteLine(function.Calculate());
        }
    }
}