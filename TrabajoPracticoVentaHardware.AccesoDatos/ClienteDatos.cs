using System.Collections.Generic;
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
            string json2 = WebHelper.Get("cliente");
            List<Cliente> resultado = MapearColeccion(json2);
            return resultado;
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
    }
}
