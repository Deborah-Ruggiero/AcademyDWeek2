using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda
{
    public static class Menu
    {
        public static void Start()
        {
            Console.WriteLine("Benvenuto nella tua Agenda!");
            //TasksManager.AggiungiDatiProva();
            TasksManager.LeggiDaFile();
            bool continua = true;
            do
            {
                Console.WriteLine("\n**************MENU******************\n");
                Console.WriteLine("Premi 1 per stampare i tuoi Tasks");
                Console.WriteLine("Premi 2 per aggiungere un nuovo Tasks");
                Console.WriteLine("Premi 3 per eliminare un tuo Tasks");
                Console.WriteLine("Premi 4 per estrarre i Task per importanza");
                Console.WriteLine("Premi 0 per salvare su file ed uscire");

                int scelta;
                do
                {
                    Console.WriteLine("Fai la tua scelta tra le possibili opzioni");
                } while (!(int.TryParse(Console.ReadLine(), out scelta)) /*&& scelta >= 0 && scelta <= 4)*/);

                switch (scelta)
                {
                    case 1: 
                        TasksManager.StampaTasks(); 
                        break;
                    case 2:
                        TasksManager.AggiungiTask();
                        break;
                    case 3:
                        TasksManager.EliminaTask();                        
                        break;
                    case 4:
                        TasksManager.FiltraTasksPerImportanza();
                        break;
                    case 0:
                        Console.WriteLine("Arrivederci!");
                        TasksManager.SalvaSuFile();
                        continua = false;
                        break;
                    default:
                        Console.WriteLine("Scelta errata. Riprova");
                        break;
                }
            } while (continua == true);
        }
    }
}
