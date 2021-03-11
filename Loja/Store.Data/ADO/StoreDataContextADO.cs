using System;
using System.Configuration;
using System.Data.SqlClient;

namespace Store.Data.ADO
{
    public class StoreDataContextADO : IDisposable
    {
        private readonly SqlConnection _conn;

        public StoreDataContextADO()
        {
            var connString = ConfigurationManager.ConnectionStrings["StoreCon"].ConnectionString;
            _conn = new SqlConnection(connString);
            _conn.Open();
        }


        public void ExecuteCommand(string sql)
        {
            var command = new SqlCommand(){
                CommandText = sql,
                CommandType = System.Data.CommandType.Text,
                Connection = _conn
            };

            command.ExecuteNonQuery();
        }

        public SqlDataReader ExecuteCommandData(string query)
        {
            var command = new SqlCommand(query, _conn);
            return command.ExecuteReader();

        } 

        public void Dispose()
        {
            if (_conn.State == System.Data.ConnectionState.Open)
                _conn.Close();
        }
    }
}
