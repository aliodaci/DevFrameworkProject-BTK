using DevFramework.Northwind.Entities.ComplexType;
using DevFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Northwind.Business.Abstarct
{
    public interface IUserService
    {
        User GetByUserNamePassword(string userName, string password);
        List<UserRoleItem> GetUserRoles(User user);
    }
}
