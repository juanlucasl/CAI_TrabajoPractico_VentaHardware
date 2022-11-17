using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using TrabajoPracticoVentaHardware.AccesoDatos;
using TrabajoPracticoVentaHardware.Entidades;
using TrabajoPracticoVentaHardware.Entidades.Excepciones;

namespace TrabajoPracticoVentaHardware.Servicio
{
    public class ProductoServicio
    {
        // Constructor
        public ProductoServicio()
        {
            _productoDatos = new ProductoDatos();
        }

        // Atributos
        private readonly ProductoDatos _productoDatos;

        // Metodos

        /// <summary>Devuelve una coleccion con todos los productos correspondientes al TP.</summary>
        /// <returns>Coleccion con todos los productos correspondientes al TP.</returns>
        public List<Producto> ObtenerProductos()
        {
            return _productoDatos.ObtenerTodos();
        }

        /// <summary>
        /// Recibe un Id y devuelve el Producto correspondiente a ese Id. Si no existe el producto, tira
        /// InvalidOperationException.
        /// </summary>
        /// <param name="productoId">Id de Producto</param>
        /// <returns>Producto correspondiente al Id</returns>
        public Producto ObtenerProductoPorId(int productoId)
        {
            List<Producto> productos = ObtenerProductos();
            return productos.Single(producto => producto.Id == productoId);
        }

        /// <summary>Recibe un producto para almacenar en el sistema.</summary>
        /// <param name="producto">Producto a almacenar.</param>
        /// <returns>Resultado de la transaccion.</returns>
        public int InsertarProducto(Producto producto)
        {
            if (producto.Precio > double.Parse(ConfigurationManager.AppSettings["PRODUCTO_PRECIO_MAXIMO"]))
                throw new DatosIngresadosInvalidosException($"Precio del Producto demasiado elevado (debe ser menor a {ConfigurationManager.AppSettings["PRODUCTO_PRECIO_MAXIMO"]})");

            if (producto.Stock > int.Parse(ConfigurationManager.AppSettings["PRODUCTO_STOCK_MAXIMO"]))
                throw new DatosIngresadosInvalidosException($"Stock del Producto demasiado elevado (debe ser menor a {ConfigurationManager.AppSettings["PRODUCTO_STOCK_MAXIMO"]})");

            ResultadoTransaccion resultadoTransaccion = _productoDatos.InsertarProducto(producto);

            if (!resultadoTransaccion.IsOk) throw new TransaccionFallidaException(resultadoTransaccion.Error);

            return resultadoTransaccion.Id;
        }
    }
}
