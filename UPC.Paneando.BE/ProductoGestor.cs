using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPC.Paneando.BE
{
    public class ProductoGestor
    {
        public int id_producto { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string tipo_producto { get; set; }
        public bool activo { get; set; }
    }
}
