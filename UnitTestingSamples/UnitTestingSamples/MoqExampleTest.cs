using System;
using System.Collections.Generic;
using System.Text;
using Demo.MoqClasses;
using Moq;
using Xunit;

namespace UnitTestingSamples
{
    public class MoqExampleTest
    {
        private readonly UserDataWorker userDataWorker;

        public MoqExampleTest()
        {
            // Arrange
            userDataWorker = new UserDataWorker();
        }

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
            mockedUser.VerifyAll();
        }

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
            mockedUser.Verify(x => x.InsertUserData(It.IsAny<SomeUserData>()), Times.Exactly(userDataList.Count));
        }

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
    }
}
