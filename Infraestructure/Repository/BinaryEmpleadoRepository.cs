using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public class BinaryEmpleadoRepository : IEmpleadoModel
    {
        public RAFContext context;
        public const int SIZE = 600;
        public BinaryEmpleadoRepository()
        {
            context = new RAFContext("Empleado", SIZE);
        }

        public Empleado GetById(int id)
        {
            try
            {
                return context.Get<Empleado>(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Add(Empleado t)
        {
            try
            {
                context.Create<Empleado>(t);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(Empleado t)
        {
            try
            {
                context.Delete<Empleado>(t);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(Empleado t)
        {
            try
            {
                context.Update<Empleado>(t);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Empleado> Read()
        {
            try
            {
                return context.GetAll<Empleado>();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
