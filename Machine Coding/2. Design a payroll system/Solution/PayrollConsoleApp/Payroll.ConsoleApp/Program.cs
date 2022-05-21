using Payroll.ConsoleApp.src;
using Payroll.ConsoleApp.src.Repositories;
using System;
using System.Threading.Tasks;

namespace Payroll.ConsoleApp
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            IEmployeeRepository employeeRepository = new EmployeeRepository();
            var employees = await employeeRepository.GetEmployeesAsync();

            var payrollManager = new PayrollManager(employees, new DateTime(2020, 2, 1));
            payrollManager.CalculateTotalAmountOfSalary();
        }
    }
}
