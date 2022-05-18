using Payroll.ConsoleApp.src.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Payroll.ConsoleApp.src.Repositories
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetEmployeesAsync();
    }
}