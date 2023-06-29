using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPC.Paneando.BE;

namespace UPC.Paneando.DA.DataAccess
{
    public class ProductoDA
    {
        private readonly dbPaneandoEntities dc;
        public ProductoDA()
        {
            dc = new dbPaneandoEntities();
        }

        public producto Eliminar(int id_producto) {
            var objProducto = dc.productoes.Find(id_producto);
            dc.productoes.Remove(objProducto);
            dc.SaveChanges();

            return objProducto;
        }

        public producto Registrar(producto objProducto) { 
            dc.productoes.Add(objProducto);
            dc.SaveChanges();

            return objProducto;
        }

        public producto Modificar(producto objProducto)
        {
            var objProducto_modificar = dc.productoes.Find(objProducto.id_producto);
            objProducto_modificar.nombre = objProducto.nombre;
            objProducto_modificar.descripcion = objProducto.descripcion;
            objProducto_modificar.image_url = objProducto.image_url;
            objProducto_modificar.activo = objProducto.activo;
            objProducto_modificar.id_tipo_producto = objProducto.id_tipo_producto;
            dc.SaveChanges();

            return objProducto_modificar;
        }

        public List<producto> ListarTodo() {
            var query = dc.productoes.ToList<producto>();

            return query;
        }

        public producto BuscarPorId(int id_producto) {
            var objProducto = dc.productoes.Find(id_producto);
            return objProducto;
        }

        public List<CatalogoProducto> ListarCatalogo(int id_tipo_producto) { 
            var query = from pro in dc.productoes
                        join tip in dc.tipo_producto on pro.id_tipo_producto equals tip.id_tipo_producto
                        join pre in dc.producto_precio.Where(x=>x.activo) on pro.id_producto equals pre.id_producto
                        where pro.id_tipo_producto == id_tipo_producto
                        select new CatalogoProducto { 
                            id_producto = pro.id_producto,
                            nombre = pro.nombre,
                            descripcion = pro.nombre,
                            tipo_producto = tip.nombre,
                            precio = pre.valor_venta
                        };

            return query.ToList();
        }

        public List<ProductoGestor> Listar_ProductoGestor()
        {
            var query = from pro in dc.productoes
                        join tip in dc.tipo_producto on pro.id_tipo_producto equals tip.id_tipo_producto
                        select new ProductoGestor
                        {
                            id_producto = pro.id_producto,
                            nombre = pro.nombre,
                            descripcion = pro.descripcion,
                            tipo_producto = tip.nombre,
                            activo = pro.activo
                        };

            return query.ToList();
        }
    }
}
