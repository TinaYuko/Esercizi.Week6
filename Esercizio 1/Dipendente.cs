using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio_1
{
    abstract class Dipendente
    {
        public string Nome { get; set; }
        public string Cognome { get; set; }

        public Dipendente()
        {

        }

        public Dipendente( string nome, string cognome)
        {
            this.Nome = nome; //this serve nel caso nome e Nome siano stati scritti nello stesso modo
            Cognome = cognome;
        }
        public void StampaDatiAnagrafici()
        {
            Console.WriteLine($"Nome: {Nome} \tCognome: {Cognome}");
        }

        public void StampaRuolo()
        {
            Console.WriteLine("Il ruolo è: Dipendente");
        }

        public abstract void StampaStipendio();
        public virtual void StampaFerie()
        {
            Console.WriteLine("Il dipendente ha 2 giorni di ferie");
        }
    }

}
