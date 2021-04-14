using System;
using Entities.Concrete;
using System.Collections.Generic;
using System.Text;
using Core.Utilities;

namespace Business.Abstract
{
    public interface IColorService
    {
        IResult Add(Color color);
        IResult Update(Color color);
        IResult Delete(Color color);
        IDataResult<List<Color>> GetAll();
        IDataResult<Color> GetById(int colorid);

    }
}
