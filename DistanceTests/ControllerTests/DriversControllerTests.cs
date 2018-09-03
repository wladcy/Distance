using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Web.Mvc;
using AutoFixture.Xunit2;
using Distance.ControllerInteraces;
using Distance.Controllers;
using Distance.Models;
using FluentAssertions;
using Moq;
using Xunit;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace DistanceTests.ControllerTests
{
    public class DriversControllerTests
    {
        [Theory, AutoData]
        public void ValidId_ShouldReturn_UserName(string Id, ApplicationUser user)
        {
            //Arrange
            var driverContextMock = new Mock<ApplicationDbContext>();
            var databaseControlerMock = new Mock<IDatabaseControler>();
            databaseControlerMock.Setup(d => d.GetUserById(Id))
                .Returns(user);

            var driverService = new DriversController(driverContextMock.Object, databaseControlerMock.Object);

            //Act
            var driver = DriversController.GetUserNameById(Id);

            //Assert
            driver.Should().NotBeNull();
            ((string)driver).Should().Contain("FirstName");
            ((string)driver).Should().Contain("LastName");
        }

        [Theory, AutoData]
        public void InValidId_ShouldReturn_Null(string Id, ApplicationUser user)
        {
            //Arrange
            var driverContextMock = new Mock<ApplicationDbContext>();
            var databaseControlerMock = new Mock<IDatabaseControler>();
            databaseControlerMock.Setup(d => d.GetUserById(Id))
                .Returns(user);

            var driverService = new DriversController(driverContextMock.Object, databaseControlerMock.Object);

            //Act
            var driver = DriversController.GetUserNameById(null);

            //Assert
            driver.Should().BeNull();
        }

        [Theory, AutoData]
        public void IfUserNotContainAdministrator_Return_False(string Id, ApplicationUser user)
        {
            //Arrange
            var driverContextMock = new Mock<ApplicationDbContext>();
            var databaseControlerMock = new Mock<IDatabaseControler>();

            databaseControlerMock.Setup(d => d.GetUserById(Id))
                .Returns(user);

            databaseControlerMock.Setup(d => d.GetUserRoles(user))
                .Returns(new List<string>());

            var driverService = new DriversController(driverContextMock.Object, databaseControlerMock.Object);

            //Act
            var driver = DriversController.IsAdministrator(Id);

            //Assert
            driver.Should().BeFalse();
        }

        [Theory, AutoData]
        public void IfUserContainAdministrator_Return_True(string Id, ApplicationUser user)
        {
            //Arrange
            var driverContextMock = new Mock<ApplicationDbContext>();
            var databaseControlerMock = new Mock<IDatabaseControler>();

            databaseControlerMock.Setup(d => d.GetUserById(Id))
                .Returns(user);

            databaseControlerMock.Setup(d => d.GetUserRoles(user))
                .Returns(new List<string>(new string[]
                {
                    "ADMINISTRATOR"
                }));

            var driverService = new DriversController(driverContextMock.Object, databaseControlerMock.Object);

            //Act
            var driver = DriversController.IsAdministrator(Id);

            //Assert
            driver.Should().BeTrue();
        }
    }
}
