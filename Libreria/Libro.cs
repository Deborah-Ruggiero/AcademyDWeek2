using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Un libro è un'entità che ha
// Codice
// Titolo
// Autore
// Genere
// Prezzo
// DataPubblicazione
 
//Per il genere usare un enum

namespace Libreria
{
    public class Libro
    {
        //elenco delle proprietà dell'entità libro
        public string Codice { get; set; }
        public string Titolo { get; set; }
        public string Autore { get; set; }
        public Genere Genere { get; set; }
        public double Prezzo { get; set; }
        public DateTime DataPubblicazione { get; set; }

        //Costruttore
        public Libro()
        {

        }
    }
    public enum Genere
    {
        Narrativa=1,
        Storico=2,
        Fantasy=3
    }
}
