using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DAL;
using DAL.Repo;

namespace UILayer.Controllers
{
    public class CarWebApController : ApiController
    {
        ICar Dser;
        public CarWebApController()
        {
            Dser = new CarDataService();
        }

        [HttpGet]
        [Route("ShowAll")]
        public IHttpActionResult ShowAllCars()
        {
            try
            {
                var res = Dser.ShowAllCar();

                return Ok(res);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("ShowById")]
        public IHttpActionResult ShowById(int id)
        {
            try
            {
                var res = Dser.ShowCarById(id);

                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteCar")]
        public IHttpActionResult DeleteCar(int id)
        {
            try
            {
                var res = Dser.DeletCar(id);

                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
