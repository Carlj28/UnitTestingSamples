using Demo;
using Xunit;

namespace UnitTestingSamples
{
    /// <summary>
    /// https://xunit.github.io/docs/getting-started-desktop.html
    /// </summary>
    public partial class XUnit
    {
        /// <summary>
        /// Sample testOutput usage
        /// </summary>
        [Fact]
        [Trait("Category", "WriteLineTests")]
        public void ConsoleWritelineExample()
        {
            //Console.Writeline don't show anything in output so we need to use ITestOutputHelper

            //Act
            //Console.WriteLine("Acting creation of car object from factory!");
            testOutput.WriteLine("Acting creation of car object from factory!");
            var result = carFactory.Create(false);

            //Assert
            //Console.WriteLine("Checking type of result!");
            testOutput.WriteLine("Checking type of result!");
            var ford = Assert.IsAssignableFrom<Car>(result);

            //Console.WriteLine("Geting name from result!");
            testOutput.WriteLine("Geting name from result!");
            Assert.Equal(ford.GetName(), "Ford");
        }

        /// <summary>
        /// Sample dispose test
        /// </summary>
        [Fact]
        [Trait("Category", "MemoryCalculatorTests")]
        public void MemoryCalculatorDisposeTest()
        {
            //Act
            var result = memoryCalculator.Add(1, 2);

            //Assert
            Assert.Equal(result, 3);
        }

        /// <summary>
        /// Sample IClassFixture
        /// </summary>
        [Fact]
        [Trait("Category", "MemoryCalculatorFixtureTests")]
        public void MemoryCalculatorFixtureTest1()
        {
            //Act
            var result = memoryCalculatorFixture.MemoryCalculator.Add(1, 2);

            //Assert
            Assert.Equal(result, 3);
        }

        /// <summary>
        /// Sample IClassFixture
        /// </summary>
        [Fact]
        [Trait("Category", "MemoryCalculatorFixtureTests")]
        public void MemoryCalculatorFixtureTest2()
        {
            //Act
            var result = memoryCalculatorFixture.MemoryCalculator.Add(1, 2);

            //Assert
            Assert.Equal(result, 3);
        }

        /// <summary>
        /// Sample IClassFixture
        /// </summary>
        [Fact]
        [Trait("Category", "MemoryCalculatorFixtureTests")]
        public void MemoryCalculatorFixtureTest3()
        {
            //Act
            var result = memoryCalculatorFixture.MemoryCalculator.Add(1, 2);

            //Assert
            Assert.Equal(result, 3);
        }

        /// <summary>
        /// Sample of Theory and InlineData
        /// </summary>
        /// <param name="value"></param>
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [Trait("Category", "TheoryTests")]
        public void TheorySample(int value)
        {
            //Act
            var response = calc.IsGreaterCheck(value, 0);

            //Assert
            Assert.True(response);
        }

    }
}
