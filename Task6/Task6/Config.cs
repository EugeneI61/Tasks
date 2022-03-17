using System.Linq;
using Task6.Models;

namespace Task6
{
    public class Config
    {
        public bool Check()
        {
            EmployeeContext db = new EmployeeContext();
            var count = db.Employees.Count();

            if (count > 4)
            {
                return false;
            }
            return true;
        }
    }
}
