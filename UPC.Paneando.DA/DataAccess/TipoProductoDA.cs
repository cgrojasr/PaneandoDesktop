using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPC.Paneando.DA.DataAccess
{
    public class TipoProductoDA
    {
        private readonly dbPaneandoEntities dc;

        public TipoProductoDA()
        {
            dc = new dbPaneandoEntities();
        }

        public List<tipo_producto> ListarTodo()
        {
            return dc.tipo_producto.ToList();
        }
    }
}
