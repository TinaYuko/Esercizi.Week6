using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestStazionePolizia
{
    class DBManagerMock : IManagerPolizia<Agente>
    {
        static List<Agente> agenti = new List<Agente>()
        {
            new Agente{Nome="Mario", Cognome="Abis", CodiceFiscale="MROABS90C12B354A", AreaGeografica="Pula", AnnoInizioAttività=2018},
            new Agente{Nome="Sara", Cognome="Collu", CodiceFiscale="SRACLL73H44C543Y", AreaGeografica="Quartu Sant'Elena", AnnoInizioAttività=1990},
            new Agente{Nome="Carla", Cognome="Dessì", CodiceFiscale="DSSCRL73H44C543Y", AreaGeografica="Quartu Sant'Elena", AnnoInizioAttività=2020},
            new Agente{Nome="Giorgio", Cognome="Manca", CodiceFiscale="MNCGRG73H44C543Y", AreaGeografica="Cagliari", AnnoInizioAttività=2000},
            new Agente{Nome="Lello", Cognome="Pilia", CodiceFiscale="PLILLL73H44C543Y", AreaGeografica="Sestu", AnnoInizioAttività=2006},
        
        };
        public void Add(Agente item)
        {
            agenti.Add(item);
            Console.WriteLine("Agente candidato correttamente");
            
        }

        public List<Agente> GetAll()
        {
            return agenti;
        }

        public Agente GetByAnni(int anni)
        {
           
            foreach (var item in agenti)
            {
                int anniDiservizio = item.CalcoloAnniDiServizio(item.AnnoInizioAttività);
                if (anniDiservizio>anni)
                {
                    return item;
                }
            }
            return null;
        }
        public bool GetByCF(string cf)
        {

            foreach (var item in agenti)
            {
                if (item.CodiceFiscale==cf)
                {
                    return false;
                }
            }
            return true;
        }

        public Agente GetByArea(string area)
        {
            foreach (var item in agenti)
            {
                if (item.AreaGeografica == area)
                {
                    return item;
                }
            }
            return null;
        }
        internal void StampaArea()
        {
            foreach (var item in agenti)
            {
                Console.WriteLine($"-{item.AreaGeografica}");
            }
        }
    }
}
