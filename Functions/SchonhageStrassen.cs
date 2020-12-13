using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Functions
{
    public static class SchonhageStrassen
    {
        public static BigInteger Multiply(BigInteger number1, BigInteger number2)
        {
            var signum = number1.Sign * number2.Sign;

            if (number1.Sign < 0)
                number1 = BigInteger.Negate(number1);
            if (number2.Sign < 0)
                number2 = BigInteger.Negate(number2);
            
            var aIntArr = ConvertBigIntegerToArray(number1);
            var bIntArr = ConvertBigIntegerToArray(number2);
            var answerArr = Multiply(aIntArr, bIntArr);
            Normalize(answerArr);
            var answer = ConvertArrayToBigInteger(answerArr);
            if (signum < 0)
                answer = BigInteger.Negate(answer);

            return answer;
        }
       private static int CountDigits(BigInteger number)
       {
           return number.ToString().Length;
       }
       
       private static List<int> ConvertBigIntegerToArray(BigInteger number)
       {
           var numberLength = CountDigits(number);
           var intArray = new List<int>(numberLength);
           var str = number.ToString();
           for (var i = numberLength - 1; i >= 0; --i)
           {
               intArray.Add(str[i] - '0');
           }
           return intArray;
       }
       
       
       public static BigInteger ConvertArrayToBigInteger(List<int> digitArray)
       {
           var answer = BigInteger.Zero;
           for (var i = digitArray.Count - 1; i >= 0; --i)
           {
               answer = answer * 10 + digitArray[i];
           }

           return answer;
       }
       
        private static List<int> Multiply(List<int> number1, List<int> number2)
        {
            var n = 1;
            while (n < Math.Max(number1.Count, number2.Count))
            {
                n <<= 1;
            }
            n <<= 1;
            var fa = new List<Complex>(n);
            var fb = new List<Complex>(n);
            
            fa.AddRange(number1.Select(t => new Complex(t, 0)));
            fb.AddRange(number2.Select(t => new Complex(t, 0)));
            for (var i = 0; i < n - number1.Count; ++i)
            {
                fa.Add(Complex.Zero);
            }
            for (var i = 0; i < n - number2.Count; ++i)
            {
                fb.Add(Complex.Zero);
            }
            FastFourierTransform(fa, false);
            FastFourierTransform(fb, false);
            for (var i = 0; i < n; ++i)
            {
                
                fa[i] *= fb[i];
            }
            FastFourierTransform(fa, true);
            var result = new List<int>();
            for (var i = 0; i < n; ++i)
            {
                result.Add((int)(fa[i].Real + 0.5));
            }
            return result;
        }

        private static void FastFourierTransform(List<Complex> number, bool invert)
        {
            var len = number.Count;
            if (len == 1)
            {
                return;
            }
            var number0 = new List<Complex>(len / 2);
            var number1 = new List<Complex>(len / 2);
            for (int i = 0, j = 0; i < len; i += 2, ++j)
            {
                number0.Add(number[i]);
                number1.Add(number[i + 1]);
            }
            
            FastFourierTransform(number0, invert);
            FastFourierTransform(number1, invert);
            var ang = 2 * Math.PI / len * (invert ? -1 : 1);

            var w  = Complex.One;
            var wn = new Complex(Math.Cos(ang), Math.Sin(ang));
            for (var i = 0; i < len / 2; ++i) {
                number[i] = number0[i] + w * number1[i];
                number[i + len/2] = number0[i] - w * number1[i];
                if (invert)
                {
                    number[i] /= 2;
                    number[i + len/2] /= 2;
                }
                w *= wn;
            }
        }

        private static void Normalize(List<int> result)
        {
            int carry = 0;
            for (var i = 0; i < result.Count; ++i)
            {
                result[i] += carry;
                carry = result[i] / 10;
                result[i] %= 10;
            }
        }
    }
}