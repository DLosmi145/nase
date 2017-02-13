using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kladionica.data.dto;
using MySql.Data.MySqlClient;

namespace Kladionica.data.dao.mysql
{
    class MySqlDogadjajTiketDAO : DogadjajTiketDAO
    {
        private static string insertQuerry = "INSERT INTO `Kladionica`.Dogadjaj_Tiket` (`DogadjajID`, `TiketID`, `TipIgreID`) VALUES (?idDogadjaj, ?idTiket, ?idTipIgre);";
        private static string getByTiketQuerry = "SELECT * FROM Dogadjaj_Tiket dt INNER JOIN Dogadjaj d ON d.idDogadjaj = dt.DogadjajID INNER JOIN TipIgre ti ON ti.idTipIgre = dt.TipIgreID WHERE dt.TiketID = ?tiketId;";
        private static string getByDogadjajQuerry = "SELECT * FROM Dogadjaj_Tiket dt INNER JOIN Tiket t ON t.idTiket = dt.TiketID INNER JOIN TipIgre ti ON ti.idTipIgre = dt.TipIgreID WHERE dt.DogadjajID = ?dogadjajId;";
        private static string getByTipIgreQuerry = "SELECT * FROM Dogadjaj_Tiket dt INNER JOIN Dogadjaj d ON d.idDogadjaj = dt.DogadjajID INNER JOIN Tiket t ON t.idTiket = dt.TiketID WHERE dt.TipIgreID = ?tipIgreId;";

        public int insert(DogadjajTiketDTO dogadjajTiket)
        {
            if (dogadjajTiket == null)
                return 0;
            MySqlConnection connection = ConnectionPool.checkOutConnection();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = insertQuerry;
            command.Parameters.AddWithValue("idDogadjaj", dogadjajTiket.Dogadjaj.Id);
            command.Parameters.AddWithValue("idTiket", dogadjajTiket.Tiket.Id);
            command.Parameters.AddWithValue("idTipIgre", dogadjajTiket.TipIgre.Id);
            command.ExecuteNonQuery();
            ConnectionPool.checkInConnection(connection);
            return 1;
        }

        public List<DogadjajTiketDTO> getByTiket(TiketDTO tiket)
        {
            MySqlConnection connection = ConnectionPool.checkOutConnection();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = getByTiketQuerry;
            command.Parameters.AddWithValue("tiketId", tiket.Id);
            MySqlDataReader reader = command.ExecuteReader();
            List<DogadjajTiketDTO> lista = new List<DogadjajTiketDTO>();
            while (reader.Read())
            {
                DogadjajTiketDTO dogadjajTiket = readerToDogadjajTiketDTO(reader, tiket);
                lista.Add(dogadjajTiket);
            }
            reader.Close();
            ConnectionPool.checkInConnection(connection);
            return lista;
        }

        public List<DogadjajTiketDTO> getByDogadjaj(DogadjajDTO dogadjaj)
        {
            MySqlConnection connection = ConnectionPool.checkOutConnection();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = getByDogadjajQuerry;
            command.Parameters.AddWithValue("dogadjajId", dogadjaj.Id);
            MySqlDataReader reader = command.ExecuteReader();
            List<DogadjajTiketDTO> lista = new List<DogadjajTiketDTO>();
            while (reader.Read())
            {
                DogadjajTiketDTO dogadjajTiket = readerToDogadjajTiketDTO(reader, dogadjaj);
                lista.Add(dogadjajTiket);
            }
            reader.Close();
            ConnectionPool.checkInConnection(connection);
            return lista;
        }

        public List<DogadjajTiketDTO> getByTipIgre(TipIgreDTO tipIgre)
        {
            MySqlConnection connection = ConnectionPool.checkOutConnection();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = getByTipIgreQuerry;
            command.Parameters.AddWithValue("tipIgreID", tipIgre.Id);
            MySqlDataReader reader = command.ExecuteReader();
            List<DogadjajTiketDTO> lista = new List<DogadjajTiketDTO>();
            while (reader.Read())
            {
                DogadjajTiketDTO dogadjajTiket = readerToDogadjajTiketDTO(reader, tipIgre);
                lista.Add(dogadjajTiket);
            }
            reader.Close();
            ConnectionPool.checkInConnection(connection);
            return lista;
        }

        public DogadjajTiketDTO readerToDogadjajTiketDTO(MySqlDataReader reader, TiketDTO tiket)
        {
            DogadjajTiketDTO dogadjajTiket = new DogadjajTiketDTO();
            dogadjajTiket.Tiket = tiket;
            dogadjajTiket.Dogadjaj = MySqlDogadjajDAO.readerToDogadjajDTO(reader);
            dogadjajTiket.TipIgre = MySqlTipIgreDAO.readerToTipIgreDTO(reader);
            return dogadjajTiket;
        }

        public DogadjajTiketDTO readerToDogadjajTiketDTO(MySqlDataReader reader, DogadjajDTO dogadjaj)
        {
            DogadjajTiketDTO dogadjajTiket = new DogadjajTiketDTO();
            dogadjajTiket.Tiket = MySqlTiketDAO.readerToTiketDTO(reader);
            dogadjajTiket.Dogadjaj = dogadjaj;
            dogadjajTiket.TipIgre = MySqlTipIgreDAO.readerToTipIgreDTO(reader);
            return dogadjajTiket;
        }

        public DogadjajTiketDTO readerToDogadjajTiketDTO(MySqlDataReader reader, TipIgreDTO tipIgre)
        {
            DogadjajTiketDTO dogadjajTiket = new DogadjajTiketDTO();
            dogadjajTiket.Tiket = MySqlTiketDAO.readerToTiketDTO(reader);
            dogadjajTiket.Dogadjaj = MySqlDogadjajDAO.readerToDogadjajDTO(reader);
            dogadjajTiket.TipIgre = tipIgre;
            return dogadjajTiket;
        }
    }
}