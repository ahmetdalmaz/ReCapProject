using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
   public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
           
         _carDal.Add(car);                  
          return new SuccessResult(Messages.CarAdded);
                           

        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour==21)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.CarsListed);

        }

        public IDataResult< List<Car>> GetAllByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == brandId));
            
        }

        private IDataResult<Car> CheckCarId(int carId) 
        {
            var result = _carDal.Get(c => c.Id == carId);

            if (result!=null)
            {
                return new SuccessDataResult<Car>(result);
            }
            return new ErrorDataResult<Car>();
        
        }

        public IDataResult< Car> GetById(int carId)
        {
            IDataResult<Car> result = BusinessRules.Run<Car>(CheckCarId(carId));
         
            return result;
        }

        public IDataResult< List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());

             
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);

        }
    }
}
