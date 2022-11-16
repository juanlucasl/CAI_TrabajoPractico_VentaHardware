using System;
using System.Collections.Generic;
using TrabajoPracticoVentaHardware.AccesoDatos;
using TrabajoPracticoVentaHardware.Entidades;
using TrabajoPracticoVentaHardware.Entidades.Excepciones;

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

        /// <summary>Recibe un cliente para almacenar en el sistema.</summary>
        /// <param name="cliente">Cliente a almacenar.</param>
        /// <returns>Resultado de la transaccion.</returns>
        public int InsertarCliente(Cliente cliente)
        {
            ResultadoTransaccion resultadoTransaccion = _clienteDatos.InsertarCliente(cliente);

            if (!resultadoTransaccion.IsOk) throw new TransaccionFallidaException(resultadoTransaccion.Error);

            return resultadoTransaccion.Id;
        }
    }
}
