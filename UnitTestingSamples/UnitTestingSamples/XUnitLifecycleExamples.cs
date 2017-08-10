using Demo;
using Xunit;

namespace UnitTestingSamples
{
    public partial class XUnit
    {
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

        [Fact]
        [Trait("Category", "MemoryCalculatorTests")]
        public void MemoryCalculatorDisposeTest()
        {
            //Act
            var result = memoryCalculator.Add(1, 2);

            //Assert
            Assert.Equal(result, 3);
        }

        [Fact]
        [Trait("Category", "MemoryCalculatorFixtureTests")]
        public void MemoryCalculatorFixtureTest1()
        {
            //Act
            var result = memoryCalculatorFixture.MemoryCalculator.Add(1, 2);

            //Assert
            Assert.Equal(result, 3);
        }

        [Fact]
        [Trait("Category", "MemoryCalculatorFixtureTests")]
        public void MemoryCalculatorFixtureTest2()
        {
            //Act
            var result = memoryCalculatorFixture.MemoryCalculator.Add(1, 2);

            //Assert
            Assert.Equal(result, 3);
        }

        [Fact]
        [Trait("Category", "MemoryCalculatorFixtureTests")]
        public void MemoryCalculatorFixtureTest3()
        {
            //Act
            var result = memoryCalculatorFixture.MemoryCalculator.Add(1, 2);

            //Assert
            Assert.Equal(result, 3);
        }
    }
}
