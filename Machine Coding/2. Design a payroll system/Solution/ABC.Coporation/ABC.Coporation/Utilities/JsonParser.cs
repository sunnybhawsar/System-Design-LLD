using ABC.Coporation.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC.Coporation.Utilities
{
    public class JsonParser
    {
        public static List<Employees> GetEmployees()
        {
            List<Employees> employees = new List<Employees>();

            try
            {
                // Parse json into list of employess
                using (StreamReader streamReader = new StreamReader(@"D:\Visual Studio WorkSpace\ABC.Coporation\ABC.Coporation\Utilities\attendance.json"))
                {
                    string jsonData = streamReader.ReadToEnd();
                    employees = JsonConvert.DeserializeObject<List<Employees>>(jsonData);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return employees;
        }
    }
}
