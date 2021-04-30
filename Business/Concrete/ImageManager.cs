using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ImageManager : IImageService
    {
        IImageDal _imageDal;

        public ImageManager(IImageDal imageDal)
        {
            _imageDal = imageDal;
        }

        public IResult Add(IFormFile formFile, Image image)
        {
            IResult result = BusinessRules.Run(CheckIfImageLimitExceded(image.CarId - 1));
            if (result != null)
            {
                return result;
            }

            var imageResult = FileHelper.Upload(formFile);

            if (!imageResult.Success)
            {
                return new ErrorResult(imageResult.Message);
            }
            image.ImagePath = imageResult.Message;
            _imageDal.Add(image);
            return new SuccessResult(Messages.Added);

        }

        public IResult Delete(Image image)
        {
            _imageDal.Delete(image);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<Image> Get(int id)
        {
            return new SuccessDataResult<Image>(_imageDal.Get(i => i.ImageId == id));
        }

        public IDataResult<List<Image>> GetAll()
        {
            return new SuccessDataResult<List<Image>>(_imageDal.GetAll());
        }

        public IDataResult<List<Image>> GetByCarId(int id)
        {
            return new SuccessDataResult<List<Image>>(_imageDal.GetAll(i => i.CarId == id));
        }

        public IResult Update(IFormFile formFile, Image image)
        {
            BusinessRules.Run(CheckIfImageLimitExceded(image.ImageId));
            if (CheckIfImageLimitExceded(image.ImageId).Success)
            {
                _imageDal.Add(image);
                return new SuccessResult(Messages.Added);
            }
            return new ErrorResult();
        }


        private IResult CheckIfImageLimitExceded(int imageId)
        {
            var result = _imageDal.GetAll();
            if (result.Count == 5)
            {
                return new ErrorResult(Messages.ImageLimitExceded);
            }
            return new SuccessResult();
        }
    }
}
