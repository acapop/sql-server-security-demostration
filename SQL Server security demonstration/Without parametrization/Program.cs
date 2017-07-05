using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Without_parametrization
{
    class Program
    {
        static void Main(string[] args)
        {
            string connetionString = null;
            SqlConnection cnn;
            SqlCommand command;
            SqlDataReader reader;
            string parametar;


            connetionString = "Server=(local);Integrated Security=SSPI;Initial Catalog=AdventureWorks2014";
            cnn = new SqlConnection(connetionString);


            try
            {
                cnn.Open();
                Console.WriteLine("Connection Open");

                parametar = "'Ken'";
                command = new SqlCommand("SELECT * FROM Person.Person WHERE FirstName = " + parametar + ";", cnn);
                reader = command.ExecuteReader();
                Console.WriteLine(reader.FieldCount);
                reader.Close();
                //po izvrsenju programa, sql server ce da izvrsi obe sql naredbe
                parametar = "'Ken';INSERT INTO Production.Culture (CultureID, Name) VALUES ('sr', 'Srbija');--";
                command = new SqlCommand("SELECT * FROM Person.Person WHERE FirstName = " + parametar + ";", cnn);
                reader = command.ExecuteReader();
                Console.WriteLine(reader.FieldCount);
                reader.Close();

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
