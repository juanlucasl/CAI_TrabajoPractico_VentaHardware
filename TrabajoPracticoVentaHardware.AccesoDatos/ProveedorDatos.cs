using System.Collections.Generic;
using System.Collections.Specialized;
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

        /// <summary>Envia una peticion para almacenar un proveedor en el sistema.</summary>
        /// <param name="proveedor">Proveedor a almacenar.</param>
        /// <returns>Resultado de la transaccion.</returns>
        public ResultadoTransaccion InsertarProveedor(Proveedor proveedor)
        {
            NameValueCollection proveedorDatos = ReverseMap(proveedor);
            string json = WebHelper.Post($"{ConfigurationManager.AppSettings["TP_CATEGORIA"]}/{ConfigurationManager.AppSettings["PATH_PROVEEDOR"]}", proveedorDatos);

            ResultadoTransaccion resultadoTransaccion = JsonConvert.DeserializeObject<ResultadoTransaccion>(json);
            return resultadoTransaccion;
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

        /// <summary>Recibe un Proveedor y lo mapea a una colección de claves y valores string.</summary>
        /// <param name="proveedor">Proveedor a serializar.</param>
        /// <returns>Proveedor mapeado.</returns>
        private static NameValueCollection ReverseMap(Proveedor proveedor)
        {
            NameValueCollection proveedorMap = new NameValueCollection
            {
                { "Nombre", proveedor.Nombre },
                { "IdProducto", proveedor.IdProducto.ToString() },
                { "FechaAlta", proveedor.FechaAlta.ToString("yyyy-MM-dd") },
                { "Usuario", ConfigurationManager.AppSettings["TP_ID"] }
            };

            return proveedorMap;
        }
    }
}
