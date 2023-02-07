using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Final_Coder2023.Managers
{
    public class SaleManager : DBConnection
    {
        public List<Venta> GetSalesById(int id)
        {
            List<Venta> venta = new List<Venta>();

            query = "SELECT * FROM Venta WHERE Venta.IdUsuario=@id";

            try
            {
                command.CommandText = query;
                command.Parameters.AddWithValue("@id", id);
                conn.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Venta VentaTemporal = new Venta();

                        VentaTemporal.Id = reader.GetInt64(0);
                        VentaTemporal.Comentario = reader.GetString(1);
                        VentaTemporal.IdUsuario = reader.GetInt64(2);

                        venta.Add(VentaTemporal);
                    }
                }
                return venta;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

    }
}
