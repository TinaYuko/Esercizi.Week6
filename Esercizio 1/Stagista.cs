using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio_1
{
    class Stagista : Dipendente
    {
        public int CompensoMensile { get; set; } = 600;

        public Stagista()
        {

        }
        public Stagista(string nome, string cognome): base(nome, cognome)
        {
            //CompensoMensile = 600; o qui o nella proprietà
        }
        public Stagista(string nome, string cognome, int compensoMensile) : base(nome, cognome)
        {
            CompensoMensile = compensoMensile;
        }

        public override void StampaStipendio()
        {
            Console.WriteLine($"Lo stipendio è di {CompensoMensile} euro");
            //Console.WriteLine("Lo stipendio delo stagista {0} {1} è di {2} euro", Cognome, Nome, CompensoMensile);
        }
        
        public new void StampaRuolo()
        {
            Console.WriteLine("Il ruolo è: Stagista");
        }

        public override void StampaFerie()
        {
            Console.WriteLine("Lo stagista ha 5 giorni di ferie");
        }
    }

    

}
