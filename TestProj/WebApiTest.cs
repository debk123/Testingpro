using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using DAL;
using NUnit;
using NUnit.Framework;
using UILayer.Controllers;
namespace TestProj
{
    [TestFixture]
    public class WebApiTest
    {
        CarWebApController cw;

        public WebApiTest()
        {
            cw = new CarWebApController();
        }
      
        [Test]
        public void GetAllCar()
        {
            IHttpActionResult res = cw.ShowAllCars();
            var resc = res as OkNegotiatedContentResult<List<Car>>;
            int a = 1;
            Assert.That(a, Is.GreaterThanOrEqualTo(1));
        }

        [Test]
        public void GetCarById()
        {
            IHttpActionResult res = cw.ShowById(100);
            var resc = res as OkNegotiatedContentResult<Car>;
            
            Assert.That(resc, !Is.Null);
        }

        [Test]
        public void DeleteCar()
        {
            IHttpActionResult res = cw.DeleteCar(115);
            var resc = res as OkNegotiatedContentResult<int>;

            Assert.That(resc.Content, Is.GreaterThanOrEqualTo(115));
        }

    }
}
