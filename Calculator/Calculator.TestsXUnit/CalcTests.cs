using Shouldly;
using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace Calculator.TestsXUnit
{
    public class CalcTests
    {
        public CalcTests()
        {
            // Setup | Initialize
        }
        ~CalcTests()
        {
            // Teardown | Cleanup
        }

        [Fact]
        public void CanCreateInstance() => Assert.NotNull(new Calc());
        [Fact]
        public void Add_5_and_6_should_return_11()
        {
            var calc = new Calc();

            var result = calc.Add(5, 6);

            Assert.Equal(11, result);
        }
        [Fact]
        public void Add_MAX_and_1_should_throw_OverflowException()
        {
            var calc = new Calc();

            Assert.Throws<OverflowException>(() => calc.Add(int.MaxValue, 1));
        }
        [Theory]
        [InlineData(5, 6, 11)]
        [InlineData(7, 9, 16)]
        [InlineData(0, 0, 0)]
        [InlineData(50000, 3, 50003)]
        [InlineData(1, 1, 2)]
        public void Add_a_and_b_should_return_result(int a, int b, int exprectedResult)
        {
            var calc = new Calc();

            var result = calc.Add(a, b);

            Assert.Equal(exprectedResult, result);
        }
        [Theory]
        [ClassData(typeof(TestDataService))]
        public void Add_a_and_b_should_return_result_classData(int a, int b, int expectedResult)
        {
            var calc = new Calc();

            var result = calc.Add(a, b);

            result.ShouldBe(expectedResult);
        }
        [Fact]
        public void Add_5_and_6_should_return_11_shouldly()
        {
            var calc = new Calc();

            var result = calc.Add(5, 6);

            result.ShouldBe(11);
        }

        private class TestDataService : IEnumerable<object[]>
        {
            public IEnumerable<object[]> Data => new[]
            {
                new object[] { 1, 2, 3 },
                new object[] {0, 0, 0}
            };

            public IEnumerator<object[]> GetEnumerator() => Data.GetEnumerator();
            IEnumerator IEnumerable.GetEnumerator() => Data.GetEnumerator();
        }
    }
}
