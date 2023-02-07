using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Final_Coder2023
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Producto> productos = ProductoManager.ObtenerProductos();

            Producto producto = ProductoManager.ObtenerProductos("Pantalon Negro");
            
            Producto producto1 = new Producto();
            producto1.Descripciones = "Pantalon Jean Negro";
            producto1.Costo = 9000;
            producto1.PrecioVenta = 12000;
            producto1.Stock = 99;
            producto1.IdUsuario = 2;

            if (ProductoManager.InsertarProducto(producto1) >= 1)
            {
                Console.WriteLine("Producto Insertado");
            }
            else
            {
                Console.WriteLine("Producto No Insertado");
            }

            Producto producto2 = ProductoManager.ObtenerProductos(1);
            Console.WriteLine(producto1.Descripciones);

        }
    }
}
