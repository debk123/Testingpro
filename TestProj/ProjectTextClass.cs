using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Repo;
using UILayer.Controllers;
using NUnit.Framework;
using NUnit;
using System.Web.Mvc;

namespace TestProj
{
    [TestFixture]
    public class ProjectTextClass
    {
        CarUIController c;
        public ProjectTextClass()
        {
            c = new CarUIController();
        }

        [Test]
        public void ShowAllView()
        {
            var res = c.ShowAllCars() as ViewResult;
            Assert.That(res.ViewName.ToString(), Is.EqualTo("ShowAllCars"));
        }

        [Test]
        public void AddCarView()
        {
            var res = c.AddCar() as ViewResult;
            Assert.That(res.ViewName.ToString(), Is.EqualTo("AddCar"));
        }

        [Test]
        public void EditCarView()
        {
            var res = c.EditCar(113) as ViewResult;
            Assert.That(res.ViewName.ToString(), Is.EqualTo("EditCar"));
        }

        [Test]
        public void DeleteCarView()
        {
           
           var res = c.DeleteCar(200) as RedirectToRouteResult;
           Assert.That(res.RouteValues["Action"], Is.EqualTo("ShowAllCars"));
        }
    }
}
