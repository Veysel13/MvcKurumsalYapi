using System.ComponentModel.DataAnnotations;

namespace Northwind.Entities
{
    public class User
    {

        public string UserName { get; set; }
        [DataType(DataType.Password)]
        public string  Password { get; set; }
    }
}