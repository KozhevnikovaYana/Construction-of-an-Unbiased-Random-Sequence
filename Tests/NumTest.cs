using System.Numerics;
using Functions;
using Functions.Functions;
using NUnit.Framework;

namespace Tests
{
    public class NumTest
    {
        [Test]
        public void NumFunctionTest0()
        {
            Fraction[] x = {new Fraction(new BigInteger(0)), new Fraction(new BigInteger(0)), new Fraction(new BigInteger(1)), new Fraction(new BigInteger(1))};
            var n = new Fraction(new BigInteger(4));
            var k = new Fraction(new BigInteger(2));
            var numFunction = new NumFunction(x, n, k);
            Assert.AreEqual(new Fraction(0), numFunction.Calculate());
        }
        [Test]
        public void NumFunctionTest1()
        {
            Fraction[] x = {new Fraction(0), new Fraction(1), new Fraction(0), new Fraction(1)};
            var n = new Fraction(4);
            var k = new Fraction(2);
            var numFunction = new NumFunction(x, n, k);
            Assert.AreEqual(new Fraction(1), numFunction.Calculate());
        }
        [Test]
        public void NumFunctionTest2()
        {
            Fraction[] x = {new Fraction(0), new Fraction(1), new Fraction(1), new Fraction(0)};
            var n = new Fraction(4);
            var k = new Fraction(2);
            var numFunction = new NumFunction(x, n, k);
            Assert.AreEqual(new Fraction(2), numFunction.Calculate());
        }
        [Test]
        public void NumFunctionTest3()
        {
            Fraction[] x = {new Fraction(1), new Fraction(0), new Fraction(0), new Fraction(1)};
            var n = new Fraction(4);
            var k = new Fraction(2);
            var numFunction = new NumFunction(x, n, k);
            Assert.AreEqual(new Fraction(3), numFunction.Calculate()); 
        }
        [Test]
        public void NumFunctionTest4()
        {
            Fraction[] x = {new Fraction(1), new Fraction(0), new Fraction(1), new Fraction(0)};
            var n = new Fraction(4);
            var k = new Fraction(2);
            var numFunction = new NumFunction(x, n, k);
            Assert.AreEqual(new Fraction(4), numFunction.Calculate()); 
        }
        [Test]
        public void NumFunctionTest5()
        {
            Fraction[] x = {new Fraction(1), new Fraction(1), new Fraction(0), new Fraction(0)};
            var n = new Fraction(4);
            var k = new Fraction(2);
            var numFunction = new NumFunction(x, n, k);
            Assert.AreEqual(new Fraction(5), numFunction.Calculate());
        }
    }
}