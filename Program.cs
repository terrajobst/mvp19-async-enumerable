using System;
using System.Threading.Tasks;

namespace iasyncenumerable
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var dataAccess = new DataAccess(Configuration.ConnectionString);

            await foreach (var employee in dataAccess.GetAllEmployeesAsync())
            {
                Console.WriteLine(employee.FullName);
            }   
        }
    }
}
