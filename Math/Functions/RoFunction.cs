namespace Math.Functions
{
    public class RoFunction: IFunction
    {
        private readonly Fraction[] _x;
        private readonly int _s;
        private readonly int _t;
        private readonly Fraction _n;
        private readonly Fraction _k;
        public RoFunction(int s, int t, Fraction n, Fraction[] x, Fraction k)
        {
            _x = x;
            _s = s;
            _t = t;
            _n = n;
            _k = k;
        }

        public Fraction Calculate()
        {
            if (_s == 0)
            {
                return StartValueCalculate();
            }
            var roFunction1 = new RoFunction(_s - 1, 2 * _t - 1, _n, _x, _k);
            var roFunction2 = new RoFunction(_s - 1, 2 * _t, _n, _x, _k);
            return roFunction1.Calculate() * roFunction2.Calculate();
        }

        // case if s = 0;
        private Fraction StartValueCalculate()
        {
            var pFunction = new PFunction(_x, _n, _t, _k);
            return pFunction.Calculate();
        }
    }
}