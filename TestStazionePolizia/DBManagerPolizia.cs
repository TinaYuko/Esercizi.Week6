using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestStazionePolizia
{
    public class DBManagerPolizia : IManagerPolizia<Agente>

    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ProvaAgenti;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public void Add(Agente item)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "insert into Agente values(@Nome, @Cognome, @CF, @Area, @Anni)";
                command.Parameters.AddWithValue("@Nome", item.Nome);
                command.Parameters.AddWithValue("@Cognome", item.Cognome);
                command.Parameters.AddWithValue("@CF", item.CodiceFiscale);
                command.Parameters.AddWithValue("@Area", item.AreaGeografica);
                command.Parameters.AddWithValue("@Anni", item.AnnoInizioAttività);

                int numRighe = command.ExecuteNonQuery();
                if (numRighe == 1)
                {
                    connection.Close();
                    Console.WriteLine("Agente candidato correttamente");
                }
                else
                {
                    Console.WriteLine("Errore.");

                }
                connection.Close();
            }
               
        }

        public List<Agente> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from Agente";

                SqlDataReader reader = command.ExecuteReader();

                List<Agente> agenti = new List<Agente>();

                while (reader.Read())
                {
                    string nome= (string)reader["Nome"];
                    string cognome = (string)reader["Cognome"];
                    string cf = (string)reader["Codice fiscale"];
                    string area = (string)reader["Area geografica"];
                    int anno = (int)reader["Anno di inizio attività"];

                    Agente a = new Agente(nome, cognome, cf, area, anno);
                    agenti.Add(a);
                }
                connection.Close();
                return agenti;
            }
        }

        public bool GetByCF(string cfToCheck)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from Agente where [Codice fiscale] <= @cf";

                command.Parameters.AddWithValue("@cf", cfToCheck);

                SqlDataReader reader = command.ExecuteReader();
                List<Agente> agenti = new List<Agente>();
                Agente agente = null;

                while (reader.Read())
                {
                    string nome = (string)reader["Nome"];
                    string cognome = (string)reader["Cognome"];
                    string cf = (string)reader["Codice fiscale"];
                    string area = (string)reader["Area geografica"];
                    int anno = (int)reader["Anno di inizio attività"];

                    agente = new Agente(nome, cognome, cf, area, anno);
                }
                agenti.Add(agente);

                int count = 0;
                foreach (var item in agenti)
                {
                    if (cfToCheck==item.CodiceFiscale)
                    {
                        count++;
                    }
                }
                if (count==0)
                {
                    return true;
                    
                }
                else
                {
                    return false;
                }
                
                
            }
        }

        internal void StampaArea()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select [Area geografica] from Agente";

                SqlDataReader reader = command.ExecuteReader();

                List<Agente> agenti = new List<Agente>();

                while (reader.Read())
                {
                    
                    string area = (string)reader["Area geografica"];
                   

                    Console.WriteLine($"- {area}");

                }
                connection.Close();
                
            }
        }

        public Agente GetByAnni(int annoMin)
        {
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from Agente where  DATEPART(year, CURRENT_TIMESTAMP) - [Anno di inizio attività] >= @a";

                command.Parameters.AddWithValue("@a", annoMin);

                SqlDataReader reader = command.ExecuteReader();

                Agente agente = null;

                while (reader.Read())
                {
                    string nome = (string)reader["Nome"];
                    string cognome = (string)reader["Cognome"];
                    string cf = (string)reader["Codice fiscale"];
                    string area = (string)reader["Area geografica"];
                    int anno = (int)reader["Anno di inizio attività"];

                    agente = new Agente(nome, cognome, cf, area, anno);
                }
                connection.Close();
                return agente;
            }
        }
        public Agente GetByArea(string areaDaCercare)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from Agente where [Area geografica] = @a";
                command.Parameters.AddWithValue("@a", areaDaCercare);

                SqlDataReader reader = command.ExecuteReader();

                Agente agente = null;

                while (reader.Read())
                {
                    string nome = (string)reader["Nome"];
                    string cognome = (string)reader["Cognome"];
                    string cf = (string)reader["Codice fiscale"];
                    string area = (string)reader["Area geografica"];
                    int anno = (int)reader["Anno di inizio attività"];

                    agente = new Agente(nome, cognome, cf, area, anno);
                }
                connection.Close();
                return agente;
            }
        }
    }
}
