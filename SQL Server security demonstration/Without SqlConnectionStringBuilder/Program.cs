using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Without_SqlConnectionStringBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            string connetionString = null;
            SqlConnection cnn;

            string database = "AdventureWorks2014;Server=192.168.1.2";
            connetionString = "Server=(local);Integrated Security=SSPI;Initial Catalog=" + database + "; ";
            cnn = new SqlConnection(connetionString);
            //Ovde klijent trazi drugi server sa imenom (IP adresom) "192.168.1.2" za razliku od resenja koje koristi SqlConnectionStringBuilder


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
    }
}
