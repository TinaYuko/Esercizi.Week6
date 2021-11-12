using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio_4
{
    class Audiolibro: Libro
    {
        // Gli audiolibri hanno anche la durata in minuti
        public int Durata { get; set; }
        public bool IsAudiolibro { get; set; } = true;

        public Audiolibro()
        {

        }
        public Audiolibro(int codice, string titolo, string autore, int durata, bool isAudio)
            : base (codice, titolo, autore)
        {
            Durata = durata;
            IsAudiolibro = isAudio;
        }
        public override string ToString()
        {
            return $"Codice: {CodiceISBN} - Titolo: {Titolo} - Autore: {Autore} - (Audiolibro)";
        }
    }
}
