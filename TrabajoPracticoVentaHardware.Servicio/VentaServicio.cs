using System.Collections.Generic;
using TrabajoPracticoVentaHardware.AccesoDatos;
using TrabajoPracticoVentaHardware.Entidades;

namespace TrabajoPracticoVentaHardware.Servicio
{
    public class VentaServicio
    {
        // Constructor
        public VentaServicio()
        {
            _ventaDatos = new VentaDatos();
        }

        // Atributos
        private readonly VentaDatos _ventaDatos;

        // Metodos

        /// <summary>Devuelve una coleccion con todas las ventas correspondientes al TP.</summary>
        /// <returns>Coleccion con todas las ventas correspondientes al TP.</returns>
        public List<Venta> ObtenerVentas()
        {
            return _ventaDatos.ObtenerTodas();
        }
    }
}
