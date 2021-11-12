using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestStazionePolizia
{
    public class Menu
    {
        //private static DBManagerPolizia dbAgenti = new DBManagerPolizia(); //Con DB
        private static DBManagerMock dbAgenti= new DBManagerMock(); //Senza DB
        public static void Start()
        {
            /*Implementare una Console App che tramite menù permetta di:
                - Mostrare tutti gli agenti di polizia
                - Scelta un’area geografica, mostrare gli agenti assegnati a quell’area
                - Scelti gli anni di servizio, mostrare gli agenti con anni di servizio maggiori o uguali rispetto all’input
                - Inserire un nuovo agente solo se non è già presente nel database
            */

            Console.WriteLine("Benvenut* al Menù principale della Stazione di Polizia di Quartu Sant'Elena.");
            bool continua = true;
            while (continua)
            {
                Console.WriteLine("Si prega di premere: ");
                Console.WriteLine("[1] Per poter visionare gli Agenti di Polizia della Stazione");
                Console.WriteLine("[2] Per visionare gli Agenti presenti in un'area Geografica");
                Console.WriteLine("[3] Per visionare gli Agenti di Polizia con anni di servizio superiore ad un determinato input ");
                Console.WriteLine("[4] Per candidare un nuovo Agente nella nostra Stazione.");
                Console.WriteLine("[0] Per uscire");


                int scelta;
                do
                {
                    Console.WriteLine("Si prega di scegliere");
                } while (!(int.TryParse(Console.ReadLine(), out scelta) && scelta >= 0 && scelta < 5));

                switch (scelta)
                {
                    case 1:
                        VisualizzaAgenti();
                        break;
                    case 2:
                        CercaAgentiPerArea();
                        break;
                    case 3:
                        CercaAgentiPerAnni();
                        break;
                    case 4:
                        InserisciAgente();
                        break;
                    case 0:
                        Console.WriteLine("La ringraziamo per aver visionato il nostro portale. Arrivederci!");
                        continua = false;
                        break;
                }
            }
        }

        private static void InserisciAgente()
        {
            Console.Write("Inserisci Codice Fiscale: ");
            string cf = Console.ReadLine();
            if (dbAgenti.GetByCF(cf))
            {


                Console.Write("Inserisci Nome: ");
                string nome = Console.ReadLine();
                Console.Write("Inserisci Cognome: ");
                string cognome = Console.ReadLine();
                Console.Write("Inserisci Area Geografica: ");
                string area = Console.ReadLine();
                int anno;
                Console.Write("Inserisci l'anno in cui ha iniziato la sua carriera: ");
                while (!(int.TryParse(Console.ReadLine(), out anno) && anno > 1950 && anno < 2021))
                {
                    Console.WriteLine("Valore errato. Riprova:");
                }

                var agente = new Agente(nome, cognome, cf, area, anno);
                dbAgenti.Add(agente);
            }
            else
            {
                Console.WriteLine("Agente già candidato!");
            }

        }

        private static void CercaAgentiPerAnni()
        {
            int anni;
            Console.Write("Inserisci gli anni di servizio minimo: ");
            while (!(int.TryParse(Console.ReadLine(), out anni) && anni > 0))
            {
                Console.WriteLine("Valore errato. Riprova:");
            }
            var a = dbAgenti.GetByAnni(anni);
            List<Agente> agenti = new List<Agente>();
            agenti.Add(a);
            Console.WriteLine("Gli Agenti richiesti sono:");
            foreach (var item in agenti)
            {
                Console.WriteLine(item.ToString());
            }
        }

        private static void CercaAgentiPerArea()
        {
            Console.WriteLine("Le aree disponibili sono: ");
            dbAgenti.StampaArea();
            Console.Write("Inserisci l'area da visionare: ");
            string areaDaCercare = Console.ReadLine();
            var a = dbAgenti.GetByArea(areaDaCercare);
            List<Agente> agenti = new List<Agente>();
            agenti.Add(a);
            Console.WriteLine("Gli Agenti presenti in quest'area sono:");
            foreach (var item in agenti)
            {
                Console.WriteLine(item.ToString());
            }
        }

        private static void VisualizzaAgenti()
        {
            Console.WriteLine("Tutti gli Agenti della Stazione sono: ");
            List<Agente> agenti = dbAgenti.GetAll();
            foreach (var item in agenti)
            {
                Console.WriteLine(item.ToString());
            }

        }
    }
}
