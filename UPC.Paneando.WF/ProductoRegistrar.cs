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
using UPC.Paneando.DA;
using UPC.Paneando.DA.DataAccess;

namespace UPC.Paneando.WF
{
    public partial class ProductoRegistrar : Form
    {
        private readonly TipoProductoDA objTipoProductoDA;
        private readonly ProductoManagement frm;
        private readonly bool modificar = false;
        public ProductoRegistrar(ProductoManagement frm, int id_producto)
        {
            InitializeComponent();
            objTipoProductoDA = new TipoProductoDA();
            Cargar_TipoProducto();
            this.frm = frm;
            if(id_producto != 0 )
            {
                modificar = true;
                lblCodigo.Visible = true;
                lblCodigoText.Visible = true;
                Cargar_Producto(id_producto);
            }
        }

        private void Cargar_Producto(int id_producto) { 
            var objProductoBL = new ProductoBL();
            var objProducto = objProductoBL.BuscarPorId(id_producto);
            lblCodigo.Text = objProducto.id_producto.ToString();
            txtNombre.Text = objProducto.nombre;
            txtDescripcion.Text = objProducto.descripcion;
            txtImageURL.Text = objProducto.image_url;
            cbTipoProducto.SelectedValue = objProducto.id_tipo_producto;
            ckActivo.Checked = objProducto.activo;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombre.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            txtImageURL.Text = string.Empty;
            cbTipoProducto.SelectedIndex = 0;
            ckActivo.Checked = false;
        }

        private void Cargar_TipoProducto() { 
            var lstTipoProducto =  objTipoProductoDA.ListarTodo();
            cbTipoProducto.DataSource = lstTipoProducto;
            cbTipoProducto.DisplayMember = "nombre";
            cbTipoProducto.ValueMember = "id_tipo_producto";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var objProducto = new producto
            {
                nombre = txtNombre.Text,
                descripcion = txtDescripcion.Text,
                image_url = txtImageURL.Text,
                id_tipo_producto = (int)cbTipoProducto.SelectedValue,
                activo = ckActivo.Checked
            };

            var objProductoBL = new ProductoBL();
            if (modificar)
            {
                objProducto.id_producto = int.Parse(lblCodigo.Text);
                objProducto = objProductoBL.Modificar(objProducto);
            }
            else
            {
                objProducto = objProductoBL.Registrar(objProducto);
                MessageBox.Show("Se registro el producto con id " + objProducto.id_producto);
            }

            if (objProducto.id_producto.Equals(0))
            {
                MessageBox.Show("No se pudo realizar el registro");
            }
            else {
                frm.CargarProductos();
                this.Close();
            }
        }
    }
}
