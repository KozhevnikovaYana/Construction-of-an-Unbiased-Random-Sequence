using System;

namespace Fuctions
{
    public class BernoulliSource
    {
        private double _probability;
        private int _n;

        public BernoulliSource(double probability, int n)
        {
            _probability = probability;
            _n = n;
        }
        private void ReadParameters()
        {
            Console.Write("Вероятность появления события p: "); 
            _probability = double.Parse(Console.ReadLine() ?? string.Empty);

            Console.Write("Количество случайных величин n: ");
            _n = int.Parse(Console.ReadLine() ?? string.Empty);

        }

        private double GetRandomNumber()
        {
            Random random = new Random(); 
            return random.NextDouble();
        }

        private int GenerateElementSequence()
        {
            var nextRandomNumber = GetRandomNumber();
            return nextRandomNumber < _probability ? 1 : 0;
        }

        public int[] Run()
        {
            ReadParameters();
            var x = new int[_n];
            for (var i = 0; i < _n; i++)
            {
                x[i] = GenerateElementSequence();
                Console.WriteLine("x[{0}] = {1}", i + 1, x[i]) ;
            }
            return x;
        }
    }
}