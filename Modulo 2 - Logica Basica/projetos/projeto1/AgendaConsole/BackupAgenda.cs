using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaConsole
{

    internal class BackupAgenda
    {   
        //Atributos:
        public static string dbFile = "db.txt";


        //Métodos:
        public static void SaveData(ref string[]nomes, ref string[] emails, ref int numRegistro)
        {
            StreamWriter sr = new StreamWriter(dbFile);
            for(int i = 0; i < numRegistro; i++)
            {
                sr.WriteLine(nomes[i] + "-" + emails[i]);
            }
            sr.Close();
        }

        public static void RestoreData(ref string[] nomes, ref string[] emails, ref int numRegistro)
        {
            numRegistro = 0;
            int pos = 0;

            StreamReader sr = new StreamReader(dbFile);
            string line = sr.ReadLine();

            while (line != null)
            {
                pos = line.IndexOf("-");

                nomes[numRegistro] = line.Substring(0, pos); // .Substring é similar ao metodo slice do js
                emails[numRegistro] = line.Substring(pos + 1);

                numRegistro++;
                line = sr.ReadLine();
            }
            sr.Close();            
        }
    }


}
