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
    public partial class FrmActivo : Form
    {
        IActivoServices activoServices;
        IEmpleadoServices empleadoServices;
        public FrmActivo(IActivoServices ActivoServices, IEmpleadoServices EmpleadoServices)
        {
            this.activoServices = ActivoServices;
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

    

        private void txtValor_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("No se puede LETRAS");
            }
        }

        private void txtValorR_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("No se puede LETRAS");
            }
        }

        private void txtVidaU_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("No se puede LETRAS");
            }
        }
        private bool verificar()
        { 
            if (String.IsNullOrEmpty(txtNombre.Text) || String.IsNullOrEmpty(txtDescripcion.Text) || String.IsNullOrEmpty(txtValor.Text) || String.IsNullOrEmpty(txtVidaU.Text) || String.IsNullOrEmpty(txtValorR.Text) || cmbEstadoActivo.SelectedIndex < 0) 
            {
              
                return false;
            }
            return true;
        }
        private void limpiar()
        {
            this.txtId.Text = String.Empty;
            this.txtNombre.Text = String.Empty;
            this.txtValor.Text = String.Empty;
            this.txtValorR.Text = String.Empty;
            this.txtVidaU.Text = String.Empty;
            this.txtDescripcion.Text = string.Empty;
            this.cmbEstadoActivo.Text = string.Empty;
            //this.cmbEstadoActivo.ResetText();
            this.txtCodigo.Text = String.Empty;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                int f = e.RowIndex;
                txtId.Text = dataGridView1.Rows[e.RowIndex].Cells["Id"].Value.ToString();
                txtNombre.Text = dataGridView1.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
                txtDescripcion.Text = dataGridView1.Rows[e.RowIndex].Cells["Descripcion"].Value.ToString();
                txtValor.Text = dataGridView1.Rows[e.RowIndex].Cells["Valor"].Value.ToString();
                txtValorR.Text = dataGridView1.Rows[e.RowIndex].Cells["ValorResidual"].Value.ToString();
                txtVidaU.Text = dataGridView1.Rows[e.RowIndex].Cells["VidaUtil"].Value.ToString();
                txtCodigo.Text = dataGridView1.Rows[e.RowIndex].Cells["Codigo"].Value.ToString();
                cmbEstadoActivo.Text = dataGridView1.Rows[e.RowIndex].Cells["EstadoActivo"].Value.ToString();
            }
            if (e.RowIndex >= 0 && !(e.ColumnIndex == 0))
            {
                FrmDepreciacion depreciacion = new FrmDepreciacion(activoServices.Read()[e.RowIndex]);
                depreciacion.ShowDialog();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = activoServices.Read();
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = false;
            AgregarItems();
        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {
            if (txtId.Text == String.Empty)
            {
                if (txtNombre.Text == String.Empty)
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

        private void btnFind_Click(object sender, EventArgs e)
        {
            //bool verificado;
            //if (String.IsNullOrEmpty(txtFind.Text))
            //{
            //    verificado = false;


            //}
            //else
            //{
            //    verificado = true;
            //}

            //if (verificado == false)
            //{
            //    MessageBox.Show("Tienes que llenar todos los campos.");
            //}
            //else
            //{
                
            //    activoServices.GetById(int.Parse(txtFind.Text));
            //}
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

                string estado = ((EstadoActivo)cmbEstadoActivo.SelectedIndex).ToString();
                int idemp = 0;
                Activo activo = new Activo()
                {
                    Nombre = txtNombre.Text,
                    Descripcion = txtDescripcion.Text,
                    Valor = double.Parse(txtValor.Text),
                    ValorResidual = double.Parse(txtValorR.Text),
                    VidaUtil = int.Parse(txtVidaU.Text),
                    Codigo = Guid.NewGuid().ToString(),
                    EstadoActivo = EstadoAsignado(estado),
                    IdEmpleado = asignarIdemp(idemp)

                };
                activoServices.Add(activo);
                dataGridView1.DataSource = null;
                limpiar();
                dataGridView1.DataSource = activoServices.Read();
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
                string estado = ((EstadoActivo)cmbEstadoActivo.SelectedIndex).ToString();
                int idemp = 0;
                Activo activo = new Activo()
                {
                    Id = int.Parse(txtId.Text),
                    Nombre = txtNombre.Text,
                    Descripcion = txtDescripcion.Text,
                    Valor = double.Parse(txtValor.Text),
                    ValorResidual = double.Parse(txtValorR.Text),
                    VidaUtil = int.Parse(txtVidaU.Text),
                    Codigo =txtCodigo.Text,
                    EstadoActivo = EstadoAsignado(estado),
                    IdEmpleado = asignarIdemp(idemp)
                };
                activoServices.Update(activo);
                dataGridView1.DataSource = null;
                limpiar();
                dataGridView1.DataSource = activoServices.Read();

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
                int idemp = 0;
                Activo activo = new Activo()
                {
                    Id = int.Parse(txtId.Text),
                    Nombre = txtNombre.Text,
                    Descripcion = txtDescripcion.Text,
                    Valor = double.Parse(txtValor.Text),
                    ValorResidual = double.Parse(txtValorR.Text),
                    VidaUtil = int.Parse(txtVidaU.Text),
                    Codigo = txtCodigo.Text,
                    EstadoActivo = ((EstadoActivo)cmbEstadoActivo.SelectedIndex).ToString(),
                    IdEmpleado = asignarIdemp(idemp)
                };
                activoServices.Delete(activo);
                dataGridView1.DataSource = null;
                limpiar();
                dataGridView1.DataSource = activoServices.Read();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void AgregarItems()
        {
            List<Empleado> empleado = empleadoServices.Read();
            foreach(Empleado emp in empleado)
            {
                cmbEmpleadoId.Items.Add(emp.Id);
                cmbEmpleado.Items.Add(emp.Nombres);
            }
        }

        private void cmbEmpleado_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbEmpleadoId.SelectedIndex = cmbEmpleado.SelectedIndex;

        }

        public string EstadoAsignado(string estado)
        {
            if (cmbEmpleadoId.SelectedItem != null)
            {
                estado = "asignado";
            }
            return estado;
        }

        public int asignarIdemp(int idemp)
        {
            if (cmbEmpleadoId.SelectedItem == null)
            {
                idemp = 0;
            }
            else
            {
                idemp = (int)cmbEmpleadoId.SelectedItem;
            }
            return idemp;
        }
    }    
}
