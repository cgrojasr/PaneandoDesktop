using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UPC.Paneando.DA;
using UPC.Paneando.DA.DataAccess;

namespace UPC.Paneando.UT
{
    [TestClass]
    public class ProductoUT
    {
        private readonly ProductoDA objProductoDA;

        public ProductoUT()
        {
            objProductoDA = new ProductoDA();
        }

        [TestMethod]
        public void ListarTodo()
        {
            var productos = objProductoDA.ListarTodo();
            Assert.AreEqual(33, productos.Count);
        }

        [TestMethod]
        public void Registrar()
        {
            var objProducto = new producto
            {
                nombre = "test",
                descripcion = "test",
                image_url = "test",
                id_tipo_producto = 1,
                activo = false
            };
            var producto_registrado = objProductoDA.Registrar(objProducto);
            Assert.AreEqual(35, producto_registrado.id_producto);
        }

        [TestMethod]
        public void Modificar()
        {
            var objProducto = new producto
            {
                id_producto = 35,
                nombre = "test modificado",
                descripcion = "test",
                image_url = "test",
                id_tipo_producto = 1,
                activo = false
            };
            var producto_registrado = objProductoDA.Modificar(objProducto);
            Assert.AreEqual(35, producto_registrado.id_producto);
        }

        [TestMethod]
        public void Eliminar()
        {
            var objProducto = objProductoDA.Eliminar(34);
            Assert.AreEqual(34, objProducto.id_producto);
        }

        [TestMethod]
        public void ListarCatalogo()
        {
            var objProductos = objProductoDA.ListarCatalogo(1);
            Assert.AreEqual(7, objProductos.Count);
        }
    }
}
