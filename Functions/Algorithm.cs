using System;
using System.Collections.Generic;
using System.Numerics;
using Functions.Functions;

namespace Functions
{
    public class Algorithm
    {
        private readonly BigInteger DEFAULT_N = 4;
        private Fraction _n;
        private Fraction[] _x;

        public Algorithm()
        {
            InitData();
        }

        private void InitData()
        {
            Console.Out.Write("Исходная последовательность: ");
            _x = Util.ConvertStringToArray(Console.In.ReadLine());
            _n = new Fraction(DEFAULT_N);
        }
     
        public void Run()
        {
            var code = new List<Fraction>();
            var startIndex = new Fraction(0);
            while (startIndex.GetNumerator() < (new BigInteger( _x.Length - 1)))
            {
                var destinationArray = CalculateArray(startIndex,0);
                var k = CalculateK(destinationArray);
                var num = CalculateNum(destinationArray, k);
                FindBounds(num, k, out var answerI, out var answerJ);
                AddCode(code, num, answerJ);
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
            var destinationArray = new Fraction[Util.ConvertBigIntegerToInt(_n.GetNumerator())];
            Array.Copy(_x,Util.ConvertBigIntegerToInt(sourceIndex.GetNumerator()), destinationArray, destinationIndex, 
                Util.ConvertBigIntegerToInt(_n.GetNumerator()));
            return destinationArray;
        }
        private Fraction CalculateK(IReadOnlyList<Fraction> array)
        {
            var k = Util.CountOnes(array);
            return k;
        }
        private Fraction CalculateNum(Fraction[] partArray, Fraction k)
        { 
            var function = new NumFunction(partArray, _n, k);
            var num = function.Calculate();
            return num;
        }
        private void FindBounds(Fraction num, Fraction k, out int answerI, out int answerJ)
        {
            answerI = 0;
            answerJ = 0;
            var sK = Util.CombinationsNumber(_n, k);
            var countElementsArray = Util.ConvertIntToArray2(sK);

            var len = countElementsArray.Length;
            
            for (var i = 0; i < len; ++i)
            {
                for (var j = 0; j < len; ++j)
                {
                    var leftSum = Sum(countElementsArray, i);
                    var rightSum = (Sum(countElementsArray, i) + (int) System.Math.Pow(2, j));
                    if ((leftSum < num) && (num < rightSum))
                    {
                        answerI = i;
                        answerJ = j;
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
            var array = Util.ConvertIntToArray2(num);
            for (var i = array.Length - j; i < array.Length; ++i)
            {
                code.Add(array[i]);
            }
        }
    }
}