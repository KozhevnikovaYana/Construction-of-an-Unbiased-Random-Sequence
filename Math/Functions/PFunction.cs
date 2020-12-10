using System;

namespace Math.Functions
{
    public class PFunction: IFunction
    {
        private readonly Fraction[] _x;
        private readonly Fraction _n;
        private readonly int _t;
        private readonly Fraction _k;
        public PFunction(Fraction[] x, Fraction n, int t, Fraction k)
        {
            _x = x;
            _n = n;
            _t = t;
            _k = k;
        }

        public Fraction Calculate()
        {
            //числитель 
            var numerator = Util.CombinationsNumber(_n - _t, _k - Util.MassiveSum(_x, _t));
            //знаменатель
            var denominator = Util.CombinationsNumber(_n - _t + 1, _k - Util.MassiveSum(_x, _t - 1));
            return numerator / denominator;
        }
    }
}