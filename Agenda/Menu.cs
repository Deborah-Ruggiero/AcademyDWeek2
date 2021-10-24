using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda
{
    public static class Menù
    {
        public static void Start()

        /*  L’utente può: 
      1. Visualizzare i tasks; 
      2. Aggiungere un nuovo task; 
      3. Eliminare un task esistente; 
      4. Filtrare i tasks per importanza(ovvero per livello di priorità);


      Un nuovo task può essere aggiunto solo se la sua data di scadenza è posteriore alla data di inserimento del  task.
      Al termine delle operazioni, i task dovranno essere salvati su un file txt. */
        {

            Console.WriteLine("Benvenuto nella tua Agenda! \n");
            bool procedi = true;


            do
            {
                Console.WriteLine("\n ***********Menu***********\n");

                Console.WriteLine("Premi [1] per visualizzare i tuoi tasks \n");
                Console.WriteLine("Premi [2] aggiungere un nuovo task \n");
                Console.WriteLine("Premi [3] eliminare un task esistente \n");
                Console.WriteLine("Premi [4] per filtrare i tasks per importanza \n");
                Console.WriteLine("Premi [0] per uscire \n");

                int scelta;
                do
                {

                    Console.WriteLine("Seleziona l'opzione desiderata");
                } while (!(int.TryParse(Console.ReadLine(), out scelta) && scelta >= 0 && scelta <= 4));

                switch (scelta)
                {
                    case 1:
                        //visualizza tasks 
                        AgendaManager.VisualizzaTasks();
                        break;
                    case 2:
                        //aggiungere tasks
                        AgendaManager.AggiungiTasks();
                        break;
                    case 3:
                        //elimina tasks
                        AgendaManager.EliminaTask();
                        break;
                    case 4:
                        //filtrare tasks per importanza
                        AgendaManager.FiltraTasksPerImportanza();
                        break;
                    case 0:
                        //uscire
                        Console.WriteLine("Alla prossima!");
                        AgendaManager.SalvaTasksSuFile();
                        procedi = false;
                        break;
                }

            } while (procedi == true);





        }
    }
}

