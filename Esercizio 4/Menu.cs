using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio_4
{
   public class Menu
    {
       /* --------------------------------------------------------------------------------------------------*/
        // private static ManagerAudiolibroMock dbAudiolibro = new ManagerAudiolibroMock();
        // private static ManagerLibroCartaceoMock dbLibroCartaceo = new ManagerLibroCartaceoMock();

        private static ManagerAudioLibro dbAudiolibro = new ManagerAudioLibro();
        private static ManagerLibroCartaceo dbLibroCartaceo = new ManagerLibroCartaceo();
        public static void Start()
        {
            Console.WriteLine("Libreria");
            bool continua = true;
            while (continua)
            {
                Console.WriteLine("--------------------------------Menu----------------------------");
                Console.WriteLine("1. Vedi libri presenti");
                Console.WriteLine("2. Vedi libri cartacei");
                Console.WriteLine("3. Vedi audiolibri");
                Console.WriteLine("4. Modifica la quantità dei libri cartacei in magazzino");
                Console.WriteLine("5. Modifica la durata di un audiolibro");
                Console.WriteLine("6. Cerca libri per titolo");
                Console.WriteLine("7. Inserisci un nuovo libro");
                Console.WriteLine("8. Elimina Film");

                Console.WriteLine("0. Exit");


                int scelta;
                do
                {
                    Console.WriteLine("Scegli cosa fare!");
                } while (!(int.TryParse(Console.ReadLine(), out scelta) && scelta >= 0 && scelta < 9));

                switch (scelta)
                {
                    case 1:
                        VisualizzaTutti();
                        break;
                    case 2:
                        VisualizzaLibriCartacei();
                        break;
                    case 3:
                        VisualizzaAudiolibri();
                        break;
                    case 4:
                        VisualizzaLibriCartacei();
                        ModificaQuantitàLibri();
                        break;
                    case 5:
                        VisualizzaAudiolibri();
                        ModificaDurataAudio();
                        break;
                    case 6:
                        CercaLibriTitolo();
                        break;
                    case 7:
                        Console.WriteLine("Premi 1 per inserire un libro cartaceo. \nPremi 2 per inserire un audiolibro");
                        int scelta2;
                        do
                        {
                            Console.WriteLine("Scegli cosa fare!");
                        } while (!(int.TryParse(Console.ReadLine(), out scelta2) && scelta2 >= 0 && scelta2 < 3));

                        switch (scelta2)
                        {
                            case 1:
                                AggiungiLibroCartaceo();
                                break;
                            case 2:
                                AggiungiAudiolibro();
                                break;
                        }
                        break;
                    case 8:

                        break;
                    
                    case 0:
                        continua = false;
                        break;
                }
            }
        }

        private static void AggiungiAudiolibro()
        {
            Console.Write("Inserisci Codice ISBN: ");
            int isbn;
            while (!(int.TryParse(Console.ReadLine(), out isbn) && isbn > 0))
            {
                Console.WriteLine("Valore errato. Riprova:");
            }
            Console.Write("Inserisci il titolo: ");
            string t = Console.ReadLine();
            Console.Write("Inserisci l'autore: ");
            string a = Console.ReadLine();
            int durata;
            Console.Write("Inserisci durata audiolibro:");

            while (!(int.TryParse(Console.ReadLine(), out durata) && durata > 0))
            {
                Console.WriteLine("Valore errato. Riprova:");
            }
            
            dbAudiolibro.AddLibro(isbn, t, a, durata);
        }

        private static void AggiungiLibroCartaceo()
        {
            Console.Write("Inserisci Codice ISBN: ");
            int isbn;
            while (!(int.TryParse(Console.ReadLine(), out isbn) && isbn > 0))
            {
                Console.WriteLine("Valore errato. Riprova:");
            }
            Console.Write("Inserisci il titolo: ");
            string t = Console.ReadLine();
            Console.Write("Inserisci l'autore: ");
            string a = Console.ReadLine();
            int numPag;
            Console.Write("Inserisci il numero delle pagine:");

            while (!(int.TryParse(Console.ReadLine(), out numPag) && numPag > 0))
            {
                Console.WriteLine("Valore errato. Riprova:");
            }
            int quantità;
            Console.Write("Quanti libri devi aggiungere al magazzino? ");

            while (!(int.TryParse(Console.ReadLine(), out quantità) && quantità > 0))
            {
                Console.WriteLine("Valore errato. Riprova:");
            }

            dbLibroCartaceo.AddLibro(isbn, t, a, numPag, quantità);
        }

        private static void CercaLibriTitolo()
        {
            Audiolibro a = new Audiolibro();
            LibroCartaceo l = new LibroCartaceo();

            Console.Write("Inserisci titolo da ricercare: ");
            string titolo;
            titolo = Console.ReadLine();
            a= dbAudiolibro.GetLibroByTitolo(titolo);
            Console.WriteLine(a.ToString());

            l = dbLibroCartaceo.GetLibroByTitolo(titolo);
            Console.WriteLine(l.ToString());


        }

        private static void ModificaDurataAudio()
        {
            int codice;
            Console.Write("Digita il codice ISBN dell'audiolibro: ");
            while (!(int.TryParse(Console.ReadLine(), out codice) && codice > 0))
            {
                Console.WriteLine("Valore errato. Riprova:");
            }
            int durataNuova;
            Console.Write("Aggiorna la nuova durata dell'audiolibro: ");
            while (!(int.TryParse(Console.ReadLine(), out durataNuova) && durataNuova > 0))
            {
                Console.WriteLine("Valore errato. Riprova:");
            }
            dbAudiolibro.ModificaDurata(codice, durataNuova);
        }

        private static void ModificaQuantitàLibri()
        {
            int codice;
            Console.Write("Digita il codice ISBN del libro: ");
            while (!(int.TryParse(Console.ReadLine(), out codice) && codice > 0))
            {
                Console.WriteLine("Valore errato. Riprova:");
            }
            int quantitàNuova;
            Console.Write("Aggiorna la quantità dei libr: ");
            while (!(int.TryParse(Console.ReadLine(), out quantitàNuova) && quantitàNuova > 0))
            {
                Console.WriteLine("Valore errato. Riprova:");
            }
            dbLibroCartaceo.ModificaQuantità(codice, quantitàNuova);
        }

        private static void VisualizzaAudiolibri()
        {
            Console.WriteLine("Tutti gli audiolibri presenti nella biblioteca sono:\n");
            List<Audiolibro> audiolibri = dbAudiolibro.GetAll();
            int numElenco = 1;
            foreach (var item in audiolibri)
            {
                Console.WriteLine($"{numElenco++}. {item.ToString()}");
            }
        }

        private static void VisualizzaLibriCartacei()
        {
            Console.WriteLine("Tutti i Libri cartacei presenti nella biblioteca sono:\n");
            List<LibroCartaceo> libriCartacei = dbLibroCartaceo.GetAll();
            int numElenco = 1;
            foreach (var item in libriCartacei)
            {
                Console.WriteLine($"{numElenco++}. {item.ToString()}");
            }
        }

        private static void VisualizzaTutti()
        {
            Console.WriteLine("Tutti i Libri presenti nella biblioteca sono:\n");
            List<LibroCartaceo> libriCartacei = dbLibroCartaceo.GetAll();
            List<Audiolibro> audiolibri = dbAudiolibro.GetAll();

            List<Libro> listaLibri = new List<Libro>();
            listaLibri.AddRange(libriCartacei);
            listaLibri.AddRange(audiolibri);
            int numElenco = 1;
            foreach (var item in listaLibri)
            {
                Console.WriteLine($"{numElenco++}. {item.ToString()}");
            }
        }
    }
}
