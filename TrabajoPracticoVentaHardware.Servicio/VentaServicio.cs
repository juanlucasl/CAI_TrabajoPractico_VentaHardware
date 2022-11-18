using System.Collections.Generic;
using System.Configuration;
using TrabajoPracticoVentaHardware.AccesoDatos;
using TrabajoPracticoVentaHardware.Entidades;
using TrabajoPracticoVentaHardware.Entidades.Excepciones;

namespace TrabajoPracticoVentaHardware.Servicio
{
    public class VentaServicio
    {
        // Constructor
        public VentaServicio()
        {
            _ventaDatos = new VentaDatos();
            _clienteServicio = new ClienteServicio();
            _productoServicio = new ProductoServicio();
        }

        // Atributos
        private readonly VentaDatos _ventaDatos;
        private readonly ClienteServicio _clienteServicio;
        private readonly ProductoServicio _productoServicio;

        // Metodos

        /// <summary>Devuelve una coleccion con todas las ventas correspondientes al TP.</summary>
        /// <returns>Coleccion con todas las ventas correspondientes al TP.</returns>
        public List<Venta> ObtenerVentas()
        {
            return _ventaDatos.ObtenerTodas();
        }

        /// <summary>Recibe una venta para almacenar en el sistema.</summary>
        /// <param name="venta">Venta a almacenar.</param>
        /// <returns>Resultado de la transaccion.</returns>
        public int InsertarVenta(Venta venta)
        {
            if (venta.Cantidad > int.Parse(ConfigurationManager.AppSettings["PRODUCTO_STOCK_MAXIMO"]))
                throw new DatosIngresadosInvalidosException($"Cantidad vendida demasiado elevada (debe ser menor a {ConfigurationManager.AppSettings["PRODUCTO_STOCK_MAXIMO"]})");

            Cliente clienteVenta = _clienteServicio.ObtenerClientePorId(venta.IdCliente);
            if (clienteVenta == null)
                throw new DatosIngresadosInvalidosException($"No existe un Cliente con Id {venta.IdCliente}");

            Producto productoVenta = _productoServicio.ObtenerProductoPorId(venta.IdProducto);
            if (productoVenta == null)
                throw new DatosIngresadosInvalidosException($"No existe un Producto con Id {venta.IdProducto}");

            ResultadoTransaccion resultadoTransaccion = _ventaDatos.InsertarVenta(venta);

            if (!resultadoTransaccion.IsOk) throw new TransaccionFallidaException(resultadoTransaccion.Error);

            return resultadoTransaccion.Id;
        }
    }
}
