using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio_2
{
    class Attaccante: Calciatore
    {
        //Gli attaccanti hanno il numero gol fatti a partita

        public int GoalFatti { get; set; } = 0;


        public Attaccante(string nome, string cognome, int età, int numeroMaglia)
            :base(nome, cognome, età, numeroMaglia, Ruolo.Attaccante)
        {
            
        }



    }
}
