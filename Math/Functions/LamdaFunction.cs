namespace Math.Functions
{
    public class LamdaFunction: IFunction
    {
        private readonly int[] _x;
        private readonly int _s;
        private readonly int _t;
        private readonly int _n;
        private readonly int _k;
        public LamdaFunction(int s, int t, int n, int[] x, int k)
        {
            _x = x;
            _s = s;
            _t = t;
            _n = n;
            _k = k;
        }
        
        public double Calculate()
        {
            if (_s == 0)
            {
                return StartValueCalculate();
            }
            return (new LamdaFunction(_s - 1, 2 * _t - 1, _n, _x, _k).Calculate()) +
                   ((new LamdaFunction(_s - 1, 2 *_t, _n, _x, _k).Calculate()) *
                    (new RoFunction(_s - 1, 2 *_t, _n, _x, _k).Calculate()));
        }

        // case if s = 0;
        private double StartValueCalculate()
        {
            var qFunction = new QFunction(_x, _n, _t, _k);
            return qFunction.Calculate();
        }
    }
}