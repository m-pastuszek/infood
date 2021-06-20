using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using InFood.Klasy.Exceptions;
using InFood.Klasy.Menu;

namespace InFood.Klasy.Database
{
    class DatabaseOperations
    {
        public static int? LAST_INSERTED_ID;
        /*
         * POLECENIE SELECT
         */
        public static DataTable Select(string queryString)
        {
            string connectionString = DatabaseConnection.GetConnectionString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();

                DataTable dataTable = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

                dataAdapter.Fill(dataTable);

                return dataTable;
            }
        }

        /*
         * POLECENIE SELECT WHERE ...
         */
        public static DataTable SelectWithParams(string queryString, Dictionary<string, object> parameters)
        {
            string connectionString = DatabaseConnection.GetConnectionString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);

                command.Parameters.Clear();

                foreach (KeyValuePair<string, object> param in parameters)
                {
                    command.Parameters.AddWithValue(param.Key, param.Value);
                }

                command.Connection.Open();

                DataTable dataTable = new DataTable();

                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

                dataAdapter.Fill(dataTable);

                return dataTable;
            }
        }

        /*
         * POLECENIE INSERT
         */
        public static void Insert(string queryString, Dictionary<string, object> parameters)
        {
            string connectionString = DatabaseConnection.GetConnectionString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString + "SELECT CAST(scope_identity() AS int)", connection);

                command.Parameters.Clear();

                foreach (KeyValuePair<string, object> param in parameters)
                {
                    command.Parameters.AddWithValue(param.Key, param.Value);
                }

                command.Connection.Open();

                try
                {
                    LAST_INSERTED_ID = (Int32?)command.ExecuteScalar();
                    if (LAST_INSERTED_ID != null)
                    {

                        Console.WriteLine("Pomyślnie dodano do bazy.");
                    }
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2601) // jeśli kod błędu 2601 (duplikat wartości)
                    {
                        Console.WriteLine(new CannotInsertDuplicateKeyRow().Message);
                        HelperClasses.PressEnterToContinue();
                        Program.EntryMenu();
                    }
                    else
                    {
                        Console.WriteLine($"Wystąpił błąd: {ex.Message}");
                    }
                }
            }
        }

        /*
         * POLECENIE UPDATE
         */
        public static void Update(string queryString, Dictionary<string, object> parameters)
        {
            string connectionString = DatabaseConnection.GetConnectionString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);

                command.Parameters.Clear();

                foreach (KeyValuePair<string, object> param in parameters)
                {
                    command.Parameters.AddWithValue(param.Key, param.Value);
                }

                command.Connection.Open();

                try
                {
                    var rowsUpdated = command.ExecuteNonQuery();
                    if (rowsUpdated >= 1)
                    {
                        Console.WriteLine("Pomyślnie zaktualizowano dane.");
                    }
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2601) // jeśli kod błędu 2601 (duplikat wartości)
                    {
                        Console.WriteLine(new CannotInsertDuplicateKeyRow().Message);
                    }
                    else
                    {
                        Console.WriteLine($"Wystąpił błąd: {ex.Message}");
                    }
                }
            }
        }

        public static void Delete(string queryString, Dictionary<string, object> parameters)
        {
            string connectionString = DatabaseConnection.GetConnectionString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);

                command.Parameters.Clear();

                foreach (KeyValuePair<string, object> param in parameters)
                {
                    command.Parameters.AddWithValue(param.Key, param.Value);
                }

                command.Connection.Open();

                try
                {
                    var rowsUpdated = command.ExecuteNonQuery();
                    if (rowsUpdated >= 1)
                    {
                        Console.WriteLine("Pomyślnie usunięto z bazy.");
                    }
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2601) // jeśli kod błędu 2601 (duplikat wartości)
                    {
                        Console.WriteLine(new CannotInsertDuplicateKeyRow().Message);
                    }
                    else
                    {
                        Console.WriteLine($"Wystąpił błąd: {ex.Message}");
                    }
                }
            }
        }
    }
}
