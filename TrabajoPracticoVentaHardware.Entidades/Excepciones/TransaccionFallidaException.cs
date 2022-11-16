using System;

namespace TrabajoPracticoVentaHardware.Entidades.Excepciones
{
    public class TransaccionFallidaException: Exception
    {
        public TransaccionFallidaException(string message) : base(message)
        {
        }
    }
}
