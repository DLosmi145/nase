using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kladionica.data.dto;
using MySql.Data.MySqlClient;

namespace Kladionica.data.dao.mysql
{
    class MySqlSportDAO : SportDAO
    {
        private string insertQuerry = "INSERT INTO `Kladionica`.`Sport` (`OpisSporta`, `Liga') VALUES (?opisSporta, ?ligaId);";

        public int insert(SportDTO sport)
        {
            if (sport == null)
                return 0;
            MySqlConnection connection = ConnectionPool.checkOutConnection();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = insertQuerry;
            command.Parameters.AddWithValue("opisSporta", sport.OpisSporta);
            command.Parameters.AddWithValue("ligaId", sport.Liga.Id);
            command.ExecuteNonQuery();
            int id = (int)command.LastInsertedId;
            sport.Id = id;
            ConnectionPool.checkInConnection(connection);
            return id;
        }

        public static SportDTO readerToSportDTO(MySqlDataReader reader)
        {
            SportDTO sport = new SportDTO();
            sport.Id = reader.GetInt32("IdSport");
            sport.OpisSporta = reader["OpisSporta"].ToString();
            sport.Liga = MySqlLigaDAO.readerToLigaDTO(reader);

            return sport;
        }
    }
}
