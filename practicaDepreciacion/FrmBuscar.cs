using AppCore.IServices;
using Domain.Entities;
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
    public partial class FrmBuscar : Form
    {
        IActivoServices activoServices;
        IEmpleadoServices empleadoServices;
        public FrmBuscar(IActivoServices ActivoServices, IEmpleadoServices EmpleadoServices)
        {
            this.activoServices = ActivoServices;
            this.empleadoServices = EmpleadoServices;
            InitializeComponent();
        }

        private void FrmAsignacion_Load(object sender, EventArgs e)
        {
            
        }

        private class Act
        {
            public string ActivosAsignados { get; set; }
        }

        private void btnFindActivo_Click(object sender, EventArgs e)
        {
            if(cmbEmpleadoId.SelectedItem == null)
            {
            }
            else
            {
                dataGridView1.DataSource = null;
                List<Activo> activo = activoServices.Read();
                List<Act> nombres = new List<Act>();
                for (int i = 0; i < activo.Count; i++)
                {

                    if (activo[i].IdEmpleado == (int)cmbEmpleadoId.SelectedItem)
                    {
                        Act act = new Act
                        {
                            ActivosAsignados = activo[i].Nombre
                        };
                        nombres.Add(act);
                    }
                }
                dataGridView1.DataSource = nombres;
            }
            
            
        }

        private void FrmBuscar_Load(object sender, EventArgs e)
        {
            AgregarItems();
            if (cmbEmpleado.SelectedIndex == -1)
            {
            }
            else
            {
                cmbEmpleado.SelectedIndex = 0;
            }
            
        }
        
        public void AgregarItems()
        {
            List<Empleado> empleado = empleadoServices.Read();
            foreach (Empleado emp in empleado)
            {
                cmbEmpleadoId.Items.Add(emp.Id);
                cmbEmpleado.Items.Add(emp.Nombres);
            }
        }

        private void cmbEmpleado_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbEmpleadoId.SelectedIndex = cmbEmpleado.SelectedIndex;
        }
    }
}
