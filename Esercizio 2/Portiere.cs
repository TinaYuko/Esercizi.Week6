using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio_2
{
    class Portiere : Calciatore
    {
        //Portieri hanno di default il numero maglia = 1 e il numero gol subiti

        public int GoalSubiti { get; set; } = 0;
    
        public Portiere(string nome, string cognome, int età /*, int numeroMaglia, Ruolo ruolo*/)
            : base(nome, cognome, età, 1, Ruolo.Portiere)
        {
        
        }
    
    }

    

}
