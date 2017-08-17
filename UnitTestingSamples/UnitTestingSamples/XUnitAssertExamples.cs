using System;
using Demo;
using Xunit;
using Xunit.Abstractions;

namespace UnitTestingSamples
{
    /// <summary>
    /// https://xunit.github.io/docs/getting-started-desktop.html
    /// </summary>
    //Trait can be on class definition level so all test in this class will be in specific category 
    //[Trait("Category", "CalculatorTests")]
    public partial class XUnit : IDisposable, IClassFixture<MemoryCalculatorFixture>
    {
        private readonly Calculator calc;
        private readonly StringWorker stringWorker;
        private readonly CollectionGenerator collectionGenerator;
        private readonly RandomGenerator randomGenerator;
        private readonly CarFactory carFactory;
        private readonly ITestOutputHelper testOutput;
        private readonly MemoryCalculator memoryCalculator;
        private readonly MemoryCalculatorFixture memoryCalculatorFixture;

        public XUnit(ITestOutputHelper testOutput, MemoryCalculatorFixture calculatorFixture)
        {
            //Arrange
            calc = new Calculator();
            stringWorker = new StringWorker();
            collectionGenerator = new CollectionGenerator();
            randomGenerator = new RandomGenerator();
            carFactory = new CarFactory();
            this.testOutput = testOutput;
            memoryCalculator = new MemoryCalculator();

            memoryCalculatorFixture = calculatorFixture;
            memoryCalculatorFixture.MemoryCalculator.ClearData();

            this.testOutput.WriteLine("Hello from constructor!");
        }

        /// <summary>
        /// Sample Assert.Throws
        /// </summary>
        [Fact]
        [Trait("Category", "CalculatorTests")]
        public void DivideByZeroThrow()
        {
            //Arrange
            var divideBy = 0;

            var result = 0;

            //Act
            Assert.Throws<DivideByZeroException>(() => { result = 8 / divideBy; });
        }

        /// <summary>
        /// Sample Assert.Equal
        /// </summary>
        [Fact]
        [Trait("Category", "CalculatorTests")]
        public void DivideInts()
        {
            //Act
            var result = calc.Divide(4, 2);

            //Assert
            Assert.Equal(result, 2);
        }

        /// <summary>
        /// Sample Assert.NotEqual
        /// </summary>
        [Fact]
        [Trait("Category", "CalculatorTests")]
        public void AddDoublesNotEqual()
        {
            //Act
            var result = calc.Add(1.1, 2.2);

            //Assert
            Assert.NotEqual(result, 3.3);
        }

        /// <summary>
        /// Sample Assert.Equal with precision set
        /// </summary>
        [Fact]
        [Trait("Category", "CalculatorTests")]
        public void AddDoubles()
        {
            //Act
            var result = calc.Add(1.1, 2.2);

            //Assert
            Assert.Equal(result, 3.3, 1);
        }

        /// <summary>
        /// Sample Assert.Equal
        /// </summary>
        [Fact]
        [Trait("Category", "StringTests")]
        public void ConcatenateStrings()
        {
            //Act
            var result = stringWorker.ConcatenateStrings("Jan", "Kowalski");

            //Assert
            Assert.Equal(result, "Jan Kowalski");
        }

        /// <summary>
        /// Sample Assert.Contains
        /// </summary>
        [Fact]
        [Trait("Category", "StringTests")]
        public void ConcatenateStringsContains()
        {
            //Act
            var result = stringWorker.ConcatenateStrings("Jan", "Kowalski");

            //Assert
            Assert.Contains("Jan", result);
        }

        /// <summary>
        /// Sample Assert.StartsWith
        /// </summary>
        [Fact]
        [Trait("Category", "StringTests")]
        public void ConcatenateStringsStartWith()
        {
            //Act
            var result = stringWorker.ConcatenateStrings("Jan", "Kowalski");

            //Assert
            Assert.StartsWith("Jan", result);
        }

        /// <summary>
        /// Sample Assert.EndsWith
        /// </summary>
        [Fact]
        [Trait("Category", "StringTests")]
        public void ConcatenateStringsEndsWith()
        {
            //Act
            var result = stringWorker.ConcatenateStrings("Jan", "Kowalski");

            //Assert
            Assert.EndsWith("Kowalski", result);
        }

