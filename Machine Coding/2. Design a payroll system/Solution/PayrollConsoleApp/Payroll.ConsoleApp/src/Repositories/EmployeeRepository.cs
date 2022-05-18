using Newtonsoft.Json;
using Payroll.ConsoleApp.src.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Payroll.ConsoleApp.src.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly string baseAddress = "http://34.198.81.140/";

        public async Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            var employees = new List<Employee>();
            try
            {
                using HttpClient httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri(baseAddress);
                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var res = await httpClient.GetAsync("attendance.json");
                if (res.IsSuccessStatusCode)
                {
                    employees = JsonConvert.DeserializeObject<IEnumerable<Employee>>(res.Content?.ReadAsStringAsync()?.Result)?.ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return employees;
        }
    }
}
