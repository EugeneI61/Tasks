using System.Linq;
using Task6.Models;

namespace Task6
{
    public class Config
    {
        public bool Check()
        {
            EmployeeContext db = new EmployeeContext();

            bool result = db.Employees.Count() < 5 ? true : false;

            return result;
        }
    }
}
