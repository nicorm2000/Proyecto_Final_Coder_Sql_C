using System.Data;
using System.Data.SqlClient;

namespace Proyecto_Final_Coder2023.Managers
{
    public class DBConnection
    {
        protected SqlConnection conn = new SqlConnection();
        protected SqlCommand command = new SqlCommand();
        protected string query;
        private protected string connectionstring = "Data Source=DESKTOP-PKSDVOQ;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public DBConnection()
        {
            conn.ConnectionString = connectionstring;
            command.Connection = conn;
            command.CommandType = CommandType.Text;
        }
    }
}
