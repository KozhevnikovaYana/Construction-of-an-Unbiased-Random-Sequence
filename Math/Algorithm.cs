using System;
using System.Linq;
using Math.Functions;

namespace Math
{
    public class Algorithm
    {
        private const double DefaultProbability = 0.3;
        private const string DefaultN = "4";
        private int _n;
        private int[] _x;
        private readonly BernoulliSource _bernoulliSource;

        public Algorithm()
        {
            InitData();
        }

        private void InitData()
        {
            Console.Out.Write("Введите последовательность: ");
            _x = ConvertStringToArray(Console.In.ReadLine());
            Console.Out.WriteLine();
            Console.Out.Write("Введите N: ");
            _n = int.Parse(Console.In.ReadLine());
        }
        private static int[] ConvertStringToArray(string str)
        {
            var charArray = str.ToCharArray();
            var intArray = new int[charArray.Length];
            for (var i = 0; i < intArray.Length; ++i)
            {
                intArray[i] = charArray[i] - '0';
            }
            return intArray;
        }
        public void Run()
        {
            int[] partArray = new int[_n];
            Array.Copy(_x, 0, partArray, 0, _n);
            var function = new NumFunction(partArray, _n, Util.CountOnes(partArray));
            Console.Out.WriteLine(function.Calculate());
        }
        
    }
}