using System.Collections.Generic;
using System.Configuration;
using Newtonsoft.Json;
using TrabajoPracticoVentaHardware.AccesoDatos.Utilidades;
using TrabajoPracticoVentaHardware.Entidades;

namespace TrabajoPracticoVentaHardware.AccesoDatos
{
    public class ProveedorDatos
    {
        /// <summary>Devuelve una coleccion con todos los proveedores correspondientes al TP.</summary>
        /// <returns>Coleccion con todos los proveedores correspondientes al TP.</returns>
        public List<Proveedor> ObtenerTodos()
        {
            string json = WebHelper.Get($"{ConfigurationManager.AppSettings["TP_CATEGORIA"]}/{ConfigurationManager.AppSettings["PATH_PROVEEDOR"]}");
            List<Proveedor> resultado = MapearColeccion(json);
            return resultado;
        }

        /// <summary>
        /// Recibe un json con un array con informacion de proveedores y devuelve una coleccion de Proveedores
        /// representando esa misma informacion.
        /// </summary>
        /// <param name="json">Json de Proveedores.</param>
        /// <returns>Coleccion de Proveedores.</returns>
        private List<Proveedor> MapearColeccion(string json)
        {
            List<Proveedor> proveedores = JsonConvert.DeserializeObject<List<Proveedor>>(json);
            return proveedores;
        }
    }
}
