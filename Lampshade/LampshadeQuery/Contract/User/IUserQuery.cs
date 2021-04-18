using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LampshadeQuery.Contract.User
{
    public interface IUserQuery
    {
        UserQueryVM GetUserBy(string userName);
    }
}
