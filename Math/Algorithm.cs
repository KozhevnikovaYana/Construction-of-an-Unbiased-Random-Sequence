using System;
using System.Collections.Generic;
using Math.Functions;

namespace Math
{
    public class Algorithm
    {
        private int _n;
        private int[] _x;

        public Algorithm()
        {
            InitData();
        }

        private void InitData()
        {
            Console.Out.Write("Введите последовательность: ");
            _x = Util.ConvertStringToArray(Console.In.ReadLine());
            Console.Out.Write("Введите N: ");
            _n = int.Parse(Console.In.ReadLine() ?? "4");
        }
     
        public void Run()
        {
            var code = new List<int>();
            int startIndex = 0;
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
                Console.Out.Write(t);
            }
        }

        private void AddCode(List<int> code, int num, int j)
        {
            Console.Write("Код блока: ");
            var array = Util.ConvertIntToArray2(num);
            for (var i = array.Length  - j; i < array.Length; ++i)
            {
                code.Add(array[i]);
                Console.Out.Write(array[i]);
            }
        }
        public int[] CalculateArray(int sourceIndex, int destinationIndex)
        {
            var destinationArray = new int[_n];
            Array.Copy(_x, sourceIndex, destinationArray, destinationIndex, _n);
            Console.Out.Write("Блок = ");
            for (var i = 0; i < _n; ++i)
            {
                Console.Out.Write(destinationArray[i]);
            }
            Console.WriteLine();
            return destinationArray;
        }

        private int CalculateK(IReadOnlyList<int> array)
        {
            var k = Util.CountOnes(array);
            Console.Out.WriteLine("K = " + k);
            return k;
        }
        private int CalculateNum(int[] partArray, int k)
        { 
           /* var function = new NumFunction(partArray, _n, k);
            var num =(int)System.Math.Round(function.Calculate());*/
            var function = new AlternativeNumFunction(partArray, _n, k);
            var num =(int)System.Math.Round(function.Calculate());
            Console.Out.WriteLine("Num = " + num);
            return num;
        }
        private void FindBounds(int num, int k, out int answerI, out int answerJ)
        {
            answerI = 0;
            answerJ = 0;
            var sK = (int)Util.CombinationsNumber(_n, k);
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
                    var rightSum = (Sum(countElementsArray, i) + System.Math.Pow(2, j));
                    Console.Out.WriteLine("Проверка: " + leftSum + " < " + num + " < " + rightSum);
                    if ((Sum(countElementsArray, i) < num) &&
                        (num < (Sum(countElementsArray, i) + System.Math.Pow(2, j))))
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

        private double Sum(IReadOnlyList<int> countElementsArray, int i)
        {
            double sum = 0;
            for (var r = 0; r < i; ++r)
            {
                sum += countElementsArray[r] * System.Math.Pow(2, r);
            }

            return sum;
        }
    }
}