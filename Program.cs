using System;
using System.Linq;
using System.Threading.Tasks;

namespace iasyncenumerable
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var dataAccess = new DataAccess(Configuration.ConnectionString);

            var employess = dataAccess.GetAllEmployeesAsync()
                                      .Where(e => e.EmployeeId > 3)
                                      .Select(e => e.FullName);

            await foreach (var employee in employess)
            {
                Console.WriteLine(employee);
            }   
        }
    }
}
