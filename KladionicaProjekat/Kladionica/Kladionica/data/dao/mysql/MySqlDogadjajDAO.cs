using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kladionica.data.dto;
using MySql.Data.MySqlClient;

namespace Kladionica.data.dao.mysql
{
    class MySqlDogadjajDAO : DogadjajDAO
    {
        private static string insertQuerry = "INSERT INTO `Kladionica`.`Dogadjaj`(`VrijemeOdrzavanja`, `Par_ID`) VALUES (?vrijeme, ?parId);";
        private static string getAllQuerry = "SELECT *, p.IdPar, p.Naziv, s.IdSport, s.OpisSporta, l.IdLiga, l.VrstaLige FROM Dogadjaj d INNER JOIN Par p on d.Par_ID = p.IdPar INNER JOIN Sport s on s.IdSport = p.SportID INNER JOIN Liga l on l.IdLiga = s.Liga;";
        private static string getAllValidEventsQuerry = "SELECT *, p.IdPar, p.Naziv, s.IdSport, s.OpisSporta, l.IdLiga, l.VrstaLige FROM Dogadjaj d INNER JOIN Par p on d.Par_ID = p.IdPar INNER JOIN Sport s on s.IdSport = p.SportID INNER JOIN Liga l on l.IdLiga = s.Liga where d.VrijemeOdrzavanja > now();";

        public int insert(DogadjajDTO dogadjaj)
        {
            if (dogadjaj == null)
                return 0;
            MySqlConnection connection = ConnectionPool.checkOutConnection();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = insertQuerry;
            command.Parameters.AddWithValue("vrijeme", dogadjaj.VrijemeOdrzavanja);
            command.Parameters.AddWithValue("parId", dogadjaj.Par.Id);
            command.ExecuteNonQuery();
            int id = (int)command.LastInsertedId;
            dogadjaj.Id = id;
            ConnectionPool.checkInConnection(connection);
            return id;
        }

        public List<DogadjajDTO> getAll()
        {
            MySqlConnection connection = ConnectionPool.checkOutConnection();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = getAllQuerry;
            MySqlDataReader reader = command.ExecuteReader();
            List<DogadjajDTO> dogadjaji = new List<DogadjajDTO>();

            while (reader.Read())
            {
                DogadjajDTO dogadjaj = new DogadjajDTO();
                dogadjaj = readerToDogadjajDTO(reader);
                dogadjaj.Par = MySqlParDAO.readerToParDTO(reader);
                dogadjaj.Par.Sport = MySqlSportDAO.readerToSportDTO(reader);
                dogadjaj.Par.Sport.Liga = MySqlLigaDAO.readerToLigaDTO(reader);
                dogadjaji.Add(dogadjaj);
            }
            reader.Close();
            ConnectionPool.checkInConnection(connection);
            return dogadjaji;
        }

        public List<DogadjajDTO> getAllValidEvents()
        {
            MySqlConnection connection = ConnectionPool.checkOutConnection();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = getAllValidEventsQuerry;
            MySqlDataReader reader = command.ExecuteReader();
            List<DogadjajDTO> dogadjaji = new List<DogadjajDTO>();

            while (reader.Read())
            {
                DogadjajDTO dogadjaj = new DogadjajDTO();
                dogadjaj = readerToDogadjajDTO(reader);
                dogadjaj.Par = MySqlParDAO.readerToParDTO(reader);
                dogadjaj.Par.Sport = MySqlSportDAO.readerToSportDTO(reader);
                dogadjaj.Par.Sport.Liga = MySqlLigaDAO.readerToLigaDTO(reader);
                dogadjaji.Add(dogadjaj);
            }
            reader.Close();
            ConnectionPool.checkInConnection(connection);
            return dogadjaji;
        }

        public static DogadjajDTO readerToDogadjajDTO(MySqlDataReader reader)
        {
            DogadjajDTO dogadjaj = new DogadjajDTO();
            dogadjaj.Id = reader.GetInt32("IdDogadjaj");
            dogadjaj.VrijemeOdrzavanja = reader.GetDateTime("vrijemeOdrzavanja");
            return dogadjaj;
        }
    }
}
