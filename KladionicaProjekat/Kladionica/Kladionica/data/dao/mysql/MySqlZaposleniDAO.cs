using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kladionica.data.dto;
using MySql.Data.MySqlClient;

namespace Kladionica.data.dao.mysql
{
    class MySqlZaposleniDAO : ZaposleniDAO
    {
        private string insertQuerry = "INSERT INTO `kladionica`.`zaposleni` (`ID`, `Ime`, `Prezime`, `BrojTelefona`, `Adresa`, `Sifra`, `NivoPristupa`) VALUES (?id, ?ime, ?prezime, ?brojTelefona, ?adresa, ?sifra, ?nivoPristupa);";
        private string getByImeISifraQuery = "SELECT * from `kladionica`.`zaposleni` where ime=? and sifra=?;";


        public int insert(ZaposleniDTO zaposleni)
        {
            if (zaposleni == null)
                return 0;
            MySqlConnection connection = ConnectionPool.checkOutConnection();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = insertQuerry;
            command.Parameters.AddWithValue("id", zaposleni.Id);
            command.Parameters.AddWithValue("ime", zaposleni.Ime);
            command.Parameters.AddWithValue("prezime", zaposleni.Prezime);
            command.Parameters.AddWithValue("brojTelefona", zaposleni.BrojTelefona);
            command.Parameters.AddWithValue("adresa", zaposleni.Adresa);
            command.Parameters.AddWithValue("sifra", zaposleni.Sifra);
            command.Parameters.AddWithValue("nivoPristupa", zaposleni.NivoPristupa);
            command.ExecuteNonQuery();
            int id = (int)command.LastInsertedId;
            ConnectionPool.checkInConnection(connection);
            return id;
        }

        public ZaposleniDTO getByImeISifra(string ime, string sifra)
        {
            MySqlConnection connection = ConnectionPool.checkOutConnection();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = getByImeISifraQuery;
            command.Parameters.AddWithValue("ime", ime);
            command.Parameters.AddWithValue("sifra", sifra);
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                ZaposleniDTO zaposleni = readerToZaposleniDTO(reader);
                reader.Close();
                ConnectionPool.checkInConnection(connection);
                return zaposleni;
            }
            else
            {
                reader.Close();
                ConnectionPool.checkInConnection(connection);
                return null;
            }

        }

        public static ZaposleniDTO readerToZaposleniDTO(MySqlDataReader reader)
        {
            ZaposleniDTO zaposleni = new ZaposleniDTO();

            zaposleni.Id = reader["ID"].ToString();
            zaposleni.Ime = reader["Ime"].ToString();
            zaposleni.Prezime = reader["Prezime"].ToString();
            zaposleni.BrojTelefona = reader["BrojTelefona"].ToString();
            zaposleni.Adresa = reader["Adresa"].ToString();
            zaposleni.Sifra = reader["Sifra"].ToString();
            zaposleni.NivoPristupa = reader["NivoPristupa"].ToString();

            return zaposleni;
        }
    }
}