using Microsoft.VisualStudio.TestTools.UnitTesting;
using Store.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Store.Teste.UI.Controllers
{
    [TestClass, TestCategory("Controllers/HomeController")]
    public class HomeControllerTest
    {
        //dado o HomeController
        [TestMethod]
        public void OMetodoIndexDeveraRetornarUmaView()
        {
            //arrange
            var homeController = new HomeController();

            //act
            var result = homeController.Index();

            //assert
            Assert.AreEqual(typeof(ViewResult), result.GetType());

        }
    }
}
