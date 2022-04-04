using AppCore.IServices;
using AppCore.Services;
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
    public partial class FrmMenuPrincipal : Form
    {
        IActivoServices activoServices;
        IEmpleadoServices empleadoServices;

        public FrmMenuPrincipal(IActivoServices ActivoServices, IEmpleadoServices EmpleadoServices)
        {
            this.activoServices = ActivoServices;
            this.empleadoServices = EmpleadoServices;
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnActivo_Click(object sender, EventArgs e)
        {
            FrmActivo frmActivo = new FrmActivo(activoServices, empleadoServices);
            frmActivo.Show();
        }

        private void btnEmpleado_Click(object sender, EventArgs e)
        {
            FrmEmpleado frmEmpleado = new FrmEmpleado(empleadoServices);
            frmEmpleado.Show();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            FrmBuscar frmBuscar = new FrmBuscar(activoServices, empleadoServices);
            frmBuscar.Show();
        }
    }
}
