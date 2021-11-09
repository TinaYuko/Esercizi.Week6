using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio_1
{
    class Tecnico : Dipendente
    {

        public string CodiceFiscale { get; set; }
        public int PagaOraria { get; set; } = 10;

        public Tecnico(string nome, string cognome, string codiceFiscale) : base (nome, cognome)
        {
            CodiceFiscale = codiceFiscale;
        }
        public Tecnico(string nome, string cognome, string codiceFiscale, int pagaOraria) : base(nome, cognome)
        {
            CodiceFiscale = codiceFiscale;
            PagaOraria = pagaOraria;
        }
        public override void StampaStipendio()
        {
            Console.WriteLine($"Lo stipendio è di {CalcolaStipendio()} euro");
        }

        protected int CalcolaStipendio()
        {
            int stipendio = 26 * 8 * PagaOraria;
                return stipendio;
        }
        public new void StampaRuolo()
        {
            Console.WriteLine("Il ruolo è: Tecnico");
        }

        public override void StampaFerie()
        {
            base.StampaFerie();
        }
    }
}
