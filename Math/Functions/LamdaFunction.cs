namespace Math.Functions
{
    public class LamdaFunction: IFunction
    {
        private readonly Fraction[] _x;
        private readonly int _s;
        private readonly int _t;
        private readonly Fraction _n;
        private readonly Fraction _k;
        public LamdaFunction(int s, int t, Fraction n, Fraction[] x, Fraction k)
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

            var lamdaFunction1 = new LamdaFunction(_s - 1, 2 * _t - 1, _n, _x, _k);
            var lamdaFunction2 = new LamdaFunction(_s - 1, 2 * _t, _n, _x, _k);
            var roFunction = new RoFunction(_s - 1, 2 * _t - 1, _n, _x, _k);
            return lamdaFunction1.Calculate() + lamdaFunction2.Calculate() * roFunction.Calculate();
            /*  return (new LamdaFunction(_s - 1, 2 * _t - 1, _n, _x, _k).Calculate()) +
                      ((new LamdaFunction(_s - 1, 2 *_t, _n, _x, _k).Calculate()) *
                       (new RoFunction(_s - 1, 2 *_t, _n, _x, _k).Calculate()));*/
        }

        // case if s = 0;
        private Fraction StartValueCalculate()
        {
            var qFunction = new QFunction(_x, _n, _t, _k);
            return qFunction.Calculate();
        }
    }
}