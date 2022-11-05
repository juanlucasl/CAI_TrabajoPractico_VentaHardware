using System.Collections.Generic;
using TrabajoPracticoVentaHardware.AccesoDatos;
using TrabajoPracticoVentaHardware.Entidades;

namespace TrabajoPracticoVentaHardware.Servicio
{
    public class ClienteServicio
    {
        // Constructor
        public ClienteServicio()
        {
            _clienteDatos = new ClienteDatos();
        }

        // Atributos
        private readonly ClienteDatos _clienteDatos;

        // Metodos

        /// <summary>Devuelve una coleccion con todos los clientes correspondientes al TP.</summary>
        /// <returns>Coleccion con todos los clientes correspondientes al TP.</returns>
        public List<Cliente> ObtenerClientes()
        {
            return _clienteDatos.ObtenerTodos();
        }
    }
}
