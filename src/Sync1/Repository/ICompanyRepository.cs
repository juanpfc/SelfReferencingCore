using System.Collections.Generic;
using Sync1.Model;

namespace Sync1.WebAPI.Repository
{

    public interface ICompanyRepository
    {
        bool Create(Employee objetoNoticia);
        bool Delete(int id);
        IEnumerable<Employee> GetAllEmployee();
        Employee Get(int id);
        Employee Update(int id, Employee objetoNoticia);
    }
}
