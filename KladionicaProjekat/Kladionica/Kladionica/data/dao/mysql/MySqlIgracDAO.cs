using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kladionica.data.dto;
using MySql.Data.MySqlClient;

namespace Kladionica.data.dao.mysql
{
    class MySqlIgracDAO : IgracDAO
    {
        private string insertQuerry = "INSERT INTO `kladionica`.`igrac`(`Ime`, `Prezime`, `Sifra`) VALUES (?ime, ?prezime, ?sifra);";
        private string getByImeISifraQuerry = "SELECT * FROM `kladionica`.`igrac` WHERE ime=? and sifra=?;";

        public int insert(IgracDTO igrac)
        {
            if (igrac == null)
                return 0;
            MySqlConnection connection = ConnectionPool.checkOutConnection();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = insertQuerry;
            command.Parameters.AddWithValue("ime", igrac.Ime);
            command.Parameters.AddWithValue("prezime", igrac.Prezime);
            command.Parameters.AddWithValue("sifra", igrac.Sifra);
            command.ExecuteNonQuery();
            int id = (int)command.LastInsertedId;
            igrac.Id = id;
            ConnectionPool.checkInConnection(connection);
            return id;
        }

        public IgracDTO getByImeISifra(string ime, string sifra)
        {
            MySqlConnection connection = ConnectionPool.checkOutConnection();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = getByImeISifraQuerry;
            command.Parameters.AddWithValue("ime", ime);
            command.Parameters.AddWithValue("sifra", sifra);
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                IgracDTO igrac = readerToIgracDTO(reader);
                ConnectionPool.checkInConnection(connection);
                return igrac;
            }
            else
            {
                reader.Close();
                ConnectionPool.checkInConnection(connection);
                return null;
            }
        }

        public static IgracDTO readerToIgracDTO(MySqlDataReader reader)
        {
            IgracDTO igrac = new IgracDTO();
            igrac.Id = reader.GetInt32("Id");
            igrac.Ime = reader["Ime"].ToString();
            igrac.Prezime = reader["Prezime"].ToString();
            igrac.Sifra = reader["Sifra"].ToString();

            return igrac;
        }
    }
}
