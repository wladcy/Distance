using Distance.Controllers;
using Distance.Models;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;

namespace DistanceTests.ControllersTests
{
    public class Tests
    {
        [Fact]
        public void GetAdress_WithAll_Parameters_Should_Return_FullAdress()
        {
            //Arrange
            CompanyViewModel Model = new CompanyViewModel();
            Model.FlatNumber = "22";
            Model.Street = "Hetmanska";
            Model.City = "Rzeszow";
            Model.ZipCode = "23-222";
            Model.HouseNumber = "1";
 
            PdfController controller = new PdfController();

            //Act
            var retval = controller.getAddress(Model);

            //Assert
            retval.Should().NotBeEmpty();
            retval.Should().Contain("Hetmanska 1/22\r\n23-222 Rzeszow");
        }

        [Fact]
        public void GetAdress_WithOut_Street_Parameter_Should_Return_Adress_WithoutStreet()
        {
            //Arrange
            CompanyViewModel Model = new CompanyViewModel();
            Model.FlatNumber = "22";
            Model.City = "Rzeszow";
            Model.ZipCode = "23-222";
            Model.HouseNumber = "1";

            PdfController controller = new PdfController();

            //Act
            var retval = controller.getAddress(Model);

            //Assert
            retval.Should().NotBeEmpty();
            retval.Should().Contain("1/22\r\n23-222 Rzeszow");
        }

        [Fact]
        public void GetAdress_WithOut_FlatNumber_Parameter_Should_Return_Adress_WithoutFlatNumber()
        {
            //Arrange
            CompanyViewModel Model = new CompanyViewModel();
            Model.Street = "Hetmanska";
            Model.City = "Rzeszow";
            Model.ZipCode = "23-222";
            Model.HouseNumber = "1";

            PdfController controller = new PdfController();

            //Act
            var retval = controller.getAddress(Model);

            //Assert
            retval.Should().NotBeEmpty();
            retval.Should().Contain("Hetmanska 1\r\n23-222 Rzeszow");
        }

        [Fact]
        public void GetAdress_WithOut_FlatNumber_And_Street_Parameter_Should_Return_ZipCode_City_HouseNumber()
        {
            //Arrange
            CompanyViewModel Model = new CompanyViewModel();
            Model.City = "Rzeszow";
            Model.ZipCode = "23-222";
            Model.HouseNumber = "1";

            PdfController controller = new PdfController();

            //Act
            var retval = controller.getAddress(Model);

            //Assert
            retval.Should().NotBeEmpty();
            retval.Should().Contain("23-222 Rzeszow, 1");
        }
    }
}
