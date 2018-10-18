using System.ServiceModel;
using Northwind.Entities;

namespace Northwind.Interfaces
{
    [ServiceContract]
    public interface IAuthenticationService
    {
        [OperationContract]
        User Authenticate(User user);
    }
}