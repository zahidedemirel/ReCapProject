using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _car;
        public InMemoryCarDal()
        {
            //bilgiler veritabanından geliyormuş gibi
            _car = new List<Car>
            {
                new Car{ID=1,BrandID=1,ColorID=12, DailyPrice=1000, Description="skoda", ModelYear=new DateTime(2015) },
                new Car{ID=2,BrandID=10,ColorID=12, DailyPrice=1500, Description="Toyota", ModelYear=new DateTime(2019) },
                new Car{ID=3,BrandID=11,ColorID=15, DailyPrice=1700, Description="Mercedes", ModelYear=new DateTime(2020) }

            };
        }
        public void Add(Car car)
        {
            _car.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete;
            carToDelete = _car.SingleOrDefault(c=>car.ID==c.ID);

            _car.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _car;
        }

        public List<Car> GetAllId(int BrandID)
        {
            //where koşulu-- içindeki koşulu uyanları listeler
            return _car.Where(c=>c.BrandID==BrandID).ToList();
        }

        public void Update(Car car)
        {
            //gönderdiğim ürün İd Sine sahip olan listedeki ürünü bul
            Car carToUpdate;
            carToUpdate = _car.SingleOrDefault(c => car.ID == c.ID);
            carToUpdate.ColorID = car.ColorID;
            carToUpdate.BrandID = car.BrandID;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;
        }
    }
}
