using System;
using System.IO;

namespace ScritturaLetturaDaFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\RenataCarriero\source\repos\AcademyDWeek2\ScritturaLetturaDaFile\fileProva.txt";
            //StreamWriter sw = new StreamWriter(@"fileProva.txt"); //di default viene creato nella cartella bin del progetto.


            //Scrittura su file con chiusura manuale
            StreamWriter sw = new StreamWriter(path);
            sw.WriteLine("Ciao a tutte!");
            sw.Close();

            //Scrittura su file con chiusura automatica -> using

            //Scrittura su file sovrascivendo il contenuto precedente
            using(StreamWriter sw1=new StreamWriter(path))
            {
                sw1.WriteLine("Buongiorno!");
            }

            //Scrittura su file mantenendo il contenuto precedente
            using(StreamWriter sw1=new StreamWriter(path, true))
            {
                sw1.WriteLine("Come state?");
            }


            //Lettura di tutto il file
            using(StreamReader sr1= new StreamReader(path))
            {
                string contenutoFile= sr1.ReadToEnd();
            }

            //Lettura di una riga dal file
            using (StreamReader sr1=new StreamReader(path))
            {
                string contenutoRiga=sr1.ReadLine();
            }

            //Lettura di tutto il file e divisione del file in righe
            using(StreamReader sr1= new StreamReader(path))
            {
                string contenutoFile = sr1.ReadToEnd();
                var arrayDiRighe = contenutoFile.Split("\r\n");
            }
        }
    }
}
