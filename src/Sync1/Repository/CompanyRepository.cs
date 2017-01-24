using System.Collections.Generic;
using System.Linq;
using Sync1.Contexto;
using Sync1.Model;

namespace Sync1.WebAPI.Repository
{
    public class CompanyRepository : ICompanyRepository
    {
        private CompanyContext db;
        public CompanyRepository(CompanyContext dbContext)
        {
            db = dbContext;
        }
        public bool Create(Employee objetoEmployee)
        {
            db.Employees.Add(new Employee() {
                FirstName = objetoEmployee.FirstName,
                LastName = objetoEmployee.LastName,
                ManagerID = objetoEmployee.Manager?.EmployeeID
            });
            db.SaveChanges();

            return true;
        }

        public Employee Get(int id)
        {
            return db.Employees.FirstOrDefault(c => c.EmployeeID == id);
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            return db.Employees;
        }

        public Employee Update(int id, Employee objetoEmployee)
        {
            var EmployeeAtual = db.Employees.FirstOrDefault(c => c.EmployeeID == id);
            EmployeeAtual.FirstName = objetoEmployee.FirstName;
            EmployeeAtual.LastName = objetoEmployee.LastName;
            db.SaveChanges();
            return EmployeeAtual;
        }

        public bool Delete(int id)
        {
            Employee deletedEmployee = db.Employees.FirstOrDefault(c => c.EmployeeID == id);
            if (deletedEmployee != null)
            {
                db.Employees.Remove(deletedEmployee);
                db.SaveChanges();
            }
            return (db.Employees.FirstOrDefault(c => c.EmployeeID == id) == null);
        }
    }
}
