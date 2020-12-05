using Math.Functions;

namespace Math.Functions
{
    public class NumFunction: IFunction
    {
        private readonly int[] _x;
        private readonly int _n;
        private readonly int _k;
        public NumFunction(int[] x, int n, int k)
        {
            _x = x;
            _n = n;
            _k = k;
        }

        public double Calculate()
        { 
            LamdaFunction lamdaFunction = new LamdaFunction((int)System.Math.Log2(_n), 1, _n, _x, _k);
            return lamdaFunction.Calculate() * Util.CombinationsNumber(_n, _k);
        }
    }
}