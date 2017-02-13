using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kladionica.data.dto;
using MySql.Data.MySqlClient;

namespace Kladionica.data.dao.mysql
{
    class MySqlTiketDAO : TiketDAO
    {
        private static string insertQuerry = "INSERT INTO `Kladionica`.`Tiket`(`VrijemeUplate`, `KontrolniBrojTiketa`, `IznosUplate`, `Sistem`, `SifraUplatnogMjesta_Sifra`, `ZaposleniID`, `IgracID`) VALUES (?vrijeme, ?brojTiketa, ?iznos, ?sistem, ?sifraMjesta, ?idZaposleni, ?idIgrac);";
        private static string getByIdQuerry = "SELECT * FROM Tiket t INNER JOIN SifraUplatnogMjesta s ON t.SifraUplatnogMjesta_Sifra = s.Sifra INNER JOIN Zaposleni z ON t.ZaposleniID = z.IdZaposleni INNER JOIN Igrac i ON t.IgracID = i.IdIgrac WHERE t.IdTiket = ?idTiket;";

        public int insert(TiketDTO tiket)
        {
            if (tiket == null)
                return 0;
            MySqlConnection connection = ConnectionPool.checkOutConnection();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = insertQuerry;
            command.Parameters.AddWithValue("vrijeme", tiket.VrijemeUplate);
            command.Parameters.AddWithValue("brojTiketa", tiket.KontrolniBrojTiketa);
            command.Parameters.AddWithValue("iznos", tiket.IznosUplate);
            command.Parameters.AddWithValue("sistem", tiket.Sistem);
            command.Parameters.AddWithValue("sifraMjesta", tiket.SifraUplatnogMjesta.Sifra);
            command.Parameters.AddWithValue("idZaposleni", tiket.Zaposleni.Id);
            command.Parameters.AddWithValue("idIgrac", tiket.Igrac.Id);
            command.ExecuteNonQuery();
            int id = (int)command.LastInsertedId;
            ConnectionPool.checkInConnection(connection);
            tiket.Id = id;
            return id;
        }

        public TiketDTO getById(int id)
        {
            MySqlConnection connection = ConnectionPool.checkOutConnection();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = getByIdQuerry;
            command.Parameters.AddWithValue("idTiket", id);
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                TiketDTO tiket = readerToTiketDTO(reader);
                tiket.Zaposleni = MySqlZaposleniDAO.readerToZaposleniDTO(reader);
                tiket.Igrac = MySqlIgracDAO.readerToIgracDTO(reader);

                reader.Close();
                ConnectionPool.checkInConnection(connection);
                return tiket;
            }

            reader.Close();
            ConnectionPool.checkInConnection(connection);
            return null;
        }

        public static TiketDTO readerToTiketDTO(MySqlDataReader reader)
        {
            TiketDTO tiket = new TiketDTO();
            tiket.Id = reader.GetInt32("IdTiket");
            tiket.KontrolniBrojTiketa = reader["KontrolniBrojTiketa"].ToString();
            tiket.IznosUplate = reader.GetFloat("IznosUplate");
            tiket.Sistem = reader.GetInt32("Sistem");

            return tiket;
        }
    }
}
