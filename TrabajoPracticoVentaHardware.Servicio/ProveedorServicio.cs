using System.Collections.Generic;
using TrabajoPracticoVentaHardware.AccesoDatos;
using TrabajoPracticoVentaHardware.Entidades;

namespace TrabajoPracticoVentaHardware.Servicio
{
    public class ProveedorServicio
    {
        // Constructor
        public ProveedorServicio()
        {
            _proveedorDatos = new ProveedorDatos();
        }

        // Atributos
        private readonly ProveedorDatos _proveedorDatos;

        /// <summary>Devuelve una coleccion con todos los proveedores correspondientes al TP.</summary>
        /// <returns>Coleccion con todos los proveedores correspondientes al TP.</returns>
        public List<Proveedor> ObtenerProveedores()
        {
            return _proveedorDatos.ObtenerTodos();
        }
    }
}
