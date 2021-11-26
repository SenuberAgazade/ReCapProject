using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarImagesService
    {
        IDataResult<List<CarImage>> GetAll();
        IDataResult<List<CarImage>> GetByCarId(int carId);
        IDataResult<CarImage> GetByImageId(int imageId);
        IResult Add(IFormFile file,CarImage carImages);
        IResult Update(IFormFile file,CarImage carImages);
        IResult Delete(CarImage carImages);
    }
}
