using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Globalization;

namespace Proyecto_Final_Coder2023
{
    internal class ProductoManager
    {
        public List<Producto> obtenerProductos()
        {
            List<Producto> productos= new List<Producto>();
            String cadenaConexion = "";

            using (SqlConnection conn = new SqlConnection())
            {
                SqlCommand comando = new SqlCommand("SELECT * FROM Producto", conn);
                conn.Open();

                SqlDataReader reader = comando.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Producto productoTemporal = new Producto();
                        productoTemporal.Id = reader.GetInt64(0);
                        productoTemporal.Desccripciones = reader.GetString(1);
                        productoTemporal.Costo = reader.GetDecimal(2);
                        productoTemporal.PrecioVenta = reader.GetDecimal(3);
                        productoTemporal.Stock = reader.GetInt32(4);
                        productoTemporal.IdUsuario = reader.GetInt64(5);

                        productos.Add(productoTemporal);
                    }
                }

                return productos;
            }
        }
    }
}
