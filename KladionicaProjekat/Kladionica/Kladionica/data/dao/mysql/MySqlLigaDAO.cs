using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kladionica.data.dto;
using MySql.Data.MySqlClient;

namespace Kladionica.data.dao.mysql
{
    class MySqlLigaDAO : LigaDAO
    {
        private string insertQuerry = "INSERT INTO `Kladionica`.`Liga` (`VrstaLige`) VALUES (?vrstaLige);";

        public int insert(LigaDTO liga)
        {
            if (liga == null)
                return 0;
            MySqlConnection connection = ConnectionPool.checkOutConnection();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = insertQuerry;
            command.Parameters.AddWithValue("vrstaLige", liga.VrstaLige);
            command.ExecuteNonQuery();
            int id = (int)command.LastInsertedId;
            ConnectionPool.checkInConnection(connection);
            liga.Id = id;

            return id;
        }

        public static LigaDTO readerToLigaDTO(MySqlDataReader reader)
        {
            LigaDTO liga = new LigaDTO();
            liga.Id = reader.GetInt32("IdLiga");
            liga.VrstaLige = reader["vrstaLige"].ToString();

            return liga;
        }
    }
}
