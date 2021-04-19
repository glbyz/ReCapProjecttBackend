using Core.Utilities;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IImageService
    {
        IResult Add(IFormFile formFile, Image image);
        IResult Delete(Image image);
        IResult Update(IFormFile formFile ,Image image);
        IDataResult<List<Image>> GetAll();
        IDataResult <List<Image>> GetByCarId(int id);
        IDataResult <Image> Get(int id);
    }
}
