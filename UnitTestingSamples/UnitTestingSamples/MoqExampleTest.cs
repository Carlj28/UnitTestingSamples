using System;
using System.Collections.Generic;
using System.Linq;
using Demo.MoqClasses;
using Moq;
using Xunit;

namespace UnitTestingSamples
{
    /// <summary>
    /// https://github.com/Moq/moq4/wiki/Quickstart
    /// </summary>
    public class MoqExampleTest
    {
        private readonly UserDataWorker userDataWorker;

        public MoqExampleTest()
        {
            // Arrange
            userDataWorker = new UserDataWorker();
        }

        /// <summary>
        /// Sample usage of Setup and Return methods
        /// </summary>
        [Fact]
        [Trait("Category", "MoqUserTests")]
        public void UpdateUser()
        {
            // Arrange
            var mockedUser = new Mock<IUserData>();

            mockedUser.Setup(x => x.GetUserData()).Returns("Jan Kowalski 1991/05/05");

            //Act
            var response = userDataWorker.UpdateUser(mockedUser.Object);

            //Assert
            Assert.Equal(response, "Jan Kowalski 1991/05/05");

            //Check if method GetUserData was called
            mockedUser.VerifyAll();
        }

        /// <summary>
        /// Sample usage of Setup and Return methods with any parameter, using It
        /// </summary>
        [Fact]
        [Trait("Category", "MoqUserTests")]
        public void SampleVerification()
        {
            // Arrange
            var mockedUser = new Mock<IUserData>();

            mockedUser.Setup(x => x.GetUserData(It.IsAny<string>())).Returns("Jan Kowalski 1991/05/05");

            //Act
            var response = userDataWorker.UpdateUser(mockedUser.Object, string.Empty);

            //Assert
            Assert.Equal(response, "Jan Kowalski 1991/05/05");
            mockedUser.VerifyAll();
        }

        /// <summary>
        /// Sample Verify usage
        /// </summary>
        [Fact]
        [Trait("Category", "MoqUserTests")]
        public void SampleVerificationCd()
        {
            // Arrange
            var mockedUser = new Mock<IUserData>();

            //Act
            userDataWorker.InsertData(mockedUser.Object, new SomeUserData());

            //Assert
            mockedUser.Verify(x => x.InsertUserData(It.IsAny<SomeUserData>()));
        }

        /// <summary>
        /// Verify if method InsertUserData was called userDataList.Count times
        /// </summary>
        [Fact]
        [Trait("Category", "MoqUserTests")]
        public void SampleVerificationTimes()
        {
            // Arrange
            var mockedUser = new Mock<IUserData>();
            var userDataList = new List<SomeUserData> {new SomeUserData(), new SomeUserData(), new SomeUserData()};

            //Act
            userDataWorker.InsertData(mockedUser.Object, userDataList);

            //Assert
            //Verify if method InsertUserData was called userDataList.Count times
            mockedUser.Verify(x => x.InsertUserData(It.IsAny<SomeUserData>()), Times.Exactly(userDataList.Count));
        }

        /// <summary>
        /// Handle throws example
        /// </summary>
        [Fact]
        [Trait("Category", "MoqUserTests")]
        public void SampleVerificationNull()
        {
            // Arrange
            var mockedUser = new Mock<IUserData>();
            mockedUser.Setup(x => x.GetUserData(It.IsAny<string>())).Returns(() => null);

            //Act
            var result = Assert.Throws<ArgumentException>(() => userDataWorker.UpdateUser(mockedUser.Object, string.Empty));

            //Assert
            mockedUser.VerifyAll();
        }

        /// <summary>
        /// Set method to throw exception and handle it
        /// </summary>
        [Fact]
        [Trait("Category", "MoqUserTests")]
        public void SampleThrows()
        {
            // Arrange
            var mockedUser = new Mock<IUserData>();
            mockedUser.Setup(x => x.GetUserData(It.IsAny<string>())).Throws<ArgumentException>();

            //Act
            var result = Assert.Throws<ArgumentException>(() => userDataWorker.UpdateUser(mockedUser.Object, string.Empty));

            //Assert
            mockedUser.VerifyAll();
        }

        /// <summary>
        /// Sample callback
        /// </summary>
        [Fact]
        [Trait("Category", "MoqUserTests")]
        public void SampleCallback()
        {
            // Arrange
            var mockedUser = new Mock<IUserData>();
            var id = 1;
            mockedUser.Setup(x => x.UpdateAndGetNewId(It.IsAny<SomeUserData>())).Returns(() => id).Callback(() => id++);

            var userDataList = new List<IUserData> { mockedUser.Object, mockedUser.Object, mockedUser.Object };

            //Act
            var response = userDataWorker.GetIds(userDataList, new SomeUserData());

            //Assert
            mockedUser.VerifyAll();
            Assert.True(response.Count() == 3);
            Assert.True(response.Contains(1));
            Assert.True(response.Contains(2));
            Assert.True(response.Contains(3));
        }
    }
}
