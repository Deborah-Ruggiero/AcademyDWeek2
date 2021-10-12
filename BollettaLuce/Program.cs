using System;

namespace BollettaLuce
{

    /*Realizzare un’applicazione console che consenta di eseguire il calcolo della bolletta della luce.
    Si richiede di sviluppare un menù attraverso cui l’utente può scegliere di:

    1.inserire i propri dati (nome, cognome e kwH consumati);
    2.richiedere il calcolo del costo della bolletta che è costituito da una quota fissa di 40€ più il prodotto tra i kwH e 10.
    3.stampare a video i valori della bolletta, inclusi nome, cognome e costo pagato.
    Ciascuna delle operazioni descritte sopra dovrà essere implementata attraverso una opportuna routine.
    */
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bolletta Luce!");
            string nome = null, cognome = null;
            double kwh = -1;
            const double quotaFissa = 40;
            double totale = 0;
            bool continua = true;

            while(continua){
                Menu();
                int scelta = Scegli();
                switch (scelta)
                {
                    case 1:
                        InserisciDati(ref nome, ref cognome, ref kwh);
                        break;
                    case 2:
                        if (kwh == -1)
                        {
                        InserisciDati(ref nome, ref cognome, ref kwh);
                        }
                        totale = CalcolaBolletta(kwh, quotaFissa);
                        break;
                    case 3:
                        StampaBolletta(nome, cognome, totale, kwh);
                        break;
                    case 0:
                        Console.WriteLine("Arrivederci!");
                        continua = false;
                        break; //return;
                }
            }
        }

        private static void StampaBolletta(string nome, string cognome, double totale, double kwh)
        {
            Console.WriteLine($"Bolletta di {nome} {cognome}");
            Console.WriteLine($"Consumi (kwh): {kwh}");
            Console.WriteLine($"Totale da pagare (euro): {totale}");
        }

        private static double CalcolaBolletta(double kwh, double quotaFissa)
        {
            double totaleDaPagare = (kwh * 10) + quotaFissa;
            Console.WriteLine("Bolletta calcolata. Corri a stamparla");
            return totaleDaPagare;

        }

        private static void InserisciDati(ref string nome, ref string cognome, ref double kwh)
        {
            Console.WriteLine("Inserisci il tuo nome: ");
            nome = Console.ReadLine();
            Console.WriteLine("Inserisci il tuo cognome: ");
            cognome = Console.ReadLine();
            do
            {
                Console.WriteLine("Inserisci i KWH consumati: ");
            } while (!(double.TryParse(Console.ReadLine(), out kwh) && kwh>=0));
        }

        private static int Scegli()
        {
            int scelta;
            do
            {
                Console.WriteLine("Fai la tua scelta tra le possibili opzioni del menu:");
            } while (!(int.TryParse(Console.ReadLine(), out scelta) && scelta>=0 && scelta<=3));
            return scelta;
        }

        private static void Menu()
        {
            Console.WriteLine("---------MENU-------");
            Console.WriteLine("1. Inserisci i tuoi dati");
            Console.WriteLine("2. Calcola bolletta");
            Console.WriteLine("3. Stampa bolletta");
            Console.WriteLine("0. Exit");
        }
    }
}
