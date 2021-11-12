using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestStazionePolizia
{
    public class Agente: Persona
    {
        /*L’agente ha le seguenti caratteristiche:
             - Nome
             - Cognome
             - Codice fiscale
             - Area geografica
             - Anno di inizio attività
        */
        public string AreaGeografica { get; set; }
        public int AnnoInizioAttività { get; set; }

        public Agente()
        {

        }
        public Agente(string nome, string cognome, string cf, string area, int anno)
            : base(nome, cognome, cf)
        {
            AreaGeografica = area;
            AnnoInizioAttività = anno;
        }

        /*I dati relativi all’agente devono essere stampati nel seguente formato:
          CF: CodiceFiscaleDell’Agente - Nome: IlNomeDellAgente – Cognome: IlCognomeDellAgente – Anni di Servizio: AnniDiServizioDellAgente
         Gli anni di servizio sono calcolati nel seguente modo: anno corrente(2021) meno l’anno di inizio attività.
         Ad es. se l’anno di inizio attività è 1993, gli anni di servizio sono 2021-1993 = 28 */
        public override string ToString()
        {
            return $"CF: {CodiceFiscale} - Nome: {Nome} – Cognome: {Cognome} – Anni di Servizio: {CalcoloAnniDiServizio(AnnoInizioAttività)}";
        }

        public int CalcoloAnniDiServizio(int annoInizio)
        {
            int anniDiServizio = DateTime.Now.Year - annoInizio;
            return anniDiServizio;
        }

    }
}
