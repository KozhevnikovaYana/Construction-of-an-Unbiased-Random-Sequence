using Math.Functions;

namespace Math.Functions
{
    public class NumFunction: IFunction
    {
        private readonly Fraction[] _x;
        private readonly Fraction _n;
        private readonly Fraction _k;
        public NumFunction(Fraction[] x, Fraction n, Fraction k)
        {
            _x = x;
            _n = n;
            _k = k;
        }

        public Fraction Calculate()
        { 
            var lamdaFunction = new LamdaFunction((int)System.Math.Log2(_n.GetNumerator()), 1, _n, _x, _k);
            return lamdaFunction.Calculate() * Util.CombinationsNumber(_n, _k);
        }
    }
}