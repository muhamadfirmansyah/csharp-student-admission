using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace PPDB_Wikrama
{
    class connectionService
    {
        public static MySqlConnection getConnection()
        {
            MySqlConnection conn = null;
            try
            {
                string sConnString = "server=localhost;database=ppdb_wikrama;uid=root;password=;";
                conn = new MySqlConnection(sConnString);
            }
            catch (MySqlException sqlex)
            {
                throw new Exception(sqlex.Message.ToString());
            }
            return conn;
        }
    }
}
