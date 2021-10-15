using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda
{
    public class Task
    {
        //Proprietà
        public string Descrizione { get; set; }
        public DateTime DataDiScadenza { get; set; }
        public Livello LivelloDiImportanza { get; set; }


        //costruttore
        public Task()
        {

        }
    }

    public enum Livello
    {
        basso=1,
        medio,
        alto
    }
}
