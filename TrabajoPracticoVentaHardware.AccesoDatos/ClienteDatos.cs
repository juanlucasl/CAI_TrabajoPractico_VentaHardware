using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using TrabajoPracticoVentaHardware.Entidades;
using TrabajoPracticoVentaHardware.AccesoDatos.Utilidades;
using Newtonsoft.Json;

namespace TrabajoPracticoVentaHardware.AccesoDatos
{
    public class ClienteDatos
    {
        /// <summary>Devuelve una coleccion con todos los clientes correspondientes al TP.</summary>
        /// <returns>Coleccion con todos los clientes correspondientes al TP.</returns>
        public List<Cliente> ObtenerTodos()
        {
            string json = WebHelper.Get("cliente");
            List<Cliente> resultado = MapearColeccion(json);
            return resultado;
        }

        /// <summary>Envia una peticion para almacenar un cliente en el sistema.</summary>
        /// <param name="cliente">Cliente a almacenar.</param>
        /// <returns>Resultado de la transaccion.</returns>
        public ResultadoTransaccion InsertarCliente(Cliente cliente)
        {
            NameValueCollection clienteDatos = ReverseMap(cliente);
            string json = WebHelper.Post("cliente", clienteDatos);

            ResultadoTransaccion resultadoTransaccion = JsonConvert.DeserializeObject<ResultadoTransaccion>(json);
            return resultadoTransaccion;
        }

        /// <summary>
        /// Recibe un json con un array con informacion de clientes y devuelve una coleccion de Clientes
        /// representando esa misma informacion.
        /// </summary>
        /// <param name="json">Json de Clientes.</param>
        /// <returns>Coleccion de Clientes.</returns>
        private List<Cliente> MapearColeccion(string json)
        {
            List<Cliente> clientes = JsonConvert.DeserializeObject<List<Cliente>>(json);
            return clientes;
        }

        /// <summary>Recibe un Cliente y lo mapea a una colección de claves y valores string.</summary>
        /// <param name="cliente">Cliente a serializar.</param>
        /// <returns>Cliente mapeado.</returns>
        private static NameValueCollection ReverseMap(Cliente cliente)
        {
            NameValueCollection clienteMap = new NameValueCollection
            {
                { "Nombre", cliente.Nombre },
                { "Apellido", cliente.Apellido },
                { "Direccion", cliente.Direccion },
                { "Telefono", cliente.Telefono.ToString() },
                { "Email", cliente.Email },
                { "Activo", cliente.Activo.ToString() },
                { "FechaNacimiento", cliente.FechaAlta.ToString("yyyy-MM-dd") },
                { "Usuario", ConfigurationManager.AppSettings["TP_ID"] }
            };

            return clienteMap;
        }
    }
}
