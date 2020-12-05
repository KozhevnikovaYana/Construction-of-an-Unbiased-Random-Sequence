namespace Math.Functions
{
    public class AlternativeNumFunction: IFunction
    {
        private int _n;
        private int[] _x;
        private int _k;
        public AlternativeNumFunction(int[] x, int n, int k)
        {
            _x = x;
            _n = n;
            _k = k;
        }
        public double Calculate()
        {
            double answer = 0;
            for (var t = 0; t < _n; ++t)
            {
                answer += Util.CombinationsNumber(_x[t] * _n - t - 1,
                    _k - Util.MassiveSum(_x, t));
            }

            return answer;
        }
    }
}