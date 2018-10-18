using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.Dal.Abstract;
using Northwind.Entities;
using Northwind.Interfaces;

namespace Northwind.Bll.Concrete
{
    public class AuthanticationManager : IAuthenticationService
    {
        private IAuthenticationDal _authenticationDal;

        public AuthanticationManager(IAuthenticationDal authenticationDal)
        {
            _authenticationDal = authenticationDal;
        }
        public User Authenticate(User user)
        {
            return _authenticationDal.Authenticate(user);
        }
    }
}
