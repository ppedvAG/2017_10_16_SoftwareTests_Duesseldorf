using NUnit.Framework;
using System;

namespace Calculator.TestsNUnit
{
    [TestFixture]
    public class CalcTests
    {
        //[SetUpFixture]

        //[OneTimeSetUp]
        //[SetUp]
        //[TearDown]
        //[OneTimeTearDown]

        [Test]
        public void Add_5_and_6_should_return_11()
        {
            var calc = new Calc();

            var result = calc.Add(5, 6);

            Assert.AreEqual(11, result);
        }
        [Test]
        public void Add_MAX_and_1_should_throw_OverflowException()
        {
            var calc = new Calc();

            Assert.Throws<OverflowException>(() => calc.Add(int.MaxValue, 1));
        }
        [TestCase(5, 6, 11)]
        [TestCase(7, 9, 16)]
        [TestCase(0, 0, 0)]
        [TestCase(50000, 3, 50003)]
        [TestCase(1, 1, 2)]
        public void Add_a_and_b_should_return_result(int a, int b, int exprectedResult)
        {
            var calc = new Calc();

            var result = calc.Add(a, b);

            Assert.AreEqual(exprectedResult, result);
            Assert.That(result, Is.EqualTo(exprectedResult));
        }
    }
}
