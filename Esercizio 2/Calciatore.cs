using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio_2
{
    class Calciatore: Atleta
    {
        //Calciatori hannno ruolo e numero maglia(ruoli = centrocampista e difensore portiere e attaccante)

        public int NumeroMaglia { get; set; }
        public Ruolo Ruolo { get; set; }

        public Calciatore(string nome, string cognome, int età, int numeroMaglia, Ruolo ruolo)
            :base (nome, cognome, età)
        {
            NumeroMaglia = numeroMaglia;
            Ruolo = ruolo;
        }

        public override string ToString()
        {
            return $"Maglia n. {NumeroMaglia} - {Nome} {Cognome}. Ruolo: {Ruolo}";
        }
    }
    public enum Ruolo
    {
        Attaccante, Centrocampista, Difensore, Portiere
    }
}
