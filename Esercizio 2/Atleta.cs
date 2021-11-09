using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio_2
{
    class Atleta
    {
        //Gli atleti hanno nome, cognome, età

        public string Nome { get; set; }
        public string Cognome { get; set; }
        public int Età { get; set; }

        public Atleta(string nome, string cognome, int età)
        {
            Nome = nome;
            Cognome = cognome;
            Età = età;
        }
    
    }
}
