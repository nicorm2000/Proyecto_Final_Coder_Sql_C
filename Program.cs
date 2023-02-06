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
            List<Producto> productos = ProductoManager.obtenerProductos();

            Producto producto = ProductoManager.obtenerProductos(4);
        }
    }
}
