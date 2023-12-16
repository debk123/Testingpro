using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;
using DAL.Repo;
namespace UILayer.Controllers
{
    public class CarUIController : Controller
    {
        ICar Dser;

        public CarUIController()
        {
            Dser = new CarDataService();
        }

        // GET: CarUI
        public ActionResult ShowAllCars()
        {
            try
            {
                var res = Dser.ShowAllCar();

                return View("ShowAllCars",res);
            }
            catch(Exception ex)
            {
                TempData["err"] = ex.Message;
            }
            return View();
        }

        public ActionResult AddCar()
        {
            return View("AddCar");
        }

        [HttpPost]
        public ActionResult AddCar(Car NewCar)
        {
            try
            {
                int cnt = Dser.AddCar(NewCar);
                if (cnt > 0)
                {
                    return RedirectToAction("showallcars");
                }
                else
                {
                    return View();
                }
            }
            catch(Exception ex)
            {
                TempData["Err"] = ex.Message;
            }
            return View();
        }

        public ActionResult DeleteCar(int id)
        {
            try
            {
                int cnt = Dser.DeletCar(id);
                if (cnt > 0)
                {
                    return RedirectToAction("ShowAllCars");
                }
                else
                {
                    TempData["Err"] = "Car not Deleted";
                }
            }
            catch (Exception ex)
            {
                TempData["Err"] = ex.Message;
            }
            return RedirectToAction("ShowAllCars");
        }

        public ActionResult EditCar(int id)
        {
            try
            {
                Car ExCar = Dser.ShowCarById(id);
                if (ExCar!=null)
                {
                    return View("EditCar",ExCar);
                }
                else
                {
                    TempData["Err"] = "Car not found";
                }
            }
            catch (Exception ex)
            {
                TempData["Err"] = ex.Message;
            }
            return View();
        }

        public ActionResult ShowCarById(int id)
        {
            try
            {
                Car ExCar = Dser.ShowCarById(id);
                if (ExCar != null)
                {
                    return View(ExCar);
                }
                else
                {
                    TempData["Err"] = "Car not found";
                }
            }
            catch (Exception ex)
            {
                TempData["Err"] = ex.Message;
            }
            return View();
        }

        [HttpPost]
        public ActionResult EditCar(Car UpdCar)
        {
            try
            {
               int cnt = Dser.UpdateCar(UpdCar);
                if (cnt>0)
                {
                    return RedirectToAction("ShowAllCars");
                }
                else
                {
                    TempData["Err"] = "Car not updated";
                }
            }
            catch (Exception ex)
            {
                TempData["Err"] = ex.Message;
            }
            return View();
        }
    }
}