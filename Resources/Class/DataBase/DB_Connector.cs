using MySqlConnector;

namespace LEW.Resources.Class.DataBase
{
    /// <summary>
    /// Get and Close connection Methods.
    /// </summary>
    public class DB_Connector
    {
        /// <summary>
        /// Methods which create a connection and open it.
        /// </summary>
        /// <returns>The opened connection.</returns>
        public static MySqlConnection GetConnection()
        {
            MySqlConnection connection = new MySqlConnection("server=46.105.171.70;uid=portfoli_LEW;password=yLtJKUVBP6pANSD;database=portfoli_LEW");
            connection.Open();
            return connection;
        }
        
        /// <summary>
        /// Methods which close a connection.
        /// </summary>
        /// <param name="connection">The connection you want to close.</param>
        public static void CloseConnection(MySqlConnection connection)
        {
            connection.Close();
        }
    }
}