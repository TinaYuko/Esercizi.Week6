using System;
using System.Collections.Generic;

namespace Esercizio_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Stagista s = new Stagista("Martina", "Mattana");
            s.StampaStipendio();
            s.StampaRuolo();

            Tecnico t = new Tecnico("Mario", "Rossi", "CFMARIOROSSI");
            Manager m = new Manager("Nenno", "Lello", "CFNENNOLELLO", 20);

            //Tutti i figli sono dipendenti
            Dipendente d = t;

            List<Dipendente> dipendentiAzienda = new List<Dipendente>();
            dipendentiAzienda.Add(m);
            dipendentiAzienda.Add(s);
            dipendentiAzienda.Add(t);

            foreach (var item in dipendentiAzienda)
            {
                item.StampaDatiAnagrafici();
                item.StampaRuolo();
                item.StampaStipendio();
                Console.WriteLine("---");
            }

        }
    }
}
