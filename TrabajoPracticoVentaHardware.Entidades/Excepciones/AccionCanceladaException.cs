using System;

namespace TrabajoPracticoVentaHardware.Entidades.Excepciones
{
    public class AccionCanceladaException: Exception
    {
        public AccionCanceladaException(string message = "Accion cancelada.") : base(message)
        {
        }
    }
}
