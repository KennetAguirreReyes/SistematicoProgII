using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public class StreamEmpleadoRepository : IEmpleadoModel
    {
        private BinaryReader binaryReader;
        private BinaryWriter binaryWriter;
        private string fileName = "activo.dat";
        public StreamEmpleadoRepository()
        {

        }

        public void Add(Empleado t)
        {
            try
            {
                int id = 0;
                Empleado last = Read().LastOrDefault();
                if (last == null)
                {
                    id = 1;
                }
                else
                {
                    id = last.Id + 1;
                }

                using (FileStream fileStream = new FileStream(fileName, FileMode.Append, FileAccess.Write))
                {
                    binaryWriter = new BinaryWriter(fileStream);
                    binaryWriter.Write(id);
                    binaryWriter.Write(t.Nombres);
                    binaryWriter.Write(t.Apellidos);
                    binaryWriter.Write(t.Cedula);
                    binaryWriter.Write(t.Direccion);
                    binaryWriter.Write(t.Telefono);
                    binaryWriter.Write(t.Email);
                    binaryWriter.Write(t.EstadoEmpleado);
                }

            }
            catch (IOException)
            {
                throw;
            }
        }

        public void Delete(Empleado t)
        {
            throw new NotImplementedException();
        }

        public Empleado GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Empleado> Read()
        {
            throw new NotImplementedException();
        }

        public void Update(Empleado t)
        {
            throw new NotImplementedException();
        }
    }
}
