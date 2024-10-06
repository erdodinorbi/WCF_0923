using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WCF_0923_server.DatabaseManager;
using WCF_0923_server.Models;

namespace WCF_0923_server.Controllers
{
    public class JogosultsagokController : BaseDatabaseManager, ISQL
    {
        public string Delete(int id)
        {
            MySqlCommand cmd = new MySqlCommand()
            {
                CommandType = System.Data.CommandType.Text,
                CommandText = "DELETE FROM Jogosultsagok WHERE Id = @Id;",
                Connection = BaseDatabaseManager.Connection
            };
            cmd.Parameters.Add(new MySqlParameter("@Id", id));

            try
            {
                cmd.Connection.Open();
                int toroltRekordok = cmd.ExecuteNonQuery();
                if (toroltRekordok == 0)
                {
                    return $"Nem található ilyen azonosító {id}";
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Hiba! " + e.Message);
            }
            finally
            {
                Connection.Close();
            }
            cmd.Parameters.Clear();
            return $"Sikeres törlés {id}";
        }

        public string Insert(Record record)
        {
            MySqlCommand cmd = new MySqlCommand()
            {
                CommandType = System.Data.CommandType.Text,
                CommandText = "INSERT INTO jogosultsagok (Szint, Nev, Leiras) VALUES (@Szint, @Nev, @Leiras)",
                Connection = BaseDatabaseManager.Connection
            };
            Jogosultsagok ujJogosultsag = record as Jogosultsagok;
            cmd.Parameters.Add(new MySqlParameter("@Szint", ujJogosultsag.Szint));
            cmd.Parameters.Add(new MySqlParameter("@Nev", ujJogosultsag.Nev));
            cmd.Parameters.Add(new MySqlParameter("@Leiras", ujJogosultsag.Leiras));

            try
            {
                cmd.Connection.Open();
                int db = cmd.ExecuteNonQuery();
                if (db == 0)
                {
                    return $"Nem sikerült rögzítenem a felhasználót! {ujJogosultsag.Nev}";
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Hiba történt a rögzítés során\n{e.Message}");
            }
            finally
            {
                BaseDatabaseManager.Connection.Close();
            }
            return "Sikeres rögzítés";
        }

        public List<Record> Select()
        {
            List<Record> list = new List<Record>();
            MySqlCommand cmd = new MySqlCommand()
            {
                CommandType = System.Data.CommandType.Text,
                CommandText = "SELECT * FROM Jogosultsagok;"
            };
            try
            {
                MySqlConnection conn = BaseDatabaseManager.Connection;
                conn.Open();
                cmd.Connection = conn;
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Jogosultsagok ujJog = new Jogosultsagok() {
                        Id = reader.GetInt32("Id"),
                        Szint = reader.GetInt32("Szint"),
                        Nev = reader.GetString("Nev"),
                        Leiras = reader.GetString("Leiras")
                    };
                    list.Add(ujJog);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Hiba történt a beolvasáskor!\n{e.Message}");
            }
            finally
            {
                BaseDatabaseManager.Connection.Close();
            }
            return list;
        }

        public string Update(Record record)
        {
            MySqlCommand cmd = new MySqlCommand()
            {
                CommandType = System.Data.CommandType.Text,
                CommandText = "UPDATE Jogosultsagok SET Szint = @Szint, Nev = @Nev, Leiras = @Leiras WHERE Id = @Id",
                Connection = BaseDatabaseManager.Connection
            };
            Jogosultsagok ujJogosultsag = record as Jogosultsagok;
            cmd.Parameters.Add(new MySqlParameter("@Id", ujJogosultsag.Id));
            cmd.Parameters.Add(new MySqlParameter("@Szint", ujJogosultsag.Szint));
            cmd.Parameters.Add(new MySqlParameter("@Nev", ujJogosultsag.Nev));
            cmd.Parameters.Add(new MySqlParameter("@Leiras", ujJogosultsag.Leiras));

            try
            {
                cmd.Connection.Open();
                int db = cmd.ExecuteNonQuery();
                if (db == 0)
                {
                    return $"Nem sikerült rögzítenem a felhasználót! {ujJogosultsag.Nev}";
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Hiba történt a rögzítés során\n{e.Message}");
            }
            finally
            {
                BaseDatabaseManager.Connection.Close();
            }
            return "Sikeres frissítés";
        }
    }
}