
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car {Id=1,BrandId=1, ColorId=2, ModelYear=2014, DailyPrice=150, Description="müsait"},
                new Car {Id=2, BrandId=2, ColorId=2, ModelYear=2018, DailyPrice=700, Description="müsait değil"},
                new Car {Id=3, BrandId=1, ColorId=2, ModelYear=2017, DailyPrice=300, Description="müsait"},
                new Car {Id=4, BrandId=3, ColorId=1, ModelYear=2016, DailyPrice=250, Description="müsait"}

            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Add()
        {
            throw new NotImplementedException();
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(Car car)
        {
            return _cars.Where(c => c.Id == car.Id).ToList();
        }

        public List<Car> GetById()
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.ModelYear = car.ModelYear;
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
