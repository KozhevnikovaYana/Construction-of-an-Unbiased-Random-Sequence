using Math.Functions;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void PFunctionTest()
        {
            int[] x = {1, 0, 0, 1};
            Assert.Pass();
        }
        
        [Test]
        public void QFunctionTest()
        {
            int[] x = {1, 0, 0, 1};
            PFunction function = new PFunction(x, 4, 1, 2);
            Assert.AreEqual(function.Calculate(), 1 / 2);
        }
        [Test]
        public void RoFunctionTest()
        {
            int[] x = {1, 0, 0, 1};
            Assert.Pass();
        }
        
        [Test]
        public void LambdaFunctionTest()
        {
            int[] x = {1, 0, 0, 1};
            Assert.Pass();
        }
        
    }
}