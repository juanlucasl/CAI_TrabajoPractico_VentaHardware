using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Globalization;
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

        /// <summary>Envia una peticion para almacenar un producto en el sistema.</summary>
        /// <param name="producto">Producto a almacenar.</param>
        /// <returns>Resultado de la transaccion.</returns>
        public ResultadoTransaccion InsertarProducto(Producto producto)
        {
            NameValueCollection productoDatos = ReverseMap(producto);
            string json = WebHelper.Post($"{ConfigurationManager.AppSettings["TP_CATEGORIA"]}/{ConfigurationManager.AppSettings["PATH_PRODUCTO"]}", productoDatos);

            ResultadoTransaccion resultadoTransaccion = JsonConvert.DeserializeObject<ResultadoTransaccion>(json);
            return resultadoTransaccion;
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

        /// <summary>Recibe un Producto y lo mapea a una colección de claves y valores string.</summary>
        /// <param name="producto">Producto a serializar.</param>
        /// <returns>Producto mapeado.</returns>
        private static NameValueCollection ReverseMap(Producto producto)
        {
            NameValueCollection productoMap = new NameValueCollection
            {
                { "Nombre", producto.Nombre },
                { "IdCategoria", Convert.ToInt32(producto.IdCategoria).ToString() },
                { "FechaAlta", producto.FechaAlta.ToString("yyyy-MM-dd") },
                { "Precio", producto.Precio.ToString("F", CultureInfo.GetCultureInfo("es-AR")) },
                { "Stock", producto.Stock.ToString() },
                { "Usuario", ConfigurationManager.AppSettings["TP_ID"] }
            };

            return productoMap;
        }
    }
}
