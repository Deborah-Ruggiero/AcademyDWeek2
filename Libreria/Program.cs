using System;
using System.Collections.Generic;

namespace Libreria
{
    class Program
    {

        /*
          Scrivere un programma che gestisca una libreria.
 
           Un libro è un'entità che ha
             Codice
             Titolo
             Autore
             Genere
             Prezzo
             DataPubblicazione
 
            Per il genere usare un enum
 
            Sarà possibile inserire un nuovo libro, eliminare un libro, modificare un libro o cercare i libri per genere
         */
        static void Main(string[] args)
        {
            Menu.Start();

            //Libro libro1 = new Libro();
            //libro1.Codice = "Cod001";
            //libro1.Autore = "Manzoni";
            //libro1.Titolo = "I promessi sposi";
            //libro1.Prezzo = 12;
            //libro1.DataPubblicazione = new DateTime(2020,10,12);

            //Console.WriteLine($"{libro1.Autore}");

            //Libro libro2 = new Libro();
            //libro2.Codice = "Cod002";
            //libro2.Titolo = "La Divina Commedia";
            //libro2.Autore = "Dante";

            //List<Libro> libri = new List<Libro>();
            //Console.WriteLine($"La mia lista contiene {libri.Count}");
            //libri.Add(libro1);
            //Console.WriteLine($"La mia lista contiene {libri.Count}");
            //libri.Add(libro2);
            //Console.WriteLine($"La mia lista contiene {libri.Count}");
            //libri.Remove(libro1);
            //Console.WriteLine($"La mia lista contiene {libri.Count}");

        }
    }
}
