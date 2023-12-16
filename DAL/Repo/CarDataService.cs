using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class CarDataService : ICar
    {
        DecDb23NewEntities db;
        public CarDataService()
        {
            db = new DecDb23NewEntities();
        }
        public int AddCar(Car NewCar)
        {
            try
            {
                Car cd=db.Cars.Add(NewCar);
                db.SaveChanges();

                if(cd!=null)
                {
                    return cd.cid;
                }
                else
                {
                    return 0;
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int DeletCar(int id)
        {
            try
            {
                Car ExCar = db.Cars.Find(id);
                if (ExCar != null)
                {
                    db.Cars.Remove(ExCar);
                    db.SaveChanges();
                    return ExCar.cid;
                }
                else
                {
                    return 0;
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<Car> ShowAllCar()
        {
            try
            {
                var res = db.Cars.ToList();

                if (res.Count >= 0)
                {
                    return res;
                }
                else
                {
                    return null;
                }
            }
             catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Car ShowCarById(int id)
        {
            try
            {
                Car ExCar = db.Cars.Find(id);
                if (ExCar != null)
                {
                    return ExCar;
                }
                else
                {
                    return null;
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int UpdateCar(Car UpdCar)
        {
            try
            {
                Car ExCar = db.Cars.Find(UpdCar.cid);
                if (ExCar != null)
                {
                    ExCar.cname = UpdCar.cname;
                    db.SaveChanges();
                    return UpdCar.cid;
                }
                
                else
                {
                    return 0;
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
