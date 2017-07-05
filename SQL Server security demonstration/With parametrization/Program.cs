using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace With_parametrization
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

                reader.Close();
                //po izvrsenju programa, sql server nece da izvrsi dodatnu sql naredbu
                parametar = "'Ken';INSERT INTO Production.Culture (CultureID, Name) VALUES ('sr', 'Srbija');--";
                command = new SqlCommand("SELECT * FROM Person.Person WHERE FirstName = @parameter;", cnn);
                command.Parameters.AddWithValue("parameter", parametar);
                reader = command.ExecuteReader();

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
