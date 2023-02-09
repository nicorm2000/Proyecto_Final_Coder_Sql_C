using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using Proyecto_Final_Coder2023.Data;
using Proyecto_Final_Coder2023.Models;

namespace Proyecto_Final_Coder2023.Managers
{
    public class ProductSaleManager : DBConnection
    {
        public List<Producto> GetProductSales(long idUsuario)
        {
            List<Producto> producto = new List<Producto>();

            query = $"SELECT IdProducto FROM Venta INNER JOIN ProductoVendido ON Venta.Id = ProductoVendido.IdVenta WHERE IdUsuario = {idUsuario}";

            try
            {
                command.CommandText = query;
                command.Parameters.AddWithValue("@idUsuario", idUsuario);
                conn.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Producto ProductoTemporal = new Producto();

                        ProductoTemporal.Id = reader.GetInt64(0);
                        ProductoTemporal.Descripciones = reader.GetString(1);
                        ProductoTemporal.Costo = reader.GetDecimal(2);
                        ProductoTemporal.PrecioVenta = reader.GetDecimal(3);
                        ProductoTemporal.Stock = reader.GetInt32(4);
                        ProductoTemporal.IdUsuario = reader.GetInt64(5);

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
