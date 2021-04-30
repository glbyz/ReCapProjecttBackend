using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, ReCapContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context= new ReCapContext())
            {
                var result = from oc in context.OperationClaims
                             join usOC in context.UserOperationClaims
                                  on oc.Id equals usOC.OperationClaimId
                             where usOC.UserId == user.Id
                             select new OperationClaim
                             {Id = oc.Id, Name = oc.Name};
                return result.ToList();
            }
        }
    }
}
