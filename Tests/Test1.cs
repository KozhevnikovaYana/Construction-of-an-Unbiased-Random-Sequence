using Math.Functions;
using NUnit.Framework;

namespace Tests
{
    public class Test1
    {
        int[] x = {1, 0, 0, 1};
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void QFunctionTest()
        {
            QFunction function = new QFunction(x, 4, 1, 2);
            Assert.AreEqual(1.0 / 2, function.Calculate());
            
            QFunction function1 = new QFunction(x, 4, 2, 2);
            Assert.AreEqual( 0, function1.Calculate());
            
            QFunction function2 = new QFunction(x, 4, 3, 2);
            Assert.AreEqual( 0, function2.Calculate());
            
            
            QFunction function3 = new QFunction(x, 4, 4, 2);
            Assert.AreEqual( 0, function3.Calculate());
        }
        
        [Test]
        public void PFunctionTest()
        {
            PFunction function = new PFunction(x, 4, 1, 2);
            Assert.AreEqual(1.0 / 2, function.Calculate());
            
            PFunction function1 = new PFunction(x, 4, 2, 2);
            Assert.AreEqual( 2.0 / 3, function1.Calculate());
        }
        [Test]
        public void RoFunctionTest()
        {
            int[] x = {1, 0, 0, 1};
            RoFunction function = new RoFunction(0, 1, 4, x, 2);
            Assert.AreEqual(1.0 / 2, function.Calculate());
            
            RoFunction function1 = new RoFunction(0, 2, 4, x, 2);
            Assert.AreEqual(2.0 / 3, function1.Calculate());
            
            RoFunction function2 = new RoFunction(0, 3, 4, x, 2);
            Assert.AreEqual(1.0 / 2, function2.Calculate());
            
            RoFunction function3 = new RoFunction(0, 4, 4, x, 2);
            Assert.AreEqual(1.0, function3.Calculate());
            
            
            RoFunction function4 = new RoFunction(1, 1, 4, x, 2);
            Assert.AreEqual(1.0 / 3, function4.Calculate());
            
            RoFunction function5 = new RoFunction(1, 2, 4, x, 2);
            Assert.AreEqual(1.0 / 2, function5.Calculate());
            
        }

        [Test]
        public void LambdaFunctionTest()
        {
            LamdaFunction function = new LamdaFunction(0, 1, 4, x, 2);
            Assert.AreEqual(1.0 / 2, function.Calculate());
            
            LamdaFunction function1 = new LamdaFunction(0, 2, 4, x, 2);
            Assert.AreEqual(0, function1.Calculate());
            
            LamdaFunction function2 = new LamdaFunction(0, 3, 4, x, 2);
            Assert.AreEqual(0, function2.Calculate());
            
            LamdaFunction function3 = new LamdaFunction(0, 4, 4, x, 2);
            Assert.AreEqual(0, function3.Calculate());
            
            LamdaFunction function4 = new LamdaFunction(1, 1, 4, x, 2);
            Assert.AreEqual(1.0 / 2, function4.Calculate());
            
            LamdaFunction function5 = new LamdaFunction(1, 2, 4, x, 2);
            Assert.AreEqual(0, function5.Calculate());
            
            LamdaFunction function6 = new LamdaFunction(2, 1, 4, x, 2);
            Assert.AreEqual(1.0 / 2, function6.Calculate());
        }
        [Test]
        public void NumFunctionTest()
        {
            NumFunction numFunction = new NumFunction(x, 4, 2);
            Assert.AreEqual(3, numFunction.Calculate());
        }
    }
}