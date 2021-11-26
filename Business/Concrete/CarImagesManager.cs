using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarImagesManager : ICarImagesService
    {
        ICarImagesDal _carImagesDal;
        IFileHelper _fileHelper;

        public CarImagesManager(ICarImagesDal carImagesDal, IFileHelper fileHelper)
        {
            _carImagesDal = carImagesDal;
            _fileHelper = fileHelper;
        }

        public IResult Add(IFormFile file,CarImage carImages)
        {
            IResult result=BusinessRules.Run(CheckIfCarImagesOfCarLimitExceeded(carImages.CarId));
            if (result != null)
            {
                return result;
            }

            carImages.ImagePath = _fileHelper.Upload(file, PathConstants.ImagesPath);
            carImages.Date = DateTime.Now;
            _carImagesDal.Add(carImages);

            return new SuccessResult(Messages.MessageAdded);
        }

        private IResult CheckIfCarImagesOfCarLimitExceeded(int carId)
        {
            var result = _carImagesDal.GetAll(ci => ci.CarId == carId).Count;

            if (result > 5)
            {
                return new ErrorResult(Messages.CarImagesOfCarLimitExceeded);
            }

            return new SuccessResult();
        }

        public IResult Delete(CarImage carImages)
        {
            _fileHelper.Delete(PathConstants.ImagesPath + carImages.ImagePath);
            _carImagesDal.Delete(carImages);

            return new SuccessResult(Messages.MessageDeleted);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>( _carImagesDal.GetAll(),  Messages.MessageListed);           
        }

        public IResult Update(IFormFile file,CarImage carImages)
        {
            carImages.ImagePath = _fileHelper.Update(file, PathConstants.ImagesPath + carImages.ImagePath, PathConstants.ImagesPath);
            _carImagesDal.Update(carImages);

            return new SuccessResult(Messages.MessageUpdated);
        }

        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            return new SuccessDataResult<List<CarImage>>(_carImagesDal.GetAll(ci=>ci.CarId == carId), Messages.MessageListed);
        }

        public IDataResult<CarImage> GetByImageId(int imageId)
        {
            return new SuccessDataResult<CarImage>(_carImagesDal.Get(ci=>ci.Id == imageId), Messages.MessageListed);
        }
    }
}
