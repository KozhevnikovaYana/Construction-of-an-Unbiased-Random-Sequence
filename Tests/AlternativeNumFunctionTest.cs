using Math.Functions;
using NUnit.Framework;

namespace Tests
{
    public class AlternativeNumFunctionTest
    {
        [Test]
        public void NumFunctionTest0()
        {
            int[] x = {0, 0, 1, 1};
            AlternativeNumFunction numFunction = new AlternativeNumFunction(x, 4, 2);
            Assert.AreEqual(0, numFunction.Calculate());
        }
        [Test]
        public void NumFunctionTest1()
        {
            int[] x = {0, 1, 0, 1};
            AlternativeNumFunction numFunction = new AlternativeNumFunction(x, 4, 2);
            Assert.AreEqual(1, numFunction.Calculate());
        }
        [Test]
        public void NumFunctionTest2()
        {
            int[] x = {0, 1, 1, 0};
            AlternativeNumFunction numFunction = new AlternativeNumFunction(x, 4, 2);
            Assert.AreEqual(2, numFunction.Calculate());
        }
        [Test]
        public void NumFunctionTest3()
        {
            int[] x = {1, 0, 0, 1};
            AlternativeNumFunction numFunction = new AlternativeNumFunction(x, 4, 2);
            Assert.AreEqual(3, numFunction.Calculate());
        }
        [Test]
        public void NumFunctionTest4()
        {
            int[] x = {1, 0, 1, 0};
            AlternativeNumFunction numFunction = new AlternativeNumFunction(x, 4, 2);
            Assert.AreEqual(4, numFunction.Calculate());
        }
        [Test]
        public void NumFunctionTest5()
        {
            int[] x = {1, 1, 0, 0};
            AlternativeNumFunction numFunction = new AlternativeNumFunction(x, 4, 2);
            Assert.AreEqual(5, numFunction.Calculate());
        }
    }
}