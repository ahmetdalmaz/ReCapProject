﻿using Business.Abstract;
using Business.Constants;
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

        public IResult Add(Car car)
        {
            if (car.Description.Length>2)
            {
                if (car.DailyPrice>0)
                {
                    _carDal.Add(car);                  
                    return new SuccessResult(Messages.CarAdded);
                }
                else
                {
                 
                    return new ErrorResult(Messages.CarPriceInvalid);
                }
            }

            else
            {
                
                return new ErrorResult(Messages.CarNameInvalid);
            }


        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }

        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour==20)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.CarsListed);

        }

        public IDataResult< List<Car>> GetAllByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == brandId));
            
        }

        public IDataResult< Car> GetById(int carId)
        {
            
             return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == carId));
        }

        public IDataResult< List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());

             
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
        }
    }
}