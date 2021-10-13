using System;

namespace Interessi
{
    // Scrivere una funzione che dato un importo di denaro iniziale,
    // un interesse annuo e un numero di anni permette di calcolare
    // l’importo di denaro accresciuto degli interessi dopo il numero di anni passati

    // Esempio
    // Voglio vincolare 10000 euro per 3 anni con un interesse del 3%

    // Dopo 1 anno : 10000 + (10000 * 3 / 100) = 10000 + 300 = 10300
    // Dopo 2 anni : 10300 + (10300 * 3 / 100) = 10300 + 309 = 10609
    // Dopo 3 anni : 10609 + (10609 * 3 / 100) = 10609 + 318,27 = 10927,27
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Calcola interessi!");
            Console.WriteLine("Inserisci il tuo importo iniziale");
            double importoIniziale = double.Parse(Console.ReadLine()); //TODO: aggiungere controlli su esito conversione e su positività
            Console.WriteLine("Inserisci gli anni da vincolare");
            int totaleAnni = int.Parse(Console.ReadLine()); //TODO: aggiungere controlli su esito conversione e su positività
            Console.WriteLine("Inserisci l'interesse");
            double interesse = double.Parse(Console.ReadLine()); //TODO: aggiungere controlli su esito conversione e su positività

            double importoFinale = CalcolaInteressiIterazione(importoIniziale, totaleAnni, interesse);
            Console.WriteLine($"L'importo finale dopo {totaleAnni} anni (calcolato con Iterazione) è di {importoFinale}");

            double importoFinaleRic = CalcolaInteressiRicorsione(importoIniziale, totaleAnni, interesse);
            Console.WriteLine($"L'importo finale dopo {totaleAnni} anni (calcolato con Ricorsione) è di {importoFinaleRic}");

        }

        private static double CalcolaInteressiRicorsione(double importoIniziale, int totaleAnni, double interesse)
        {

            if (totaleAnni == 0)
            {
                return importoIniziale;
            }
            else
            {
                return CalcolaInteressiRicorsione(importoIniziale + (importoIniziale * 3 / 100), --totaleAnni, interesse);

            }
        }

        private static double CalcolaInteressiIterazione(double importo, int totaleAnni, double interesse)
        {

            for (var i = 0; i < totaleAnni; i++)
            {
                importo = importo + (importo * interesse / 100);
            }
            return importo;
        }
    }
}
