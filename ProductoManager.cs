using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Globalization;
using System.Data;

namespace Proyecto_Final_Coder2023
{
    internal static class ProductoManager
    {
        public static String cadenaConexion = "";
        public static List<Producto> obtenerProductos()
        {
            List<Producto> productos= new List<Producto>();
         
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
                        productoTemporal.Descripciones = reader.GetString(1);
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

        public static Producto obtenerProductos(string descripciones)
        {
            Producto producto = new Producto();

            using (SqlConnection conn = new SqlConnection())
            {
                SqlCommand comando2 = new SqlCommand($"SELECT * FROM Producto WHERE Descripciones = '{descripciones}'", conn);

                comando2.Parameters.AddWithValue("descripciones", descripciones);

                conn.Open();

                SqlDataReader reader = comando2.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read()

                    producto.Id = reader.GetInt64(0);
                    producto.Desccripciones = reader.GetString(1);
                    producto.Costo = reader.GetDecimal(2);
                    producto.PrecioVenta = reader.GetDecimal(3);
                    producto.Stock = reader.GetInt32(4);
                    producto.IdUsuario = reader.GetInt64(5);
                }

                return producto;
            }
        }
    }
}
