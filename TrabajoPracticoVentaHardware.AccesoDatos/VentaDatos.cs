using System.Collections.Generic;
using System.Configuration;
using Newtonsoft.Json;
using TrabajoPracticoVentaHardware.AccesoDatos.Utilidades;
using TrabajoPracticoVentaHardware.Entidades;

namespace TrabajoPracticoVentaHardware.AccesoDatos
{
    public class VentaDatos
    {
        /// <summary>Devuelve una coleccion con todas las ventas correspondientes al TP.</summary>
        /// <returns>Coleccion con todas las ventas correspondientes al TP.</returns>
        public List<Venta> ObtenerTodas()
        {
            string json = WebHelper.Get($"{ConfigurationManager.AppSettings["TP_CATEGORIA"]}/{ConfigurationManager.AppSettings["PATH_VENTA"]}");
            List<Venta> resultado = MapearColeccion(json);
            return resultado;
        }
        
        /// <summary>
        /// Recibe un json con un array con informacion de ventas y devuelve una coleccion de Ventas
        /// representando esa misma informacion.
        /// </summary>
        /// <param name="json">Json de Ventas.</param>
        /// <returns>Coleccion de Ventas.</returns>
        private List<Venta> MapearColeccion(string json)
        {
            List<Venta> ventas = JsonConvert.DeserializeObject<List<Venta>>(json);
            return ventas;
        }
    }
}
