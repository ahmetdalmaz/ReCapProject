using Business.Abstract;
using Core.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _CarImageDal;
        ICarService _carService;

        public CarImageManager(ICarImageDal carImageDal, ICarService carService)
        {
            _CarImageDal = carImageDal;
            _carService = carService;
        }

        public IResult Add(IFormFile file,CarImage carImage)
        {
            BusinessRules.Run(CheckCarImageCount(carImage.CarId));

            carImage.ImagePath = FileHelper.Add(file);         
            _CarImageDal.Add(carImage);
            return new SuccessResult();
         
        }

      
        public IResult Delete(CarImage carImage)
        {
            FileHelper.Delete((_CarImageDal.Get(c => c.Id == carImage.Id).ImagePath));
            _CarImageDal.Delete(carImage);
            return new SuccessResult();
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_CarImageDal.GetAll());
        }

        private IResult CheckCarImageCount(int carId) 
        {
            var result = _CarImageDal.GetAll(c => c.CarId == carId).Count;
            if (result<5)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        
        
        }
        
        private IDataResult<List<CarImage>> CheckIfCarImageExists(int carId) 
        {
              IDataResult<Car> result = _carService.GetById(carId);
           

            if (result==null)
            {
                string path = Environment.CurrentDirectory + @"\wwwroot\Uploads\default.jpg";
                List<CarImage> carImages = _CarImageDal.GetAll(c => c.CarId == carId);
                if (!carImages.Any())
                {
                    List<CarImage> carImage = new List<CarImage>();
                    carImage.Add(new CarImage { CarId = carId, Date = DateTime.Now, ImagePath = path });
                    return new SuccessDataResult<List<CarImage>>(carImage);


                }
                return new SuccessDataResult<List<CarImage>>(carImages);

            }
            return new ErrorDataResult<List<CarImage>>();

            
                                    
        }
       

        public IResult Update(IFormFile file, CarImage carImage)
        {           
            carImage.ImagePath = FileHelper.Update(_CarImageDal.Get(c => c.Id == carImage.Id).ImagePath, file);
            _CarImageDal.Update(carImage);
            return new SuccessResult();
        }

        public IDataResult<CarImage> Get(CarImage carImage)
        {
            

            return new SuccessDataResult<CarImage>(carImage);

        }

        IDataResult<List<CarImage>> ICarImageService.Get(CarImage carImage)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<CarImage>> GetImagesByCarId(int carId)
        {
            IDataResult<List<CarImage>> dataResult = CheckIfCarImageExists(carId);

            return dataResult;

        }
    }
}
