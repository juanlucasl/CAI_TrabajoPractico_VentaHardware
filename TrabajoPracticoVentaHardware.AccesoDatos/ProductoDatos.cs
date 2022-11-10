using System.Collections.Generic;
using System.Configuration;
using Newtonsoft.Json;
using TrabajoPracticoVentaHardware.AccesoDatos.Utilidades;
using TrabajoPracticoVentaHardware.Entidades;

namespace TrabajoPracticoVentaHardware.AccesoDatos
{
    public class ProductoDatos
    {
        /// <summary>Devuelve una coleccion con todos los productos correspondientes al TP.</summary>
        /// <returns>Coleccion con todos los productos correspondientes al TP.</returns>
        public List<Producto> ObtenerTodos()
        {
            string json = WebHelper.Get($"{ConfigurationManager.AppSettings["TP_CATEGORIA"]}/{ConfigurationManager.AppSettings["PATH_PRODUCTO"]}");
            List<Producto> resultado = MapearColeccion(json);
            return resultado;
        }

        /// <summary>
        /// Recibe un json con un array con informacion de productos y devuelve una coleccion de Productos
        /// representando esa misma informacion.
        /// </summary>
        /// <param name="json">Json de Productos.</param>
        /// <returns>Coleccion de Productos.</returns>
        private List<Producto> MapearColeccion(string json)
        {
            List<Producto> productos = JsonConvert.DeserializeObject<List<Producto>>(json);
            return productos;
        }
    }
}
