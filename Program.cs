using System;

namespace iasyncenumerable
{
    class Program
    {
        static void Main(string[] args)
        {
            var dataAccess = new DataAccess(Configuration.ConnectionString);

            foreach (var employee in dataAccess.GetAllEmployees())
            {
                Console.WriteLine(employee.FullName);
            }
        }
    }
}
