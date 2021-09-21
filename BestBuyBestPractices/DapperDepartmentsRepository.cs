using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestBuyBestPractices
{
    class DapperDepartmentsRepository : IDepartmentsRepository
    {
        private readonly IDbConnection _connection;
        //Constructor
        public DapperDepartmentsRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Departments> GetAllDepartments()
        {
            return _connection.Query<Departments>("SELECT * FROM Departments;");
        }

        public void InsertDepartment(string newDepartmentName)
        {
            _connection.Execute("INSERT INTO DEPARTMENTS (Name) VALUES (@departmentName);",
            new { departmentName = newDepartmentName });
        }

    }
}
