using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {

            var result = CheckReturnDate(rental.CarId);

            if (!result.Success) 
            {
                return result;
            }       
           _rentalDal.Add(rental);
            return result;
           
        }

        public IResult CheckReturnDate(int carId)
        {
          var result= _rentalDal.Get(c => c.ReturnDate == null && c.CarId == carId);
            if (result!=null)
            {
                return new ErrorResult(Messages.RentalAddedError);
            }
           
             return new SuccessResult(Messages.RentalAdded);
            
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult();
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

       

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult();
        }

        public IResult UpdateReturnDate(int Id)
        {
            var result = _rentalDal.Get(r => r.Id == Id);
            if (result.ReturnDate!=null)
            {
                return new ErrorResult(Messages.RentalReturnDateError);
            }
            result.ReturnDate = DateTime.Now;
            _rentalDal.Update(result);
            return new SuccessResult(Messages.RentalReturnDateUpdated);

        }
    }
}
