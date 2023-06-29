using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPC.Paneando.BE;
using UPC.Paneando.DA;
using UPC.Paneando.DA.DataAccess;

namespace UPC.Paneando.BL
{
    public class ProductoBL
    {
        private readonly ProductoDA objProductoDA;

        public ProductoBL()
        {
            objProductoDA = new ProductoDA();
        }

        public List<producto> ListarTodo()
        {
            return objProductoDA.ListarTodo();
        }

        public producto Registrar(producto objProducto) {
            try
            {
                objProducto = objProductoDA.Registrar(objProducto);
            }
            catch (Exception ex)
            {
                //Desarrollar un log que almacene las excepciones 
                objProducto.id_producto = 0;
                //return objProducto;
                //Utilizar throw solo si vamos a tratar la excepcion en otra capa
                //throw ex;
            }
            return objProducto;
        }

        public producto Modificar(producto objProducto) {
            return objProductoDA.Modificar(objProducto);
        }

        public producto Eliminar(int id_producto) {
            return objProductoDA.Eliminar(id_producto);
        }

        public producto BuscarPorId(int id_producto) { 
            return objProductoDA.BuscarPorId(id_producto);
        }

        public List<ProductoGestor> Listar_ProductoGestor() {
            return objProductoDA.Listar_ProductoGestor();
        }
    }
}
