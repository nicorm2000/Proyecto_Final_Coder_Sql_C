using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Proyecto_Final_Coder2023
{
    internal class Producto
    {
        private long Id { get; set;  }
        private string Descripciones { get; set; }
        private decimal Costo { get; set; }
        private decimal PrecioVenta { get; set; }
        private int Stock { get; set; }
        private decimal IdUsuario { get; set; }
    }
}
