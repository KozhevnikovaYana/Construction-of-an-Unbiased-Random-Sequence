using System;
using System.Collections.Generic;
using System.Linq;

namespace Math
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
            var str = Convert.ToString(x.GetNumerator(), 2);
            return ConvertStringToArray(str);
        }
        public static Fraction[] ConvertStringToArray(string str)
        {
            var charArray = str.ToCharArray();
            var intArray = new Fraction[charArray.Length];
            for (var i = 0; i < intArray.Length; ++i)
            {
                intArray[i] = new Fraction(charArray[i] - '0');
            }
            return intArray;
        }
        
        
        // Возвращает наибольший общий делитель (Алгоритм Евклида)
        public static int GetGreatestCommonDivisor(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }
        // Возвращает наименьшее общее кратное
        public static int GetLeastCommonMultiple(int a, int b)
        {
            // В формуле опушен модуль, так как в классе
            // числитель всегда неотрицательный, а знаменатель -- положительный
            // ...
            // Деление здесь -- челочисленное, что не искажает результат, так как
            // числитель и знаменатель делятся на свои делители,
            // т.е. при делении не будет остатка
            return a * b / GetGreatestCommonDivisor(a, b);
        }
    }
}