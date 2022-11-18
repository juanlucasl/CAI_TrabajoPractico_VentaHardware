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

        /// <summary>
        /// Recibe un Id y devuelve el Cliente correspondiente a ese Id, o null si no existe el Cliente.
        /// </summary>
        /// <param name="idCliente">Id de Cliente</param>
        /// <returns>Cliente correspondiente al Id</returns>
        public Cliente ObtenerClientePorId(int idCliente)
        {
            if (idCliente == 0) return null;

            List<Cliente> clientes = ObtenerClientes();
            return clientes.Find(cliente => cliente.Id == idCliente);
        }

        /// <summary>
        /// Recibe un string con un email y devuelve el Cliente correspondiente a ese email, o null si no existe el
        /// Cliente.
        /// </summary>
        /// <param name="clienteEmail">Email de Cliente</param>
        /// <returns>Cliente correspondiente al Email</returns>
        public Cliente ObtenerClientePorEmail(string clienteEmail)
        {
            if (string.IsNullOrEmpty(clienteEmail)) return null;

            List<Cliente> clientes = ObtenerClientes();
            return clientes.Find(cliente => cliente.Email == clienteEmail);
        }

        /// <summary>Recibe un cliente para almacenar en el sistema.</summary>
        /// <param name="cliente">Cliente a almacenar.</param>
        /// <returns>Resultado de la transaccion.</returns>
        public int InsertarCliente(Cliente cliente)
        {
            Cliente clienteObtenidoPorMail = ObtenerClientePorEmail(cliente.Email);
            if (clienteObtenidoPorMail != null)
                throw new DatosIngresadosInvalidosException($"Ya existe un Cliente con email {cliente.Email}");

            ResultadoTransaccion resultadoTransaccion = _clienteDatos.InsertarCliente(cliente);

            if (!resultadoTransaccion.IsOk) throw new TransaccionFallidaException(resultadoTransaccion.Error);

            return resultadoTransaccion.Id;
        }
    }
}
