using System;

namespace IterazioneRicorsione
{
    class Program
    {
        static void Main(string[] args)
        {
            //SommaPrimiNnumeri();
            //Fibonacci();

            

        }

        private static void Fibonacci()
        {
            Console.WriteLine("Calcolare l'n-esimo numero della serie di Fibonacci");
            int N = 10; //deve essere un intero positivo.
            //Iterazione
            int NesimoNumero = FibonacciIterazione(N);
            Console.WriteLine($"Il {N}° numero della serie di fibonacci (calcolato con iterazione) è {NesimoNumero}");

            //Ricorsione
            int NesimoNumeroRic = FibonacciRicorsione(N);
            Console.WriteLine($"Il {N}° numero della serie di fibonacci (calcolato con ricorsione) è {NesimoNumeroRic}");
        }

        private static int FibonacciRicorsione(int n) 
        {

            if(n==0 || n==1)
            {
                return n;
            }
            else
            {
                return FibonacciRicorsione(n - 1) + FibonacciRicorsione(n - 2);
            }
        }

        private static int FibonacciIterazione(int n)
        {
            
            int[] arrayFibonacci = new int[n];

            for (int i = 0; i < n; i++)
            {
                if (i <= 1)
                {
                    arrayFibonacci[i] = 1;
                }
                else
                {
                    arrayFibonacci[i] = arrayFibonacci[i - 1] + arrayFibonacci[i - 2];
                }
            }
            return arrayFibonacci[n - 1];
        }

        private static void SommaPrimiNnumeri()
        {
            Console.WriteLine("Calcolare la somma dei primi N numeri positivi");
            //Iterazione
            int N = 4;

            int somma = SommaIterazione(N);
            Console.WriteLine($"La somma dei primi {N} numeri calcolata con iterazione (for) è {somma}");

            int sommaConWhile = SommaIterazioneWhile(N);
            Console.WriteLine($"La somma dei primi {N} numeri calcolata con iterazione (while) è {sommaConWhile}");

            //Ricorsione
            int sommaRic = SommaRicorsione(N);
            Console.WriteLine($"La somma dei primi {N} numeri calcolata con ricorsione è {sommaRic}");
        }

        private static int SommaRicorsione(int n)
        {
            int sum = 0;
            if (n == 1)
            {
                sum = 1;
                return sum;
            }
            else
            {
                sum= SommaRicorsione(n - 1) + n;
                return sum;
            }
        }

        private static int SommaIterazioneWhile(int n)
        {
            int sum = 0;
            int i = 0;
            while (i <= n)
            {
                sum += i;
                i++;
            }
            return sum;
        }

        private static int SommaIterazione(int n)
        {
            int sum = 0;
            for (int  i = 0;  i <= n;  i++)
            {
                sum += i; //sum = sum + i;
            }
            return sum;
        }
    }
}
