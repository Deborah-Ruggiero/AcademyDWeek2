using System;

namespace CarteDiCredito
{
    // Le carte di pagamento sono lunghe 16 cifre. 
    // Le prime 6 cifre rappresentano un numero di identificazione univoco per la banca che ha emesso la carta.
    // Le successive 2 cifre determinano il tipo di carta (ad es. debito, credito, regalo).
    // Le cifre da 9 a 15 sono il numero di serie della carta
    // L'ultima cifra è utilizzata come cifra di controllo per verificare se il numero della carta è valido.

    // Hans Peter ha inventato un metodo per determinare se un numero di carta di credito è sintatticamente valido

    // Step 1 : Vengono raddoppiate le cifre che si trovano in posizione dispari e
    // Step 2 : Se questo "raddoppio" risulta in un numero a due cifre, viene sottratto 9 da esso per ottenere una sola cifra.
    // Step 3 : Vengono sommante tutte le cifre ottenute
    // Step 4 : Vengono aggiunte le cifre nelle posizioni pari
    // Step 5 : Se il risultato è divisibile per 10, il numero della carta è valido; in caso contrario, non è valido.

    // Esempi
    // Carta di pagamento : 4  5  5  6    7  3  7  5   8  6  8  9   9  8  5  5
    // Step 1             : 8  5 10  6   14  3 14  5   16 6  16 9   18 8  10 5
    // Step 2             : 8  5  1  6    5  3  5  5   7  6  7  9   9  8  1  5
    // Step 3             : 8 + 1 + 5 + 5 + 7 + 7 + 9 + 1 = 43
    // Step 4             : 43 + (5+6+3+5+6+9+8+5) = 43 + 47 = 90
    // Step 5             : 90/10 = 9 resto 0 -> Numero della carta valido

    // Esempi
    // Carta di pagamento : 4  0  2  4    0  0  7  1   0  9  0  2   2  1  4  3
    // Step 1             : 8  0  4  4    0  0 14  1   0  9  0  2   4  1  8  3
    // Step 2             : 8  0  4  4    0  0  5  1   0  9  0  2   4  1  8  3
    // Step 3             : 8 + 4 + 0 + 5 + 0 + 0 + 4 + 8 = 29
    // Step 4             : 29 + (0+4+0+1+9+2+1+3) = 29 + 20 = 49
    // Step 5             : 49/10 = 4 resto 9 -> Numero della carta non valido
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Inserisci il numero della tua carta di credito:");
            const int N = 16;
            int[] cartadiCredito = new int[N];
            int[] posizioniPari = new int[N / 2];
            int[] posizioniDispari = new int[N / 2];
            int countPari = 0;
            int countDispari = 0;

            for (int i = 0; i < cartadiCredito.Length; i++)
            {
                int numero;
                while (!(int.TryParse(Console.ReadLine(), out numero) && numero>=0 && numero <=9))
                {
                    Console.WriteLine("Inserisci un valore corretto");
                }
                cartadiCredito[i] = numero;
            }

            Console.WriteLine("La carta inserita è la seguente:");
            for (int i = 0; i < cartadiCredito.Length; i++)
            {
                Console.Write(cartadiCredito[i]);
            }

            for (int i = 0; i < cartadiCredito.Length; i++)
            {
                if (i % 2 == 0)
                {
                    posizioniDispari[countDispari] = cartadiCredito[i];
                    countDispari++;
                }
                else
                {
                    posizioniPari[countPari] = cartadiCredito[i];
                    countPari++;
                }
            }

            //Stampo i 2 array
            Console.WriteLine("\nArray con le sole cifre che stanno in posizione Dispari");
            for (int i = 0; i < posizioniDispari.Length; i++)
            {
                Console.Write(posizioniDispari[i]);
            }
            Console.WriteLine("\nArray con le sole cifre che stanno in posizione Pari");
            for (int i = 0; i < posizioniPari.Length; i++)
            {
                Console.Write(posizioniPari[i]);
            }

            int[] posizioniDispariRaddoppiate = new int[N / 2];
            for (int i = 0; i < posizioniDispariRaddoppiate.Length; i++)
            {
                if (posizioniDispari[i] * 2 >= 10)
                {
                    posizioniDispariRaddoppiate[i] = (posizioniDispari[i] * 2)-9;
                }
                else
                {
                    posizioniDispariRaddoppiate[i] = posizioniDispari[i] * 2;
                }               
            }
            Console.WriteLine("\nArray con le cifre in posizioni dispari raddoppiate*");
            for (int i = 0; i < posizioniDispariRaddoppiate.Length; i++)
            {
                Console.Write(posizioniDispariRaddoppiate[i]);
            }

            int totaleCifreArrayDispariRadd = 0;
            foreach (var item in posizioniDispariRaddoppiate)
            {
                totaleCifreArrayDispariRadd = totaleCifreArrayDispariRadd + item;
            }
            Console.WriteLine($"\nLa somma delle cifre dell'array dispari raddoppiato è {totaleCifreArrayDispariRadd}");

            int totaleCifreArrayPari = 0;
            foreach (var item in posizioniPari)
            {
                totaleCifreArrayPari = totaleCifreArrayPari + item;
            }
            Console.WriteLine($"\nLa somma delle cifre dell'array pari è {totaleCifreArrayPari}");

            int totale = totaleCifreArrayDispariRadd + totaleCifreArrayPari;

            Console.WriteLine($"\nLa somma totale delle cifre è {totale}");

            if (totale % 10 == 0)
            {
                Console.WriteLine("La carta è valida");
            }
            else
            {
                Console.WriteLine("La carta NON è valida");
            }

        }
    }
}
