using ABC.Coporation.Model;
using ABC.Coporation.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC.Coporation.Src
{
    // Sunny Bhawsar
    public class Calculation
    {
        public static void CalculateTotalAmount()
        {
            // Get list of employees from json file
            var employees = JsonParser.GetEmployees();

            var desiredDate = Convert.ToDateTime("01-Feb-2020");
            Decimal totalAmount = 0;
            Decimal maleSalary = 0;
            Decimal femaleSalary = 0;
            Decimal bonus = 0;

            // Get applicable employees details of desired month (Feb 2020)
            employees = employees.Where(e => e.calculate == "Y" && e.date > desiredDate).ToList();

            foreach(var employee in employees)
            {
                if (employee.designation == "Worker")
                {
                    if(employee.total_hours > 8)
                    {
                        totalAmount += employee.per_day_salary * 2;
                        
                        if (employee.gender == "Male")
                            maleSalary += employee.per_day_salary * 2;
                        else
                            femaleSalary += employee.per_day_salary * 2;
                    }
                    else if (employee.total_hours >= 4 && employee.total_hours < 8)
                    {
                        totalAmount += employee.per_day_salary / 2;

                        if (employee.gender == "Male")
                            maleSalary += employee.per_day_salary / 2;
                        else
                            femaleSalary += employee.per_day_salary / 2;
                    }
                }
                else  // Non Workers
                {
                    if (employee.weekday <= 5) // Skipping the weekends for non workers
                    {
                        if (employee.total_hours >= 8)
                        {
                            totalAmount += employee.per_day_salary;

                            if (employee.gender == "Male")
                                maleSalary += employee.per_day_salary;
                            else
                                femaleSalary += employee.per_day_salary;
                        }
                        else if (employee.total_hours >= 4 && employee.total_hours < 8)
                        {
                            totalAmount += employee.per_day_salary / 2;

                            if (employee.gender == "Male")
                                maleSalary += employee.per_day_salary / 2;
                            else
                                femaleSalary += employee.per_day_salary / 2;
                        }
                    }
                }
            }

            if (maleSalary < femaleSalary)
                bonus = (maleSalary / 100);
            else
                bonus = (femaleSalary / 100);

            totalAmount += bonus;
            Decimal basicSalary = maleSalary + femaleSalary;

            Console.WriteLine("Basic Salary: " + basicSalary);
            Console.WriteLine("Bonus: " + bonus);
            Console.WriteLine("Total Salary: " + totalAmount);  // Final Amount : 4681912.5
        }
    }
}
