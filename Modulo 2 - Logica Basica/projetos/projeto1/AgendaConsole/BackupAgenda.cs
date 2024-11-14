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

        }


    }

}
