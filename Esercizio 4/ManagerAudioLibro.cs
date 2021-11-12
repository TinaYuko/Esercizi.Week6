using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio_4
{
    class ManagerAudioLibro : ILibreriaManager<Audiolibro>
    {
        static List<Audiolibro> audiolibri = new List<Audiolibro>();
        const string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog = LibreriaAdo; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
 

        public List<Audiolibro> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "select * from Audiolibro";

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {

                    var id = reader["CodiceISBN"];
                    var titolo = reader["Titolo"];
                    var autore = reader["Autore"];
                    var durata = reader["Durata"];


                    Audiolibro a = new Audiolibro()
                    {
                        CodiceISBN = (int)id,
                        Titolo = (string)titolo,
                        Autore = (string)autore,
                        Durata = (int)durata
                    };
                    audiolibri.Add(a);

                }
                connection.Close();
                return audiolibri;
            }
        }

        public Audiolibro GetByIsbn(int isbn)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "select * from Audiolibro where CodiceISBN= @isbn";
                command.Parameters.AddWithValue("@Isbn", isbn);

                SqlDataReader reader = command.ExecuteReader();
                Audiolibro a = new Audiolibro();
                while (reader.Read())
                {
                    var id = reader["CodiceISBN"];
                    var title = reader["Titolo"];
                    var autore = reader["Autore"];
                    var durata = reader["Durata"];

                    a.CodiceISBN = (int)id;
                    a.Titolo = (string)title;
                    a.Autore = (string)autore;
                    a.Durata = (int)durata;



                }
                connection.Close();
                return a;

            }
        }

        internal void AddLibro(int isbn, string t, string a, int durata)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "insert into Audiolibro values( @Isbn, @Titolo, @Autore @Durata)";
                command.Parameters.AddWithValue("@Isbn", isbn);
                command.Parameters.AddWithValue("@Titolo", t);
                command.Parameters.AddWithValue("@Autore", a);
                command.Parameters.AddWithValue("@Durata", durata);

                int rigaInserita = command.ExecuteNonQuery();
                if (rigaInserita == 1)
                {
                    Console.WriteLine("Audiolibro inserito correttamente");
                }
                else
                {
                    Console.WriteLine("Errore.Non è stato possibile inserire l'audiolibro");
                }
            }
        }

        internal Audiolibro GetLibroByTitolo(string titolo)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "select * from Audiolibro where Titolo= @t";
                command.Parameters.AddWithValue("@t", titolo);

                SqlDataReader reader = command.ExecuteReader();
                Audiolibro a = new Audiolibro();
                while (reader.Read())
                {
                    var id = reader["CodiceISBN"];
                    var title = reader["Titolo"];
                    var autore = reader["Autore"];
                    var durata = reader["Durata"];

                    a.CodiceISBN = (int)id;
                    a.Titolo = (string)title;
                    a.Autore = (string)autore;
                    a.Durata = (int)durata;
                    

                  
                }
                connection.Close();
                return a;
                
            }
        }

        internal void ModificaDurata(int codice, int durataNuova)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "update Audiolibro set Durata=@Durata where CodiceISBN=@Id";
                command.Parameters.AddWithValue("@Id", codice);
                command.Parameters.AddWithValue("@Durata", durataNuova);

                int rigaInserita = command.ExecuteNonQuery();
                if (rigaInserita == 1)
                {
                    Console.WriteLine("Durata aggiornata correttamente");
                }
                else
                {
                    Console.WriteLine("Errore. Non è stato possibile aggiornare la durata. Ricontrolla i dati inseriti!");
                }
            }
        }
    }
}
