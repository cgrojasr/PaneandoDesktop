using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UPC.Paneando.DA;

namespace UPC.Paneando.BL.UT
{
    [TestClass]
    public class ProductoUT
    {
        private readonly ProductoBL objProductoBL;

        public ProductoUT()
        {
            objProductoBL = new ProductoBL();
        }

        [TestMethod]
        public void Registro()
        {
            var objProducto = new producto
            {
                nombre = "demo 20230626",
                descripcion = "demo 20230626",
                id_tipo_producto = 1,
                image_url = "demo 20230626",
                activo = false
            };

            objProducto = objProductoBL.Registrar(objProducto);
            Assert.AreEqual(34, objProducto.id_producto);


        }
    }
}
