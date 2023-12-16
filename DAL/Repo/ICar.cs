using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public interface ICar
    {
        int AddCar(Car NewCar);
        Car ShowCarById(int id);

        IEnumerable<Car> ShowAllCar();
        int UpdateCar(Car UpdCar);

        int DeletCar(int id);
      
    }
}
