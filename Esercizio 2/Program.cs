using System;
using System.Collections.Generic;

namespace Esercizio_2
{
    class Program
    {
        static void Main(string[] args)
        {



            // Una squadra di calcio è formata da 11 calciatori di cui
            // un portiere
            // 4 difensori
            // 4 centrocampisti
            // 2 attaccanti

            //Per svolgere una partita serve anche un arbitro(l'arbitro è un atleta)
            Console.WriteLine("Calcio");

            List<Calciatore> squadra1 = new List<Calciatore>();

            Portiere p = new Portiere("Antonio", "Donnaruma", 20);
            Calciatore d1 = new Calciatore("Alessio", "Romagnoli", 22, 13, Ruolo.Difensore);
            Calciatore c1 = new Calciatore("Francesco", "Barella", 25, 12, Ruolo.Centrocampista);
            Attaccante a1 = new Attaccante("Alex", "Marquez", 30, 8);

            SquadraManager.AddCalciatore(p, squadra1);
            SquadraManager.AddCalciatore(d1, squadra1);
            SquadraManager.AddCalciatore(c1, squadra1);
            SquadraManager.AddCalciatore(a1, squadra1);

            Console.WriteLine("La rosa della squadra1 è:");
            foreach (var item in squadra1)
            {
                Console.WriteLine(item.ToString());
            }

            Portiere p1 = new Portiere("Gigi", "Buffon", 43);
            SquadraManager.AddCalciatore(p1, squadra1);




        }
    }
}
