using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using DAL;
using DAL.Repo;
using NUnit.Framework;

namespace TestProj
{
    [TestFixture]
    public class DatabaseTestClass
    {
        ICar CarSer;

        public DatabaseTestClass()
        {
            CarSer = new CarDataService();
        }
        [Test]
        public void AddCarTest()
        {
            Car newcar = new Car();

            newcar.cid = 115;
            newcar.cname = "md12";

            var obj = CarSer.AddCar(newcar);

            Assert.That(115, Is.EqualTo(newcar.cid));
        }

        [Test]
        public void ShowCarTest()
        {

            var obj = CarSer.ShowAllCar();

            Assert.That(obj.Count, Is.GreaterThanOrEqualTo(0));
        }

        [Test]
        public void UpdateCarTest()
        {
            Car updCar = new Car();
            updCar.cid = 115;
            updCar.cname = "updatedcar";
           
            var obj = CarSer.UpdateCar(updCar);
            

            Assert.That(obj, Is.GreaterThanOrEqualTo(1));
        }

    }
}
