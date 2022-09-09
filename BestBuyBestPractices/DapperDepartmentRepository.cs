using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestBuyBestPractices
{
    internal class DapperDepartmentRepository : IDepartmentRepository
    {
        private readonly IDbConnection _connection;

        public DapperDepartmentRepository(IDbConnection connection)
        {
            _connection = connection;
        }
        //GetAllDepartments Method
        public IEnumerable<Department> GetAll()
        {
            return _connection.Query<Department>("Select * from Departments");
        }

        //InsertDepartment 
        public void InsertDepartment(string name)
        {
            _connection.Execute("");
        }
    }
}
