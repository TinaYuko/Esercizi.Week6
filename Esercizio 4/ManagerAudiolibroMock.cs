using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio_4
{
    class ManagerAudiolibroMock : ILibreriaManager<Audiolibro>
    {
        static List<Audiolibro> audiolibri = new List<Audiolibro>()
        {
            new Audiolibro{CodiceISBN=12341, Titolo="La bussola d'oro", Autore="Nenno a caso", Durata=1000, IsAudiolibro=true},
            new Audiolibro{CodiceISBN=12342, Titolo="Il signore degli anelli", Autore="J.R.R. Tolkien", Durata=2000, IsAudiolibro=true }
        };

        public bool Add(Audiolibro item)
        {
            throw new NotImplementedException();
        }

        public List<Audiolibro> GetAll()
        {
            return audiolibri;
        }

        public Audiolibro GetByIsbn(int isbn)
        {
            foreach (var item in audiolibri)
            {
                if (item.CodiceISBN == isbn)
                {
                    return item;
                }
            }
            return null;
        }

        internal void ModificaDurata(int codice, int durataNuova)
        {
            foreach (var item in audiolibri)
            {
                if (item.CodiceISBN == codice)
                {
                    item.Durata = durataNuova;
                }
            }
            Console.WriteLine("Durata audiolibri aggiornata correttamente!");
        }

        internal void GetLibroByTitolo(string titolo)
        {
            foreach (var item in audiolibri)
            {
                if (item.Titolo == titolo)
                {
                    Console.WriteLine(item.ToString());
                }
            }
        }

        internal void AddLibro(int isbn, string t, string aut, int durata)
        {
            Audiolibro a = new Audiolibro();
            a.CodiceISBN = isbn;
            a.Titolo = t;
            a.Autore = aut;
            a.Durata = durata;
            audiolibri.Add(a);
            Console.WriteLine("Audiolibro aggiunto correttamente!");
        }
    }
}
