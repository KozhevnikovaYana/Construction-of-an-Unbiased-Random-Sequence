using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Functions
{
    public static class Util
    {
        public static Fraction CombinationsNumber(Fraction n, Fraction k)
        {
            if (n < k)
            {
                return new Fraction(0);
            }
            var fraction = Factorial(n) /  (Factorial(k) * Factorial(n - k));
            return fraction;
        }

        private static Fraction Factorial(Fraction n)
        {
            return (n == 0) ? new Fraction(1) : n * Factorial(n - 1);
        }

        public static Fraction MassiveSum(IReadOnlyList<Fraction> x, int t)
        {
            if (x.Count < t)
                t = x.Count;
            
            Fraction sum = new Fraction(0);
            for (var i = 0; i < t; ++i)
            {
                sum += x[i];
            }

            return sum;
        }

        public static Fraction CountOnes(IReadOnlyList<Fraction> x)
        {
            Fraction sum = new Fraction(0);
            foreach (var item in x)
            {
                sum = item + sum;
            }
            return sum;
        }
        
        public static Fraction[] ConvertIntToArray2(Fraction x)
        {
            int number = ConvertBigIntegerToInt(x.GetNumerator());
            String str = Convert.ToString(number, 2);
            return ConvertStringToArray(str);
        }
        public static Fraction[] ConvertStringToArray(string str)
        {
            var charArray = str.ToCharArray();
            var intArray = new Fraction[charArray.Length];
            for (var i = 0; i < intArray.Length; ++i)
            {
                BigInteger integer = new BigInteger(charArray[i] - '0');
                intArray[i] = new Fraction(integer);
            }
            return intArray;
        }
        public static Fraction[] ConvertIntToArray(int number)
        {
            return ConvertStringToArray(number.ToString());
        }
        
        // Возвращает наибольший общий делитель (Алгоритм Евклида)
        public static BigInteger GetGreatestCommonDivisor(BigInteger a, BigInteger b)
        {
            while (b != 0)
            {
                BigInteger temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }
        // Возвращает наименьшее общее кратное
        public static BigInteger GetLeastCommonMultiple(BigInteger a, BigInteger b)
        {
            return (a * b / GetGreatestCommonDivisor(a, b));
        }

        public static int ConvertBigIntegerToInt(BigInteger num)
        {
            var str = num.ToString();
            var answer = 0;
            foreach (var character in str)
            {
                answer = answer * 10 + character - '0';
            }

            return answer;
        }
    }
}