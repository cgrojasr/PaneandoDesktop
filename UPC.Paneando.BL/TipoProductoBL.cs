using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPC.Paneando.DA;
using UPC.Paneando.DA.DataAccess;

namespace UPC.Paneando.BL
{
    public class TipoProductoBL
    {
        private readonly TipoProductoDA objTipoProductoDA;

        public TipoProductoBL()
        {
            objTipoProductoDA = new TipoProductoDA();
        }

        public List<tipo_producto> ListarTodo() {
            return objTipoProductoDA.ListarTodo();
        }
    }
}
