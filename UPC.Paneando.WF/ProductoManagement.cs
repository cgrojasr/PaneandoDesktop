using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UPC.Paneando.BL;

namespace UPC.Paneando.WF
{
    public partial class ProductoManagement : Form
    {
        public ProductoManagement()
        {
            InitializeComponent();
            CargarProductos();
        }

        public void CargarProductos() { 
            ProductoBL objProductoBL = new ProductoBL();
            dgProductos.DataSource = objProductoBL.Listar_ProductoGestor();
            dgProductos.Columns[0].HeaderText = "Código";
            dgProductos.Columns[3].HeaderText = "Tipo Producto";
            //dgProductos.Columns[6].Visible = false;
            //dgProductos.Columns[7].Visible = false;
            //dgProductos.Columns[8].Visible = false;

        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            ProductoRegistrar form = new ProductoRegistrar(this, 0);
            form.Show();
        }

        private void dgProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var rows = dgProductos.RowCount;
            int id_producto = (int)dgProductos.Rows[e.RowIndex].Cells[0].Value;
            ProductoRegistrar form = new ProductoRegistrar(this, id_producto);
            form.Show();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            var id_producto = (int)dgProductos.SelectedRows[0].Cells[0].Value;
            var objProductoBL = new ProductoBL();
            var objProducto = objProductoBL.Eliminar(id_producto);
            MessageBox.Show("Se elimino el producto " + objProducto.nombre);
            CargarProductos();
        }
    }
}
