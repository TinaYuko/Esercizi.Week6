using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio_3
{
    static class Menu
    {
        public static void Start()
        {
            Console.WriteLine("Hola! Vieni a scoprire Area e Perimetro delle forme geometriche!");
            bool exit = true;
            do
            {
                Console.WriteLine("\nPremi: \n[1] Per inserire figura geometrica" +
                    "\n[2] Controllare che figure abbiamo nella lista" +
                    "\n[3] Per calcolarne il Perimetro" +
                    "\n[4] Per calcolarne l'Area" +
                    "\n[0] per uscire!");


                int choice;
                do
                {
                    Console.WriteLine("Su, forza! Scegli!");
                }
                while (!(int.TryParse(Console.ReadLine(), out choice) && choice >= 0 && choice < 5));

                switch (choice)
                {
                    case 1:
                        ScelgoFigura();
                        break;
                    case 2:
                        Manager.StampoFigure();
                        break;
                    case 3:
                        Manager.StampoPerimetro();
                        break;
                    case 4:
                        Manager.StampoArea();
                        break;
                    case 0:
                        Console.WriteLine("Tutto fatto? Bene, ciao!!!");
                        exit = false;
                        break;
                }
            }
            while (exit);
        }

        private static void ScelgoFigura()
        {
            bool exit = true;
            do
            {
                Console.WriteLine("[1] Triangolo" +
                    "\n[2] Quadrato" +
                    "\n[3] Rettangolo" +
                    "\n[4] Cerchio" +
                    "\n[0] Per tornare indietro.");


                int choice;
                do
                {
                    Console.WriteLine("Su, forza! Scegli!");
                }
                while (!(int.TryParse(Console.ReadLine(), out choice) && choice >= 0 && choice < 5));

                switch (choice)
                {
                    case 1:
                        Console.Write("Inserisci base: ");
                        double base1 = Convert.ToDouble(Console.ReadLine());
                        Console.Write("Inserisci altezza: ");
                        double altezza = Convert.ToDouble(Console.ReadLine());
                        FormaGeometrica t = new Triangolo("Triangolo", base1, altezza);
                        Manager.AggiungiForma(t);
                        break;
                    case 2:
                        Console.Write("Inserisci lato: ");
                        double lato = Convert.ToDouble(Console.ReadLine());
                        FormaGeometrica q = new Quadrato("Quadrato", lato);
                        Manager.AggiungiForma(q);
                        break;
                    case 3:
                        Console.Write("Inserisci base: ");
                        double base2 = Convert.ToDouble(Console.ReadLine());
                        Console.Write("Inserisci altezza: ");
                        double altezza2 = Convert.ToDouble(Console.ReadLine());
                        FormaGeometrica r = new Rettangolo("Rettangolo", base2, altezza2);
                        Manager.AggiungiForma(r);
                        break;
                    case 4:
                        Console.Write("Inserisci raggio: ");
                        double raggio = Convert.ToDouble(Console.ReadLine());
                        FormaGeometrica c = new Quadrato("Cerchio", raggio);
                        Manager.AggiungiForma(c);
                        break;
                    case 0:
                        Console.WriteLine("Perfetto, ora cosa vuoi fare?");
                        exit = false;
                        break;
                }
            }
            while (exit);

        }

       

        
    }
}
