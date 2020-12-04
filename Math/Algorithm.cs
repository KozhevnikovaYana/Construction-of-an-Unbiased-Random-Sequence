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
        private int[] x;
        private readonly BernoulliSource _bernoulliSource;

        public Algorithm()
        {
            Console.Out.Write("Введите N:");
            _n = int.Parse(Console.In.ReadLine() ?? DefaultN);
            _bernoulliSource = new BernoulliSource(DefaultProbability, _n);
        }

        public void Run()
        {
            x = _bernoulliSource.Run();
            var k = x.Count(t => t == 1);
            var function = new NumFunction(x, _n, k);
            function.Calculate();
        }
        
    }
}