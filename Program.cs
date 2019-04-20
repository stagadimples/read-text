using System;
using Oracle.ManagedDataAccess.Client;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;

namespace ReadText
{
    class Program
    {
        static void Main(string[] args)
        {
            string fpath;
            string text;


            Console.Write("Specify full file path to read: ");
            fpath = Console.ReadLine();

            try
            {
                text = File.ReadAllText(fpath);

                string[] textlines = File.ReadAllLines(fpath);

                for (int i = 0; i < textlines.Length; i++)
                {
                    Console.WriteLine(textlines[i]);
                }
            }
            catch(Exception err)
            {
                Console.WriteLine(err.Message);
            }

            //Console.WriteLine(text);

            string constring = "User Id = c##zipcensus; password = Formula1;" +
                "Data Source=localhost:1521/orcl.home; Pooling=false;";


            OracleConnection con = new OracleConnection(constring);
            con.ConnectionString = constring;
            con.Open();

            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "select productname from product where rownum < 25";

            //Execute the command and use datareader to display the data
            OracleDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine("Product Name: " + reader.GetString(1));
            }
            Console.ReadLine();

        }


    }
}
