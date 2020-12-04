namespace Math.Functions
{
    public class QFunction
    {
        private readonly int[] _x;
        private readonly int _n;
        private readonly int _t;
        private readonly int _k;
        public QFunction(int[] x, int n, int t, int k)
        {
            _x = x;
            _n = n;
            _t = t;
            _k = k;
        }

        public double Calculate()
        {
            //числитель 
            var numberator = Util.CombinationsNumber(_n - 1, _k - Util.MassiveSum(_x, _t));
            //знаменатель
            var denominator = Util.CombinationsNumber(_n - _t + 1, _k - Util.MassiveSum(_x, _t));
            return _x[_t - 1] *numberator / denominator;
        }
    }
}