using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio_4
{
    class ManagerLibroCartaceo : ILibreriaManager<LibroCartaceo>
    {
        const string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog = LibreriaAdo; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        static List<LibroCartaceo> libriCartacei = new List<LibroCartaceo>();


        public List<LibroCartaceo> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "select * from LibroCartaceo";

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {

                    var id = reader["CodiceISBN"];
                    var titolo = reader["Titolo"];
                    var autore = reader["Autore"];
                    var numPag = reader["NumeroPagine"];
                    var quantità = reader["QuantitàMagazzino"];


                    LibroCartaceo l = new LibroCartaceo()
                    {
                        CodiceISBN = (int)id,
                        Titolo = (string)titolo,
                        Autore = (string)autore,
                        NumeroPagine = (int)numPag,
                        QuantitàMagazzino= (int)quantità
                    };
                    libriCartacei.Add(l);

                }
                connection.Close();
                return libriCartacei;
            }
        }

        public LibroCartaceo GetByIsbn(int isbn)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "select * from LibroCartaceo where CodiceISBN= @isbn";
                command.Parameters.AddWithValue("@isbn", isbn);

                SqlDataReader reader = command.ExecuteReader();
                LibroCartaceo l = new LibroCartaceo();
                while (reader.Read())
                {
                    var id = reader["CodiceISBN"];
                    var title = reader["Titolo"];
                    var autore = reader["Autore"];
                    var numPag = reader["NumeroPagine"];
                    var quantità = reader["QuantitàMagazzino"];


                    l.CodiceISBN = (int)id;
                    l.Titolo = (string)title;
                    l.Autore = (string)autore;
                    l.NumeroPagine = (int)numPag;
                    l.QuantitàMagazzino = (int)quantità;


                }
                connection.Close();
                return l;
            }
        }

        internal void ModificaQuantità(int codice, int quantitàNuova)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "update LibroCartaceo set QuantitàMagazzino=@Q where CodiceISBN=@Id";
                command.Parameters.AddWithValue("@Id", codice);
                command.Parameters.AddWithValue("@Durata", quantitàNuova);

                int rigaInserita = command.ExecuteNonQuery();
                if (rigaInserita == 1)
                {
                    Console.WriteLine("Quantità aggiornata correttamente");
                }
                else
                {
                    Console.WriteLine("Errore. Non è stato possibile aggiornare la quantità. Ricontrolla i dati inseriti!");
                }
            }
        }

        internal LibroCartaceo GetLibroByTitolo(string titolo)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "select * from LibroCartaceo where Titolo= @t";
                command.Parameters.AddWithValue("@t", titolo);

                SqlDataReader reader = command.ExecuteReader();
                LibroCartaceo l = new LibroCartaceo();
                while (reader.Read())
                {
                    var id = reader["CodiceISBN"];
                    var title = reader["Titolo"];
                    var autore = reader["Autore"];
                    var numPag = reader["NumeroPagine"];
                    var quantità = reader["QuantitàMagazzino"];


                    l.CodiceISBN = (int)id;
                    l.Titolo = (string)title;
                    l.Autore = (string)autore;
                    l.NumeroPagine = (int)numPag;
                    l.QuantitàMagazzino = (int)quantità;


                }
                connection.Close();
                return l;
            }
        }

        internal void AddLibro(int isbn, string t, string a, int numPag, int quantità)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "insert into LibroCartaceo values( @Isbn, @Titolo, @Autore @Num, @Q)";
                command.Parameters.AddWithValue("@Isbn", isbn);
                command.Parameters.AddWithValue("@Titolo", t);
                command.Parameters.AddWithValue("@Autore", a);
                command.Parameters.AddWithValue("@Num", numPag);
                command.Parameters.AddWithValue("@Q", quantità);

                int rigaInserita = command.ExecuteNonQuery();
                if (rigaInserita == 1)
                {
                    Console.WriteLine("Libro inserito correttamente");
                }
                else
                {
                    Console.WriteLine("Errore.Non è stato possibile inserire il libro");
                }
            }
        }
    }
}
