using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio_1
{
    class Manager: Tecnico
    {
        public int BonusMensile { get; set; }

        public Manager(string nome, string cognome, string codiceFiscale, int pagaOraria) 
            : base(nome, cognome, codiceFiscale, pagaOraria)
        {

        }
        public Manager(string nome, string cognome, string codiceFiscale, int pagaOraria, int bonus)
            : base(nome, cognome, codiceFiscale, pagaOraria)
        {
            BonusMensile = bonus;
        }

        public override void StampaStipendio()
        {
            Console.WriteLine($"Lo stipendio è di {CalcolaStipendio()+BonusMensile} euro");
        }

        public new void StampaRuolo()
        {
            Console.WriteLine("Il ruolo è: Manager");
        }

        public override void StampaFerie()
        {
            base.StampaFerie();
        }

    }

    
}
