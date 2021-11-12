using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestStazionePolizia
{
    public abstract class Persona
    {
        /*L’agente deriva da un’astrazione di persona. La persona ha le seguenti caratteristiche:
            - Nome
            - Cognome
            - Codice fiscale 
        */
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string CodiceFiscale { get; set; }

        public Persona()
        {

        }
        public Persona(string nome, string cognome, string cf)
        {
            Nome = nome;
            Cognome = cognome;
            CodiceFiscale = cf;
        }
    }
}
