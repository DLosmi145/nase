using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kladionica.data.dto;
using MySql.Data.MySqlClient;

namespace Kladionica.data.dao.mysql
{
    class MySqlTipIgreDAO : TipIgreDAO
    {
        private static string insertQuerry = "INSERT INTO `Kladionica`.`TipIgre`(`VrstaIgre`) VALUES (?vrsta);";
        private static string getByVrstaIgreQuerry = "SELECT * FROM TipIgre WHERE VrstaIgre=?vrsta;";

        public int insert(TipIgreDTO tipIgre)
        {
            if (tipIgre == null)
                return 0;
            MySqlConnection connection = ConnectionPool.checkOutConnection();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = insertQuerry;
            command.Parameters.AddWithValue("vrsta", tipIgre.VrstaIgre);
            command.ExecuteNonQuery();
            int id = (int)command.LastInsertedId;
            tipIgre.Id = id;
            ConnectionPool.checkInConnection(connection);
            return id;
        }

        public TipIgreDTO getByVrstaIgre(string vrsta)
        {
            MySqlConnection connection = ConnectionPool.checkOutConnection();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = getByVrstaIgreQuerry;
            command.Parameters.AddWithValue("vrsta", vrsta);
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                TipIgreDTO tipIgre = readerToTipIgreDTO(reader);
                reader.Close();
                ConnectionPool.checkInConnection(connection);
                return tipIgre;
            }
            reader.Close();
            ConnectionPool.checkInConnection(connection);
            return null;
        }

        public static TipIgreDTO readerToTipIgreDTO(MySqlDataReader reader)
        {
            TipIgreDTO tipIgre = new TipIgreDTO();
            tipIgre.Id = reader.GetInt32("IdTipIgre");
            tipIgre.VrstaIgre = reader["VrstaIgre"].ToString();
            return tipIgre;
        }
    }
}
