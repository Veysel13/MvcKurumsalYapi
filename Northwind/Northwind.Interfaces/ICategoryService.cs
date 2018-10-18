using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Northwind.Entities;

namespace Northwind.Interfaces
{
    //service olarak yayına aldık
    [ServiceContract]
    public interface ICategoryService
    {
        [OperationContract]
        List<Category> GetAll();

       
    }
}
