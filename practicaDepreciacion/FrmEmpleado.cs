using AppCore.IServices;
using Domain.Entities;
using Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace practicaDepreciacion
{
    public partial class FrmEmpleado : Form
    {
        IEmpleadoServices empleadoServices;
        public FrmEmpleado(IEmpleadoServices EmpleadoServices)
        {
            this.empleadoServices = EmpleadoServices;
            InitializeComponent();
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("No se puede numeros");
            }
        }

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("No se puede numeros");
            }
        }

        private bool verificar()
        {
            if (String.IsNullOrEmpty(txtNombres.Text) || String.IsNullOrEmpty(txtApellidos.Text) || String.IsNullOrEmpty(txtCedula.Text) || String.IsNullOrEmpty(txtDireccion.Text) || String.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtTelefono.Text) || cmbEstadoEmpleado.SelectedIndex < 0)
            {

                return false;
            }
            return true;
        }

        private void limpiar()
        {
            this.txtId.Text = String.Empty;
            this.txtNombres.Text = String.Empty;
            this.txtApellidos.Text = String.Empty;
            this.txtCedula.Text = String.Empty;
            this.txtDireccion.Text = String.Empty;
            this.txtEmail.Text = string.Empty;
            this.txtTelefono.Text = string.Empty;
            this.cmbEstadoEmpleado.Text = string.Empty;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                int f = e.RowIndex;
                txtId.Text = dataGridView1.Rows[e.RowIndex].Cells["Id"].Value.ToString();
                txtCedula.Text = dataGridView1.Rows[e.RowIndex].Cells["Cedula"].Value.ToString();
                txtNombres.Text = dataGridView1.Rows[e.RowIndex].Cells["Nombres"].Value.ToString();
                txtApellidos.Text = dataGridView1.Rows[e.RowIndex].Cells["Apellidos"].Value.ToString();
                txtDireccion.Text = dataGridView1.Rows[e.RowIndex].Cells["Direccion"].Value.ToString();
                txtTelefono.Text = dataGridView1.Rows[e.RowIndex].Cells["Telefono"].Value.ToString();
                txtEmail.Text = dataGridView1.Rows[e.RowIndex].Cells["Email"].Value.ToString();
                cmbEstadoEmpleado.Text = dataGridView1.Rows[e.RowIndex].Cells["EstadoEmpleado"].Value.ToString();
            }
        }

        private void FrmEmpleado_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = empleadoServices.Read();
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = false;
        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {
            if (txtId.Text == String.Empty)
            {
                if (txtNombres.Text == String.Empty)
                {
                    btnSave.Enabled = false;
                }
                else
                {
                    btnSave.Enabled = true;
                }
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
            }
            else
            {
                btnSave.Enabled = false;
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool verificado = verificar();
            if (verificado == false)
            {
                MessageBox.Show("Tienes que llenar todos los campos.");
            }
            else
            {
                Empleado empleado = new Empleado()
                {
                    Cedula = txtCedula.Text,
                    Nombres = txtNombres.Text,
                    Apellidos = txtApellidos.Text,
                    Direccion = txtDireccion.Text,
                    Telefono = txtTelefono.Text,
                    Email = txtEmail.Text,
                    EstadoEmpleado = ((EstadoEmpleado)cmbEstadoEmpleado.SelectedIndex).ToString()

                };
                empleadoServices.Add(empleado);
                dataGridView1.DataSource = null;
                limpiar();
                dataGridView1.DataSource = empleadoServices.Read();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            bool verificado = verificar();
            if (verificado == false)
            {
                MessageBox.Show("Tienes que llenar todos los campos.");
            }
            else
            {
                Empleado empleado = new Empleado()
                {
                    Id = int.Parse(txtId.Text),
                    Cedula = txtCedula.Text,
                    Nombres = txtNombres.Text,
                    Apellidos = txtApellidos.Text,
                    Direccion = txtDireccion.Text,
                    Telefono = txtTelefono.Text,
                    Email = txtEmail.Text,
                    EstadoEmpleado = ((EstadoEmpleado)cmbEstadoEmpleado.SelectedIndex).ToString()

                };
                empleadoServices.Update(empleado);
                dataGridView1.DataSource = null;
                limpiar();
                dataGridView1.DataSource = empleadoServices.Read();

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            bool verificado = verificar();
            if (verificado == false)
            {
                MessageBox.Show("Tienes que llenar todos los campos.");
            }
            else
            {

                Empleado empleado = new Empleado()
                {
                    Id = int.Parse(txtId.Text),
                    Cedula = txtCedula.Text,
                    Nombres = txtNombres.Text,
                    Apellidos = txtApellidos.Text,
                    Direccion = txtDireccion.Text,
                    Telefono = txtTelefono.Text,
                    Email = txtEmail.Text,
                    EstadoEmpleado = ((EstadoEmpleado)cmbEstadoEmpleado.SelectedIndex).ToString()
                };
                empleadoServices.Delete(empleado);
                dataGridView1.DataSource = null;
                limpiar();
                dataGridView1.DataSource = empleadoServices.Read();
            }
        }
    }
}
