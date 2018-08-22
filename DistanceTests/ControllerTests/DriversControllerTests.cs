using System;
using System.Web.Mvc;
using Distance.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DistanceTests.ControllerTests
{
    [TestClass]
    public class DriversControllerTests
    {
        [TestMethod]
        public void IfNotFoundDriverInDatabaseReturnNull()
        {
            var controller = new DriversController();
            var result = controller.Details(null) as ViewResult;

            Assert.IsNull(result);
        }
    }
}