        /// <summary>
        /// Sample Assert.Matches
        /// </summary>
        [Fact]
        [Trait("Category", "StringTests")]
        public void ConcatenateStringsMatches()
        {
            //Act
            var result = stringWorker.ConcatenateStrings("Jan", "Kowalski");

            //Assert
            Assert.Matches("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+", result);
        }

        /// <summary>
        /// Sample Assert.False
        /// </summary>
        [Fact]
        [Trait("Category", "StringTests")]
        public void ConcatenateStringsIsNotNull()
        {
            //Act
            var result = stringWorker.ConcatenateStrings("Jan", "Kowalski");

            //Assert
            Assert.False(String.IsNullOrEmpty(result));
        }

        /// <summary>
        /// Sample Assert.Null
        /// </summary>
        [Fact]
        [Trait("Category", "StringTests")]
        public void ConcatenateStringsIsNull()
        {
            //Act
            var result = stringWorker.ConcatenateStrings(null, "Kowalski");

            //Assert
            Assert.Null(result);
        }

        /// <summary>
        /// Sample Assert.True
        /// </summary>
        [Fact]
        [Trait("Category", "CalculatorTests")]
        public void CalculatorIsGreaterTest()
        {
            //Act
            var result = calc.IsGreaterCheck(2, 1);

            //Assert
            Assert.True(result);
        }

        /// <summary>
        /// Sample Assert.All
        /// </summary>
        [Fact]
        [Trait("Category", "CollectionTests")]
        public void CollectionGeneratorNotNullOrEmpty()
        {
            //Act
            var result = collectionGenerator.GetNames();

            //Assert
            Assert.All(result, name => { Assert.False(String.IsNullOrEmpty(name)); });
        }

        /// <summary>
        /// Sample Assert.Contains
        /// </summary>
        [Fact]
        [Trait("Category", "CollectionTests")]
        public void CollectionGeneratorContains()
        {
            //Act
            var result = collectionGenerator.GetNames();

            //Assert
            Assert.Contains("Jan Kowalski", result);
        }

        /// <summary>
        /// Sample Assert.DoesNotContain
        /// </summary>
        [Fact]
        [Trait("Category", "CollectionTests")]
        public void CollectionGeneratorDontContains()
        {
            //Act
            var result = collectionGenerator.GetNames();

            //Assert
            Assert.DoesNotContain("Adam Kowalski", result);
        }

        /// <summary>
        /// Sample Assert.Contains
        /// </summary>
        [Fact]
        [Trait("Category", "CollectionTests")]
        public void CollectionGeneratorAtLeastOne()
        {
            //Act
            var result = collectionGenerator.GetNames();

            //Assert
            Assert.Contains(result, name => name.Contains("Jan"));
        }

        /// <summary>
        /// Sample Assert.InRange
        /// </summary>
        [Fact]
        [Trait("Category", "RandomTests")]
        public void RandomInRange()
        {
            //Act
            var result = randomGenerator.GetRandomInt();

            //Assert
            Assert.InRange(result, 1, 100);
        }

        /// <summary>
        /// Sample Assert.IsType
        /// </summary>
        [Fact]
        [Trait("Category", "TypeTests")]
        public void IsTypeFiat()
        {
            //Act
            var result = carFactory.Create(true);

            //Assert
            var fiat = Assert.IsType<Fiat>(result);
            Assert.Equal(fiat.GetName(), "Fiat");
        }

        /// <summary>
        /// Sample Assert.IsType
        /// </summary>
        [Fact]
        [Trait("Category", "TypeTests")]
        public void IsTypeFord()
        {
            //Act
            var result = carFactory.Create(false);

            //Assert
            var ford = Assert.IsType<Ford>(result);
            Assert.Equal(ford.GetName(), "Ford");
        }

        /// <summary>
        /// Sample Assert.IsAssignableFrom
        /// </summary>
        [Fact]
        [Trait("Category", "TypeTests")]
        public void IsAssignableType()
        {
            //Act
            var result = carFactory.Create(false);

            //Assert
            var ford = Assert.IsAssignableFrom<Car>(result);
            Assert.Equal(ford.GetName(), "Ford");
        }

        /// <summary>
        /// Dispose memory calculator
        /// </summary>
        public void Dispose()
        {
            testOutput.WriteLine("Disposing memory calculator!");
            memoryCalculator?.Dispose();
        }
    }
}
