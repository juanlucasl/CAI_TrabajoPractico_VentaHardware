using System;

namespace TrabajoPracticoVentaHardware.Entidades.Excepciones
{
    public class DatosIngresadosInvalidosException : Exception
    {
        public DatosIngresadosInvalidosException(string message) : base(message)
        {
        }
    }
}
