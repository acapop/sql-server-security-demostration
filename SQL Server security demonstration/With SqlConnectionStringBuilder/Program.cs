using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace With_SqlConnectionStringBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            //koriscenjem SqlConnectionStringBuilder validiramo connection string (sprecavano unos SQL Injection pri konekciji) i mozemo lako menjati vrednost connection stringa
            SqlConnectionStringBuilder builder =
                new SqlConnectionStringBuilder(GetConnectionStringWindows());

            Console.WriteLine("Windows connection string:");
            Console.WriteLine(builder.ConnectionString);

            Console.WriteLine("SQL Server connection string:");
            builder.ConnectionString = GetConnectionStringSQLServerLogin();

            Console.WriteLine(builder.ConnectionString);

            Console.WriteLine(builder.Password);
            builder.Password = "newPassword";
            builder.AsynchronousProcessing = true;
            Console.WriteLine(builder.Password);
            
            builder["Server"] = ".";
            builder["Connect Timeout"] = 1000;
            builder["Trusted_Connection"] = true;
            Console.WriteLine(builder.ConnectionString);

            Console.WriteLine("Press Enter to finish.");
            Console.ReadLine();
        }

        private static string GetConnectionStringWindows()
        {
            return "Server=(local);Integrated Security=SSPI;" +
                "Initial Catalog=AdventureWorks2014";
        }
        private static string GetConnectionStringSQLServerLogin()
        {
            return "server=(local);user id=aca;" +
                "password= acaaca;initial catalog=AdventureWorks2014";
        }
    }
}
