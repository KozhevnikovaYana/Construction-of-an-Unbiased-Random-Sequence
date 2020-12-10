using Math;
using Math.Functions;
using NUnit.Framework;

namespace Tests
{
    public class Test1
    {
        Fraction[] x = {new Fraction(1), new Fraction(0), new Fraction(0), new Fraction(1)};
        Fraction n = new Fraction(4);
        Fraction k = new Fraction(2);
        [Test]
        public void QFunctionTest()
        {
            var function = new QFunction(x, n, 1, k);
            Assert.AreEqual(new Fraction(1, 2), function.Calculate());
            
            var function1 = new QFunction(x, n, 2, k);
            Assert.AreEqual( new Fraction(0), function1.Calculate());
            
            var function2 = new QFunction(x, n, 3, k);
            Assert.AreEqual( new Fraction(0), function2.Calculate());
            
            
            var function3 = new QFunction(x, n, 4, k);
            Assert.AreEqual( new Fraction(0), function3.Calculate());
        }
        
        [Test]
        public void PFunctionTest()
        {
            var function = new PFunction(x, n, 1, k);
            Assert.AreEqual(new Fraction(1,2), function.Calculate());
            
            var function1 = new PFunction(x, n, 2, k);
            Assert.AreEqual( new Fraction(2,3), function1.Calculate());
        }
        [Test]
        public void RoFunctionTest()
        {
            var function = new RoFunction(0, 1, n, x, k);
            Assert.AreEqual(new Fraction(1,2), function.Calculate());
            
            var function1 = new RoFunction(0, 2, n, x, k);
            Assert.AreEqual(new Fraction(2,3), function1.Calculate());
            
            var function2 = new RoFunction(0, 3, n, x, k);
            Assert.AreEqual(new Fraction(1,2), function2.Calculate());
            
            var function3 = new RoFunction(0, 4, n, x, k);
            Assert.AreEqual(new Fraction(1), function3.Calculate());
            
            var function4 = new RoFunction(1, 1, n, x, k);
            Assert.AreEqual(new Fraction(1,3), function4.Calculate());
            
            var function5 = new RoFunction(1, 2, n, x, k);
            Assert.AreEqual(new Fraction(1,2), function5.Calculate());
            
        }

        [Test]
        public void LambdaFunctionTest()
        {
            var function = new LamdaFunction(0, 1, n, x, k);
            Assert.AreEqual(new Fraction(1, 2), function.Calculate());
            
            var function1 = new LamdaFunction(0, 2, n, x, k);
            Assert.AreEqual(new Fraction(0), function1.Calculate());
            
            var function2 = new LamdaFunction(0, 3, n, x, k);
            Assert.AreEqual(new Fraction(0), function2.Calculate());
            
            var function3 = new LamdaFunction(0, 4, n, x, k);
            Assert.AreEqual(new Fraction(0), function3.Calculate());
            
            var function4 = new LamdaFunction(1, 1, n, x, k);
            Assert.AreEqual(new Fraction(1, 2), function4.Calculate());
            
            var function5 = new LamdaFunction(1, 2, n, x, k);
            Assert.AreEqual(new Fraction(0), function5.Calculate());
            
            var function6 = new LamdaFunction(2, 1, n, x, k);
            Assert.AreEqual(new Fraction(1, 2), function6.Calculate());
        }
        [Test]
        public void NumFunctionTest()
        {
            NumFunction numFunction = new NumFunction(x, n, k);
            Assert.AreEqual(new Fraction(3), numFunction.Calculate());
        }
    }
}