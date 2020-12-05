using System;
using System.Collections.Generic;
using System.Linq;

namespace Math
{
    public static class Util
    {
        public static double CombinationsNumber(int n, int k)
        {
            if (n < k)
            {
                return 0;
            }
            return ((double)Factorial(n))/(Factorial(k) * Factorial(n - k));
        }

        private static int Factorial(int n)
        {
            return (n == 0) ? 1 : n * Factorial(n - 1);
        }

        public static int MassiveSum(IReadOnlyList<int> x, int t)
        {
            if (x.Count < t)
                t = x.Count;
            
            var sum = 0;
            for (var i = 0; i < t; ++i)
            {
                sum += x[i];
            }

            return sum;
        }

        public static int CountOnes(IReadOnlyList<int> x)
        {
            return x.Sum();
        }
        
        public static int[] ConvertIntToArray2(int x)
        {
            var str = Convert.ToString(x, 2);
            return ConvertStringToArray(str);
        }
        public static int[] ConvertStringToArray(string str)
        {
            var charArray = str.ToCharArray();
            var intArray = new int[charArray.Length];
            for (var i = 0; i < intArray.Length; ++i)
            {
                intArray[i] = charArray[i] - '0';
            }
            return intArray;
        }
    }
}