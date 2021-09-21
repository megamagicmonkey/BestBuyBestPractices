using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestBuyBestPractices
{
    interface IDepartmentsRepository
    {
        IEnumerable<Departments> GetAllDepartments();

        public void InsertDepartment(string newDepartmentName);
        

    }

}
