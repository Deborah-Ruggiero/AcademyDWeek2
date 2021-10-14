using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria
{
    public static class Menu
    {

        public static void Start()
        {
            Console.WriteLine("Benvenuto nella libreria\n");
            LibreriaManager.AggiungiDatiProva();
            bool continua = true;
            do
            {
                Console.WriteLine("\n**************MENU******************\n");
                Console.WriteLine("Premi 1 per aggiungere un libro");
                Console.WriteLine("Premi 2 per eliminare un libro");
                Console.WriteLine("Premi 3 per modificare un libro");
                Console.WriteLine("Premi 4 per stampare i libri");
                Console.WriteLine("Premi 5 per estrarre i libri per genere");
                Console.WriteLine("Premi 0 per uscire");

                int scelta;
                do
                {
                    Console.WriteLine("Fai la tua scelta tra le possibili opzioni");
                } while (!(int.TryParse(Console.ReadLine(), out scelta) && scelta >= 0 && scelta <= 5));

                switch (scelta)
                {
                    case 1: //if(scelta==1)
                        LibreriaManager.AggiungiLibro();                        
                        break;
                    case 2:
                        LibreriaManager.EliminaLibro();
                        break;
                    case 3:
                        LibreriaManager.ModificaLibro();
                        break;
                    case 4:
                        LibreriaManager.StampaLibri();
                        break;
                    case 5:
                        LibreriaManager.FiltraLibriPerGenere();
                        break;
                    case 0:
                        Console.WriteLine("Arrivederci!");
                        continua = false;
                        break;
                }
            } while (continua==true);
        }
       
    }
}
