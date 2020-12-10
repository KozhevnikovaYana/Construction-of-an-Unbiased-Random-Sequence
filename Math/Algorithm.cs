using System;
using System.Collections.Generic;
using Math.Functions;

namespace Math
{
    public class Algorithm
    {
        private Fraction _n;
        private Fraction[] _x;

        public Algorithm()
        {
            InitData();
        }

        private void InitData()
        {
            Console.Out.Write("Введите последовательность: ");
            _x = Util.ConvertStringToArray(Console.In.ReadLine());
            Console.Out.Write("Введите N: ");
            _n = new Fraction(int.Parse(Console.In.ReadLine() ?? "4"));
        }
     
        public void Run()
        {
            var code = new List<Fraction>();
            var startIndex = new Fraction(0);
            while (startIndex < _x.Length - 1)
            {
                var destinationArray = CalculateArray(startIndex,0);
                var k = CalculateK(destinationArray);
                var num = CalculateNum(destinationArray, k);
                FindBounds(num, k, out var answerI, out var answerJ);
                AddCode(code, num, answerJ);
                Console.WriteLine();
                startIndex += _n;
            }
            Console.Out.Write("Ответ: ");
            foreach (var t in code)
            {
                Console.Out.Write(t.ToString());
            }
        }

        public Fraction[] CalculateArray(Fraction sourceIndex, int destinationIndex)
        {
            var destinationArray = new Fraction[_n.GetNumerator()];
            Array.Copy(_x, sourceIndex.GetNumerator(), destinationArray, destinationIndex, _n.GetNumerator());
            Console.Out.Write("Блок = ");
            for (var i = 0; i < _n; ++i)
            {
                Console.Out.Write(destinationArray[i]);
            }
            Console.WriteLine();
            return destinationArray;
        }
        private Fraction CalculateK(IReadOnlyList<Fraction> array)
        {
            var k = Util.CountOnes(array);
            Console.Out.WriteLine("K = " + k);
            return k;
        }
        private Fraction CalculateNum(Fraction[] partArray, Fraction k)
        { 
            var function = new NumFunction(partArray, _n, k);
            var num = function.Calculate();
            Console.Out.WriteLine("Num = " + num);
            return num;
        }
        private void FindBounds(Fraction num, Fraction k, out int answerI, out int answerJ)
        {
            answerI = 0;
            answerJ = 0;
            var sK = Util.CombinationsNumber(_n, k);
            var countElementsArray = Util.ConvertIntToArray2(sK);
            Console.Out.Write("S_k = " + sK + " =");
            foreach (var t in countElementsArray)
            {
                Console.Out.Write("2^" +t + "+");
            }
            Console.WriteLine();
            
            var len = countElementsArray.Length;
            
            for (var i = 0; i < len; ++i)
            {
                for (var j = 0; j < len; ++j)
                {
                    Console.Out.WriteLine("Iteration i = " + i + " j = " + j);
                    var leftSum = Sum(countElementsArray, i);
                    var rightSum = (Sum(countElementsArray, i) + (int) System.Math.Pow(2, j));
                    Console.Out.WriteLine("Проверка: " + leftSum + " < " + num + " < " + rightSum);
                    if ((Sum(countElementsArray, i) < num) &&
                        (num < (Sum(countElementsArray, i) + (int)System.Math.Pow(2, j))))
                    {
                        answerI = i;
                        answerJ = j;
                        Console.Out.WriteLine("Мы нашли индексы: i = " + answerI + 
                                              " j = " + answerJ);
                        return;
                    }
                    

                }
            }
        }
        private Fraction Sum(IReadOnlyList<Fraction> countElementsArray, int i)
        {
            Fraction sum = new Fraction(0);
            for (var r = 0; r < i; ++r)
            {
                sum = sum + countElementsArray[r] * (int) System.Math.Pow(2, r);
            }

            return sum;
        }

        private void AddCode(List<Fraction> code, Fraction num, int j)
        {
            Console.Write("Код блока: ");
            var array = Util.ConvertIntToArray2(num);
            for (var i = array.Length - j; i < array.Length; ++i)
            {
                code.Add(array[i]);
                Console.Out.Write(array[i]);
            }
        }
    }
}