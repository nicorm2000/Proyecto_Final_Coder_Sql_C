using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Proyecto_Final_Coder2023.Models
{
    public class Venta
    {
        public long Id { get; set; }
        public string Comentario { get; set; }
        public long IdUsuario { get; set; }
    }
}
