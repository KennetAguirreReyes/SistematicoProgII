using AppCore.IServices;
using AppCore.Services;
using Autofac;
using Domain.Interfaces;
using Infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace practicaDepreciacion
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Application.EnableVisualStyles();
            // Application.SetCompatibleTextRenderingDefault(false);
            //var builder = new ContainerBuilder();
            // builder.RegisterType<BinaryActivoRepository>().As<IActivoModel>();
            // builder.RegisterType<ActivoServices>().As<IActivoServices>();
            // var container = builder.Build();
            // Application.Run(new FrmActivo(container.Resolve<IActivoServices>()));
            
            //Application.Run(new FrmMenuPrincipal());
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var builder = new ContainerBuilder();
            builder.RegisterType<BinaryActivoRepository>().As<IActivoModel>();
            builder.RegisterType<ActivoServices>().As<IActivoServices>();
            var container = builder.Build();

            var builder1 = new ContainerBuilder();
            builder1.RegisterType<BinaryEmpleadoRepository>().As<IEmpleadoModel>();
            builder1.RegisterType<EmpleadoServices>().As<IEmpleadoServices>();
            var container1 = builder1.Build();
            Application.Run(new FrmMenuPrincipal(container.Resolve<IActivoServices>(), container1.Resolve<IEmpleadoServices>()));

        }
    }
}
