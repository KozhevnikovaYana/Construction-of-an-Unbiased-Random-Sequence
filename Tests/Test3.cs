using Math.Functions;
using NUnit.Framework;

namespace Tests
{
    public class Test3
    {
        int[] x = {0, 1, 1, 0};
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void QFunctionTest()
        {
            var function = new QFunction(x, 4, 1, 2);
            Assert.AreEqual(0, function.Calculate());
            
            var function1 = new QFunction(x, 4, 2, 2);
            Assert.AreEqual( 1.0 / 3, function1.Calculate());
            
            var function2 = new QFunction(x, 4, 3, 2);
            Assert.AreEqual( 1.0 / 2, function2.Calculate());
            
            
            var function3 = new QFunction(x, 4, 4, 2);
            Assert.AreEqual( 0, function3.Calculate());
        }
        
        [Test]
        public void PFunctionTest()
        {
            var function = new PFunction(x, 4, 1, 2);
            Assert.AreEqual(1.0 / 2, function.Calculate());
            
            var function1 = new PFunction(x, 4, 2, 2);
            Assert.AreEqual( 2.0 / 3, function1.Calculate());
            
            var function2 = new PFunction(x, 4, 3, 2);
            Assert.AreEqual(1.0 / 2, function2.Calculate());
            
            var function3 = new PFunction(x, 4, 4, 2);
            Assert.AreEqual( 1, function3.Calculate());
        }
        [Test]
        public void RoFunctionTest()
        {
            var function = new RoFunction(0, 1, 4, x, 2);
            Assert.AreEqual(1.0 / 2, function.Calculate());
            
            var function1 = new RoFunction(0, 2, 4, x, 2);
            Assert.AreEqual(2.0 / 3, function1.Calculate());
            
            var function2 = new RoFunction(0, 3, 4, x, 2);
            Assert.AreEqual(1.0 / 2, function2.Calculate());
            
            var function3 = new RoFunction(0, 4, 4, x, 2);
            Assert.AreEqual(1.0, function3.Calculate());
            
            
            var function4 = new RoFunction(1, 1, 4, x, 2);
            Assert.AreEqual(1.0 / 3, function4.Calculate());
            
            var function5 = new RoFunction(1, 2, 4, x, 2);
            Assert.AreEqual(1.0 / 2, function5.Calculate());
            
        }

        [Test]
        public void LambdaFunctionTest()
        {
            var function = new LamdaFunction(0, 1, 4, x, 2);
            Assert.AreEqual(0, function.Calculate());
            
            var function1 = new LamdaFunction(0, 2, 4, x, 2);
            Assert.AreEqual(1.0 / 3, function1.Calculate());
            
            var function2 = new LamdaFunction(0, 3, 4, x, 2);
            Assert.AreEqual(1.0 / 2, function2.Calculate());
            
            var function3 = new LamdaFunction(0, 4, 4, x, 2);
            Assert.AreEqual(0, function3.Calculate());
            
            var function4 = new LamdaFunction(1, 1, 4, x, 2);
            Assert.AreEqual(2.0 / 9, function4.Calculate());
            
            var function5 = new LamdaFunction(1, 2, 4, x, 2);
            Assert.AreEqual(1.0 / 2, function5.Calculate());
            
            var function6 = new LamdaFunction(2, 1, 4, x, 2);
            Assert.AreEqual(17.0 / 36, function6.Calculate());
        }
        [Test]
        public void NumFunctionTest()
        {
            var numFunction = new NumFunction(x, 4, 2);
            Assert.AreEqual(17.0 / 6, numFunction.Calculate());
        }
    }
}