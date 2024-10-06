using MySql.Data.MySqlClient;
using Org.BouncyCastle.Crypto.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WCF_0923_server.DatabaseManager;
using WCF_0923_server.Models;

namespace WCF_0923_server.Controllers
{
    public class FelhasznalokController : BaseDatabaseManager, ISQL
    {
        public string Delete(int id)
        {
            MySqlCommand cmd = new MySqlCommand()
            {
                CommandType = System.Data.CommandType.Text,
                CommandText = "DELETE FROM Felhasznalok WHERE Id = @Id;",
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
                CommandText = "INSERT INTO felhasznalok (LoginNev, Hash, Salt, Nev, Jog, Aktiv, Email, Profilkep) VALUES (@LoginNev, @Hash, @Salt, @Nev, @Jog, @Aktiv, @Email, @Profilkep)",
                Connection = BaseDatabaseManager.Connection
            };
            Felhasznalok ujFelhasznalo = record as Felhasznalok;
            cmd.Parameters.Add(new MySqlParameter("@LoginNev", ujFelhasznalo.LoginNev));
            cmd.Parameters.Add(new MySqlParameter("@Hash", ujFelhasznalo.Hash));
            cmd.Parameters.Add(new MySqlParameter("@Salt", ujFelhasznalo.Salt));
            cmd.Parameters.Add(new MySqlParameter("@Nev", ujFelhasznalo.Nev));
            cmd.Parameters.Add(new MySqlParameter("@Jog", ujFelhasznalo.Jog));
            cmd.Parameters.Add(new MySqlParameter("@Aktiv", ujFelhasznalo.Aktiv));
            cmd.Parameters.Add(new MySqlParameter("@Email", ujFelhasznalo.Email));
            cmd.Parameters.Add(new MySqlParameter("@Profilkep", ujFelhasznalo.Profilkep));

            try
            {
                cmd.Connection.Open();
                int db = cmd.ExecuteNonQuery();
                if (db == 0)
                {
                    return $"Nem sikerült rögzítenem a felhasználót! {ujFelhasznalo.Nev}";
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
            MySqlCommand cmd = new MySqlCommand() {
                CommandType = System.Data.CommandType.Text,
                CommandText = "SELECT * FROM Felhasznalok;"
            };
            try
            {
                MySqlConnection conn = BaseDatabaseManager.Connection;
                conn.Open();
                cmd.Connection = conn;
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Felhasznalok ujFelh = new Felhasznalok() {
                        Id = reader.GetInt32("Id"),
                        LoginNev = reader.GetString("LoginNev"),
                        Hash = reader.GetString("Hash"),
                        Salt = reader.GetString("Salt"),
                        Nev = reader.GetString("Nev"),
                        Jog = reader.GetInt32("Jog"),
                        Aktiv = reader.GetBoolean("Aktiv"),
                        Email = reader.GetString("Email"),
                        Profilkep = reader.GetString("ProfilKep")
                    };
                    list.Add(ujFelh);
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
                CommandText = "UPDATE felhasznalok (LoginNev, Hash, Salt, Nev, Jog, Aktiv, Email, Profilkep) VALUES (@LoginNev, @Hash, @Salt, @Nev, @Jog, @Aktiv, @Email, @Profilkep)",
                Connection = BaseDatabaseManager.Connection
            };
            Felhasznalok ujFelhasznalo = record as Felhasznalok;
            cmd.Parameters.Add(new MySqlParameter("@LoginNev", ujFelhasznalo.LoginNev));
            cmd.Parameters.Add(new MySqlParameter("@Hash", ujFelhasznalo.Hash));
            cmd.Parameters.Add(new MySqlParameter("@Salt", ujFelhasznalo.Salt));
            cmd.Parameters.Add(new MySqlParameter("@Nev", ujFelhasznalo.Nev));
            cmd.Parameters.Add(new MySqlParameter("@Jog", ujFelhasznalo.Jog));
            cmd.Parameters.Add(new MySqlParameter("@Aktiv", ujFelhasznalo.Aktiv));
            cmd.Parameters.Add(new MySqlParameter("@Email", ujFelhasznalo.Email));
            cmd.Parameters.Add(new MySqlParameter("@Profilkep", ujFelhasznalo.Profilkep));

            try
            {
                cmd.Connection.Open();
                int db = cmd.ExecuteNonQuery();
                if (db == 0)
                {
                    return $"Nem sikerült rögzítenem a felhasználót! {ujFelhasznalo.Nev}";
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