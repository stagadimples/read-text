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

            Console.ReadLine();

        }


    }
}
