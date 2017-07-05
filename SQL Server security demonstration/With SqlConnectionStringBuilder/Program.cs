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

            //SQL Server login nije siguran jer podaci idu preko mreze, cime login moze da bude narusen.
            Console.WriteLine("SQL Server connection string:");
            builder.ConnectionString = GetConnectionStringSQLServerLogin();


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
