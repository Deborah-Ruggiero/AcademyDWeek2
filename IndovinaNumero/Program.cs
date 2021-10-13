using System;
using System.IO;

namespace IndovinaNumero
{
//Esercizio: Indovina Numero.
//Il gioco consiste nell’indovinare un numero tra 1 e 100, generato in modo casuale.

//L’utente accede e visualizza un messaggio di benvenuto. 
//Gli viene chiesto di inserire il suo nome, quindi, una volta inserito,
//compare un messaggio del tipo “Ciao NOME!” ed un menu con delle scelte/opzioni.
//In particolare potrà scegliere se iniziare a giocare una partita o uscire dal programma.

//Se l’utente decide di uscire, verrà visualizzato un messaggio di arrivederci.

//Se invece decide di giocare dovrà essere generato un numero casuale
//che ovviamente NON dovrà essere mostrato a video.
//(Opzionale: il numero può essere salvato in un file “NumeroDaIndovinare.txt”). 

//Dopo la generazione e memorizzazione del numero casuale,
//si dovrà chiedere all’utente di provare ad indovinare il numero
//specificando a video(e quindi controllando in fase di inserimento)
//che si tratta di un numero compreso tra 1 e 100. 
//(Opzionale: Se l’utente inserisce “0” interrompe la partita e
//gli verrà mostrato un messaggio di “Partita interrotta” quindi
//svelato il numero che doveva indovinare.Ritornerà quindi al menu iniziale.)

//Bisognerà tener traccia dei tentativi che fa, 
//mostrando il numero dei tentativi che sono stati fatti.

//--------------------------------------------------------------------
//Esempio: 
//Finora hai effettuato 0 tentativi.
//Inserisci il tuo 1° tentativo(0 per interrompere la partita) :
//--------------------------------------------------------------------

//L’utente dovrà provare quindi ad indovinare il numero.
//Ogni volta che l’utente prova ad inserire un numero, cioè inserisce un tentativo,
//bisognerà quindi verificare se il numero inserito corrisponde al numero segreto.
//Se l’utente NON indovina il numero, gli verrà mostrato un suggerimento del tipo
//“Prova con un numero più alto” o “Prova con un numero più basso” 
//in base al confronto tra il numero che l’utente ha inserito e il numero segreto.
//Quindi l’utente farà un altro tentativo e così via finché indovina il numero!

//---------------------------------------------------------------------------------------
//Esempio (Il numero da indovinare è 20 e l'utente inserisce come secondo tentativo 15):

//Suggerimento: Inserisci un numero più alto.
//Finora hai effettuato 2 tentativi.
//Inserisci il tuo 3° tentativo (0 per interrompere la partita):
//---------------------------------------------------------------------------------------

//Se/quando l’utente indovina il numero, verrà visualizzato il messaggio:
//“Complimenti hai vinto! Ti sono bastati X tentativi! Bravo!”. 
//E verrà rimandato al menu iniziale.
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Benvenutoo!");
            Console.WriteLine("Inserisci il tuo nome:");
            string nome = Console.ReadLine();
            Console.WriteLine($"Ciao {nome}!");
            bool continua = true;
            do
            {
                char scelta = sceltaMenu();

                switch (scelta)
                {
                    case 's':
                        NuovaPartita();
                        break;
                    case 'n':
                        Uscita(nome);
                        continua = false;
                        break;
                }
            } while (continua);
            
        }

        private static void NuovaPartita()
        {
            int numeroSegreto = new Random().Next(1, 101);
            //Scrittura su file
            string path = @"C:\Users\RenataCarriero\source\repos\AcademyDWeek2\IndovinaNumero\NumeroSegreto.txt";
            using(StreamWriter sw =new StreamWriter(path))
            {
                sw.WriteLine($"Il numero segreto è {numeroSegreto}");
            }

            Console.WriteLine("\nNumero segreto scelto tra 1 e 100. Prova ad indovinarlo!");
            int tentativo;
            int countTentativi = 0;
            string suggerimento = "";
            bool trovato = false;

            do
            {
                Console.WriteLine($"Finora hai effettuato {countTentativi} tentativi.");
                countTentativi++;
                Console.WriteLine($"Fai il tuo {countTentativi}° tentativo (0 per interrompere il gioco)");
                while (!(int.TryParse(Console.ReadLine(), out tentativo) && tentativo >= 0 && tentativo <= 100))
                {
                    Console.WriteLine("Devi inserire un numero compreso tra 0 e 100. Riprova. ");
                    Console.WriteLine($"Fai il tuo {countTentativi}° tentativo (0 per interrompere il gioco)");
                }

                if (tentativo == 0)
                {
                    Console.WriteLine("\nPartita Interrotta!");
                    Console.WriteLine($"Il numero segreto era {numeroSegreto}");
                    return;

                }
                else if (tentativo == numeroSegreto)
                {
                    Console.WriteLine("\n************HAI VINTO!!!!***********");
                    Console.WriteLine($"\nHai effettuato in totale {countTentativi} tentativi. Bravo!");
                    trovato = true;
                }
                else
                {
                    if (tentativo < numeroSegreto)
                    {
                        suggerimento = "Prova con un numero più alto";
                    }
                    else
                    {
                        suggerimento = "Prova ad inserire un numero più basso";
                    }
                    Console.WriteLine("Suggerimento: " + suggerimento);
                }
            } while (trovato==false);
        }

        private static void Uscita(string nomeUtente)
        {
            Console.WriteLine($"Ciao {nomeUtente}. Torna presto a giocare!");
        }

        private static char sceltaMenu()
        {
            Console.WriteLine("\n----------Menu----------");
            Console.WriteLine("Vuoi fare una nuova partita? s/n");

            char risposta = Console.ReadKey().KeyChar;
            while(risposta !='s' && risposta != 'n')
            {
                Console.WriteLine("Errore. Devi scegliere s/n");
                risposta = Console.ReadKey().KeyChar;
            }

            return risposta;
        }
    }
}
