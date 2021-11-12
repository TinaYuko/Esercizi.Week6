using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio_4
{
    abstract class Libro
    {
        //I libri hanno titolo - autore - codice ISBN
        public int CodiceISBN { get; set; }
        public string Titolo { get; set; }
        public string  Autore { get; set; }

        public Libro()
        {

        }
        public Libro(int codice, string titolo, string autore)
        {
            CodiceISBN = codice;
            Titolo = titolo;
            Autore = autore;
        }

        public override string ToString()
        {
            return $"Codice: {CodiceISBN} - Titolo: {Titolo} - Autore: {Autore}";
        }

    }
}
