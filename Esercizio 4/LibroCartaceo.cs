using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio_4
{
    class LibroCartaceo : Libro
    {
        // I libri cartacei hanno il numero di pagine e la quantità in magazzino
        public int NumeroPagine { get; set; }
        public int QuantitàMagazzino { get; set; }

        public LibroCartaceo()
        {

        }

        public LibroCartaceo(int codice, string titolo, string autore, int numPagine, int quantitaMag)
            : base (codice, titolo, autore)
        {
            NumeroPagine = numPagine;
            QuantitàMagazzino = quantitaMag;
        }
        public override string ToString()
        {
            return $"Codice: {CodiceISBN} - Titolo: {Titolo} - Autore: {Autore} - (Libro Cartaceo)";
        }
    }
}
