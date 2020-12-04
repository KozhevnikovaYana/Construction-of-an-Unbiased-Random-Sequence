using System.Collections.Generic;

namespace Math
{
    public static class Util
    {
        public static double CombinationsNumber(int n, int k)
        {
            return ((double)Factorial(n))/(Factorial(k) * Factorial(n - k));
        }

        private static int Factorial(int n)
        {
            return (n == 0) ? 1 : n * Factorial(n - 1);
        }

        public static int MassiveSum(IReadOnlyList<int> x, int t)
        {
            var sum = 0;
            for (var i = 0; i < t; ++i)
            {
                sum += x[i];
            }

            return sum;
        }
    }
}