using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda
{
    public static class TasksManager
    {
        public static List<Task> tasks = new List<Task>();


        internal static void AggiungiDatiProva()
        {
            Task task1 = new Task()
            {
                Descrizione = "Esame Matematica",
                DataDiScadenza = new DateTime(2022, 06, 10),
                LivelloDiImportanza = Livello.alto
            };
            Task task2 = new Task()
            {
                Descrizione = "Controllo dentista",
                DataDiScadenza = new DateTime(2022, 02, 05),
                LivelloDiImportanza = Livello.alto
            };

            tasks.Add(task1);
            tasks.Add(task2);
        }

        public static void LeggiDaFile()
        {
            string path = @"C:\Users\RenataCarriero\source\repos\AcademyDWeek2\Agenda\Tasks.txt";
            // File è una classe che fa parte sempre della System.IO
            // Metodo exists (path -> la posizione e il nome del nostro file) -> stringa
            if (File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string contenutoFile = sr.ReadToEnd();
                    // bool stringaVuota = String.IsNullOrEmpty(file);
                    // equivale a scrivere  file == "" ma è più corretto

                    if (contenutoFile == null || contenutoFile=="") //string.IsNullOrEmpty(contenutoFile)
                    {
                        Console.WriteLine("Non ci sono libri!!");
                    }
                    else
                    {
                        string[] righeDelMioFile = contenutoFile.Split("\r\n");

                        // riga 1(0) -> intestazione
                        // riga 2(1) -> 1, descrizione, data di Scadenza, ....
                        // riga 3(2) -> 2, descrizione, data di Scadenza, ...
                        // ......
                        // ultima riga(lunghezzaArray -1)  ->vuote


                        for (int i = 1; i < (righeDelMioFile.Length - 1); i++)
                        {
                            Task task = new Task();

                            string riga = righeDelMioFile[i];
                            string[] campiDellaRiga = riga.Split(",");

                            //campiDellaRiga[0]; (( contiene una parte che non ci interessa es. "1)" )
                            task.Descrizione = campiDellaRiga[1];
                            task.DataDiScadenza = DateTime.Parse(campiDellaRiga[2]);
                            //lettura e conversione in un enum "TipoEnum"
                            //(TipoEnum)Enum.Parse(typeof(TipoEnum), "stringa da convertire");
                            task.LivelloDiImportanza = (Livello)Enum.Parse(typeof(Livello), campiDellaRiga[3]);
                            tasks.Add(task);
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Impossibile caricare dati. File inesistente.");
            }
        }

        public static void StampaTasksDiUnaLista(List<Task> listaTasks)
        {
            if (listaTasks.Count == 0)
            {
                Console.WriteLine("Lista vuota");
            }
            else
            {
                Console.WriteLine("Descrizione\t\tData di Scadenza\t\tLivello di importanza");
                foreach (var item in listaTasks)
                {
                    Console.WriteLine($"{item.Descrizione}\t\t{item.DataDiScadenza}\t\t{item.LivelloDiImportanza}");
                }
            }
        }

        internal static void StampaTasks()
        {
            StampaTasksDiUnaLista(tasks);
        }



        internal static void AggiungiTask()
        {
            //Chiedo all'utente le informazioni necessarie per poter creare un nuovo task.
            Task nuovoTask = new Task();
            //Console.WriteLine("Inserisci la descrizione");
            //nuovoTask.Descrizione = Console.ReadLine();
            nuovoTask.Descrizione = InserisciDescrizioneTask();//l'utente non deve poter inserire 2 tasks con la stessa descrizione
            nuovoTask.DataDiScadenza = InserisciDataScadenza();
            nuovoTask.LivelloDiImportanza = InserisciPriorita();

            tasks.Add(nuovoTask);
            Console.WriteLine("Task aggiunto correttamente");
        }

        private static string InserisciDescrizioneTask() //Opzionale
        {
            Task taskTrovato = null;
            string descrizione;
            do
            {
                Console.WriteLine("Inserisci la descrizione");
                descrizione = Console.ReadLine();

                taskTrovato = CercaTask(descrizione);
                if (taskTrovato != null)
                {
                    Console.WriteLine("Impossibile aggiungere il task. Esiste già un altro task con la stessa descrizione");
                }
            } while (!(taskTrovato == null));

            return descrizione;
        }

        private static Livello InserisciPriorita()
        {
            Console.WriteLine("Inserisci il livello di importanza/priorità");
            Console.WriteLine($"Premi {(int)Livello.basso} se {Livello.basso}");
            Console.WriteLine($"Premi {(int)Livello.medio} se {Livello.medio}");
            Console.WriteLine($"Premi {(int)Livello.alto} se {Livello.alto}");
            int livello;
            do
            {
                Console.WriteLine("Fai la tua scelta");
            } while (!(int.TryParse(Console.ReadLine(), out livello) && livello >= 1 && livello <= 3));
            return (Livello)livello;
        }

        private static DateTime InserisciDataScadenza()
        {
            DateTime data;
            do
            {
                Console.WriteLine("Inserisci la data di scadenza del task");
            } while (!(DateTime.TryParse(Console.ReadLine(), out data) && data >= DateTime.Now));
            return data;
        }

        internal static void EliminaTask()
        {
            Console.WriteLine("I tasks presenti nella tua agenda sono:");
            StampaTasks();
            Console.WriteLine("Scrivi la descrizione del task che vuoi eliminare");
            string descrizioneDaRicercare = Console.ReadLine();
            Task taskTrovato = CercaTask(descrizioneDaRicercare);
            if (taskTrovato == null)
            {
                Console.WriteLine("Task non trovato. Descrizione inesistente!");
            }
            else
            {
                tasks.Remove(taskTrovato);
                Console.WriteLine("Task eliminato correttamente!");
            }
        }

        private static Task CercaTask(string descrizioneDaRicercare)
        {
            foreach (var item in tasks)
            {
                if (item.Descrizione == descrizioneDaRicercare)
                {
                    return item;
                }
            }
            return null;
        }

        internal static void FiltraTasksPerImportanza()
        {
            Livello liv = InserisciPriorita();

            List<Task> tasksFiltrati = new List<Task>();

            foreach (var item in tasks)
            {
                if (item.LivelloDiImportanza == liv)
                {
                    tasksFiltrati.Add(item);
                }
            }
            StampaTasksDiUnaLista(tasksFiltrati);
        }

        internal static void SalvaSuFile()
        {
            string path = @"C:\Users\RenataCarriero\source\repos\AcademyDWeek2\Agenda\Tasks.txt";

            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine("Descrizione,Data Scadenza,Priorità");

                int count = 1;
                foreach (var item in tasks)
                {
                    sw.WriteLine($"{count},{item.Descrizione},{item.DataDiScadenza},{item.LivelloDiImportanza}");
                    count++;
                }

            }
        }
    }
}
