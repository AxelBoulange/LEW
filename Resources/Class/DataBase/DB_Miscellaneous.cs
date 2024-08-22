using MySqlConnector;

namespace LEW.Resources.Class.DataBase
{
    /// <summary>
    /// Useful DB Methods.
    /// </summary>
    public class DB_Miscellaneous
    {
        /// <summary>
        /// Check the connection between the current device and the DB server. 
        /// </summary>
        /// <param name="connection">The Connection you want to check.</param>
        /// <returns>TRUE if there is a link between the device and the DB server. Otherwise FALSE.</returns>
        public static bool Ping(MySqlConnection connection)
        {
            return connection.Ping();
        }
    }
}