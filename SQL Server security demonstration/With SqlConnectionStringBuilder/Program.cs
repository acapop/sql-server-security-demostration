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
            string connetionString = null;
            SqlConnection cnn;

            //koriscenjem SqlConnectionStringBuilder validiramo connection string (sprecavano unos SQL Injection pri konekciji). Takodje mozemo lako menjati vrednost connection stringa
            SqlConnectionStringBuilder builder =
                new SqlConnectionStringBuilder(GetConnectionStringWindows());

            Console.WriteLine("Windows connection string:");
            Console.WriteLine(builder.ConnectionString);

            //SQL Server login nije siguran jer podaci idu preko mreze, cime login moze da bude narusen.
            //Console.WriteLine("SQL Server connection string:");
            //builder.ConnectionString = GetConnectionStringSQLServerLogin();

            builder["initial catalog"] = "AdventureWorks2014;Server=192.168.1.2";
            //Ovde klijent trazi bazu podataka pod imenom "AdventureWorks2014;Server=192.168.1.2" za razliku od prethodnog resenja gde klijent gadja drugi server
            connetionString = builder.ConnectionString;

            cnn = new SqlConnection(connetionString);


            try
            {
                cnn.Open();
                Console.WriteLine("Connection Open");

                cnn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Can not open connection ! ");
            }
            Console.ReadLine();
        }

        private static string GetConnectionStringWindows()
        {
            return "Server=(local);Integrated Security=SSPI;Initial Catalog=AdventureWorks2014;";
        }
        private static string GetConnectionStringSQLServerLogin()
        {
            return "server=(local);user id=aca;password= acaaca;initial catalog=AdventureWorks2014";
        }
    }
}
