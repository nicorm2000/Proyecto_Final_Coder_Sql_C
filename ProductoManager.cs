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
        public static String cadenaConexion = "Data Source=DESKTOP-PKSDVOQ;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public static List<Producto> ObtenerProductos()
        {
            List<Producto> productos= new List<Producto>();
         
            using (SqlConnection conn = new SqlConnection(cadenaConexion))
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

        public static Producto ObtenerProductos(string descripciones)
        {
            Producto producto = new Producto();

            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {
                SqlCommand comando2 = new SqlCommand($"SELECT * FROM Producto WHERE Descripciones = '{descripciones}'", conn);

                comando2.Parameters.AddWithValue("descripciones", descripciones);

                conn.Open();

                SqlDataReader reader = comando2.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();

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

        public static int InsertarProducto(Producto producto)
        {
            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {
                SqlCommand comando = new SqlCommand("INSERT INTO Producto(Descripciones, Costo, PrecioVenta, Stock, IdUsuario)" + "VALUES(@descripciones, @costo, @precioVenta, @stock, @isUsuario)", conn);
                comando.Parameters.AddWithValue("@descripciones", producto.Descripciones);
                comando.Parameters.AddWithValue("@costo", producto.Costo);
                comando.Parameters.AddWithValue("@precioVenta", producto.PrecioVenta);
                comando.Parameters.AddWithValue("@stock", producto.Stock);
                comando.Parameters.AddWithValue("@isUsuario", producto.IdUsuario);

                conn.Open();

                return comando.ExecuteNonQuery();
            }
        }

        public static List<Producto> ObtenerProductosvendidos(long idUsuario)
        {
            List<long> idProductos = new List<long>();

            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {
                SqlCommand comando2 = new SqlCommand("SELECT IdProducto FROM Venta " + "INNER JOIN ProductoVendido " + "ON Venta.Id = ProductoVendido.IdVenta" + " WHERE IdUsuario = @idUsuario", conn);

                comando2.Parameters.AddWithValue("idUsuario", idUsuario);

                conn.Open();

                SqlDataReader reader = comando2.ExecuteReader();

                if (reader.HasRows)
                {
                    while(reader.Read())
                    {
                        idProductos.Add(reader.GetInt64(0));
                    }
                }

                List <Producto> productos = new List<Producto>();

                foreach (var id in idProductos)
                {
                    Producto prodTemp = ObtenerProductos(id);
                    productos.Add (prodTemp);
                }

                return productos;
            }
        }

        public static Producto ObtenerProductos(long id)
        {
            Producto producto = new Producto();

            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {
                SqlCommand comando2 = new SqlCommand($"SELECT * FROM Producto WHERE Id = @id", conn);

                comando2.Parameters.AddWithValue("@id", id);

                conn.Open();

                SqlDataReader reader = comando2.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();

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
}
