using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kladionica.data.dto;
using MySql.Data.MySqlClient;

namespace Kladionica.data.dao.mysql
{
    class MySqlParDAO : ParDAO
    {
        private static string insertQuerry = "INSERT INTO `Kladionica`.`Par` (`Naziv`, `SportID`) VALUES (?naziv, ?sportId);";

        public int insert(ParDTO par)
        {
            if (par == null)
                return 0;
            MySqlConnection connection = ConnectionPool.checkOutConnection();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = insertQuerry;
            command.Parameters.AddWithValue("naziv", par.Naziv);
            command.Parameters.AddWithValue("sportId", par.Sport.Id);
            command.ExecuteNonQuery();
            int id = (int)command.LastInsertedId;
            par.Id = id;
            ConnectionPool.checkInConnection(connection);
            return id;
        }

        public static ParDTO readerToParDTO(MySqlDataReader reader)
        {
            ParDTO par = new ParDTO();
            par.Id = reader.GetInt32("IdPar");
            par.Naziv = reader["Naziv"].ToString();
            par.Sport = MySqlSportDAO.readerToSportDTO(reader);

            return par;
        }
    }
}
