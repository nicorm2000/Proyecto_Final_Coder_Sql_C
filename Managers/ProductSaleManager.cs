using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace Proyecto_Final_Coder2023.Managers
{
    public class ProductSaleManager : DBConnection
    {
        public List<Producto> GetProductSales(int id)
        {
            List<Producto> producto = new List<Producto>();

            query = "SELECT * FROM ProductoVendido PV INNER JOIN Producto P ON PV.IdProducto = P.Id WHERE P.Id = @id";

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
                        Producto ProductoTemporal = new Producto();

                        ProductoTemporal.Id = reader.GetInt64(4);
                        ProductoTemporal.Descripciones = reader.GetString(5);
                        ProductoTemporal.Costo = reader.GetDecimal(6);
                        ProductoTemporal.PrecioVenta = reader.GetDecimal(7);
                        ProductoTemporal.Stock = reader.GetInt32(8);
                        ProductoTemporal.IdUsuario = reader.GetInt64(9);

                        producto.Add(ProductoTemporal);
                    }
                }
                return producto;
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
