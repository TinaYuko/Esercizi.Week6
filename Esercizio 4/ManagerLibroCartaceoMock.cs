using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio_4
{
    class ManagerLibroCartaceoMock : ILibreriaManager<LibroCartaceo>
    {
        static List<LibroCartaceo> libriCartacei = new List<LibroCartaceo>()
        {
            new LibroCartaceo{CodiceISBN=12351, Titolo="Il signore degli anelli", Autore="J.R.R. Tolkien", NumeroPagine=3000, QuantitàMagazzino=5},
            new LibroCartaceo{CodiceISBN=12352, Titolo="I promessi sposi", Autore="Manzoni", NumeroPagine=250, QuantitàMagazzino=2},
            new LibroCartaceo{CodiceISBN=12353, Titolo="Il trono di spade", Autore="G. Martin", NumeroPagine=465, QuantitàMagazzino=6}
        };

        public bool Add(LibroCartaceo item)
        {
            throw new NotImplementedException();
        }

        public List<LibroCartaceo> GetAll()
        {
            return libriCartacei; 
        }

        public LibroCartaceo GetByIsbn(int isbn)
        {
            foreach (var item in libriCartacei)
            {
                if (item.CodiceISBN == isbn)
                {
                    return item;
                }
            }
            return null;
        }

        internal void ModificaQuantità(int codice, int quantitàNuova)
        {
            foreach (var item in libriCartacei)
            {
                if (item.CodiceISBN==codice)
                {
                    item.QuantitàMagazzino = quantitàNuova;
                }
            }
            Console.WriteLine("Quantità libri aggiornata correttamente!");
        }

        internal void GetLibroByTitolo(string titolo)
        {
            foreach (var item in libriCartacei)
            {
                if (item.Titolo == titolo)
                {
                    Console.WriteLine(item.ToString());
                }
            }
        }

        internal void AddLibro(int isbn, string t, string a, int numPag, int quantità)
        {
            LibroCartaceo l = new LibroCartaceo();
            l.CodiceISBN = isbn;
            l.Titolo = t;
            l.Autore = a;
            l.NumeroPagine = numPag;
            l.QuantitàMagazzino = quantità;
            libriCartacei.Add(l);
            Console.WriteLine("Libro aggiunto correttamente!");
        }
    }
}
