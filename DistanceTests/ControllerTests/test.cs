using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using Moq;
using Xunit;

namespace DistanceTests.ControllerTests
{
    public class test
    {
        [Theory, AutoData]
        public void AddUser_Invoke_UserCreated_v1(string expectedLogin, string expectedName, string expectedSurname)
        {
            // Arrange
            var userContextMock = new Mock<UsersContext>();
            userContextMock.Setup(x => x.Users.Add(It.IsAny<User>())).Returns((User u) => u);

            var usersService = new UsersService(userContextMock.Object);

            // Act
            var user = usersService.AddUser(expectedLogin, expectedName, expectedSurname);

            // Assert
            Assert.Equal(expectedLogin, user.Login);
            Assert.Equal(expectedName, user.Name);
            Assert.Equal(expectedSurname, user.Surname);
            Assert.False(user.AccountLocked);

            userContextMock.Verify(x => x.SaveChanges(), Times.Once);
        }
    }
}
