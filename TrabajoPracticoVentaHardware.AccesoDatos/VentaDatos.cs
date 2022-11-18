using System.Collections.Generic;
using System.Collections.Specialized;
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

        /// <summary>Envia una peticion para almacenar una venta en el sistema.</summary>
        /// <param name="venta">Venta a almacenar.</param>
        /// <returns>Resultado de la transaccion.</returns>
        public ResultadoTransaccion InsertarVenta(Venta venta)
        {
            NameValueCollection ventaDatos = ReverseMap(venta);
            string json = WebHelper.Post($"{ConfigurationManager.AppSettings["TP_CATEGORIA"]}/{ConfigurationManager.AppSettings["PATH_VENTA"]}", ventaDatos);

            ResultadoTransaccion resultadoTransaccion = JsonConvert.DeserializeObject<ResultadoTransaccion>(json);
            return resultadoTransaccion;
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

        /// <summary>Recibe una Venta y la mapea a una colección de claves y valores string.</summary>
        /// <param name="venta">Venta a serializar.</param>
        /// <returns>Venta mapeada.</returns>
        private static NameValueCollection ReverseMap(Venta venta)
        {
            NameValueCollection ventaMap = new NameValueCollection
            {
                { "IdCliente", venta.IdCliente.ToString() },
                { "IdProducto", venta.IdProducto.ToString() },
                { "Cantidad", venta.Cantidad.ToString() },
                { "FechaAlta", venta.FechaAlta.ToString("yyyy-MM-dd") },
                { "Usuario", ConfigurationManager.AppSettings["TP_ID"] }
            };

            return ventaMap;
        }
    }
}
