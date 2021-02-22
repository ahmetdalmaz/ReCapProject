using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IResult Add(Car car);
        void Update(Car car);
        void Delete(Car car);
       IDataResult< List<Car>> GetAll();
       IDataResult< List<Car>> GetAllByBrandId(int brandId);
       IDataResult< List<CarDetailDto>> GetCarDetails();
       IDataResult< Car> GetById(int carId);

       
    }
}
