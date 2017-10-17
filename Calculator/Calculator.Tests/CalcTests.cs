using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Calculator.Tests
{
    [TestClass]
    public class CalcTests
    {
        //[AssemblyInitialize]
        //[ClassInitialize]
        //[TestInitialize]
        //[TestCleanup]
        //[ClassCleanup]
        //[AssemblyCleanup]

        [TestMethod]
        public void CanCreateInstance()
        {
            var calc = new Calc();
            Assert.IsNotNull(calc);
        }
        [TestMethod]
        public void Add_5_and_6_should_return_11()
        {
            // Arrange
            var calc = new Calc();

            // Act
            var result = calc.Add(5, 6);

            // Assert
            Assert.AreEqual(11, result);
        }
        [TestMethod]
        public void Add_0_and_0_should_return_0()
        {
            var calc = new Calc();

            var result = calc.Add(0, 0);

            Assert.AreEqual(0, result);
        }
        [TestMethod]
        public void Add_M9_and_M5_should_return_M14()
        {
            var calc = new Calc();

            var result = calc.Add(-9, -5);
            
            Assert.AreEqual(-14, result);
        }
        [TestMethod]
        [ExpectedException(typeof(OverflowException))]
        public void Add_MAX_and_1_should_throw_OverflowException()
        {
            var calc = new Calc();

            var result = calc.Add(int.MaxValue, 1);
        }
        [TestMethod]
        [ExpectedException(typeof(OverflowException))]
        public void Add_MIN_and_M1_should_throw_OverflowException()
        {
            var calc = new Calc();

            var result = calc.Add(int.MinValue, -1);
        }
        [TestMethod]
        public void Add_MAX_and_1_should_throw_OverflowException_workaround()
        {
            var calc = new Calc();

            try
            {
                calc.Add(int.MaxValue, 1);
                Assert.Fail("No OverflowException was thrown.");
            }
            catch (OverflowException)
            { /* Test pass! */ }
            catch (Exception)
            {
                Assert.Fail("Any other than OverflowException was thrown.");
            }
        }
    }
}
