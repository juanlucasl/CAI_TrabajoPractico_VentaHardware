using System.Collections.Generic;
using TrabajoPracticoVentaHardware.Entidades;

namespace TrabajoPracticoVentaHardware.Servicio
{
    internal static class ReporteHelper
    {
        /// <summary>
        /// Recibe una Lista de ventas y una Lista de productos y devuelve una Lista de Entidades representando a la
        /// Venta junto con el Producto que se vendio.
        /// </summary>
        /// <param name="ventas">Lista de ventas.</param>
        /// <param name="productos">Lista de productos.</param>
        /// <returns>Lista de ventas con el producto que se vendio en cada una.</returns>
        internal static List<VentaProductoHelper> VincularVentasYProductos(List<Venta> ventas, List<Producto> productos)
        {
            List<VentaProductoHelper> ventasDeProductos = new List<VentaProductoHelper>();
            foreach (Venta venta in ventas)
            {
                Producto productoVentaCliente = productos.Find(producto => producto.Id == venta.IdProducto);

                if (productoVentaCliente != null) // No mostrar la venta si no se encuentra el producto.
                    ventasDeProductos.Add(new VentaProductoHelper(venta, productoVentaCliente));
            }

            return ventasDeProductos;
        }

        /// <summary>
        /// Recibe una Lista de ventas, una Lista de clientes y un Producto y devuelve una Lista de Entidades
        /// representando a la Venta junto con el Cliente al que se le realizó la Venta.
        /// </summary>
        /// <param name="ventas">Lista de ventas.</param>
        /// <param name="clientes">Lista de clientes.</param>
        /// <param name="producto">Producto que se vendio.</param>
        /// <returns>Lista de ventas con el cliente que fue participe en cada una.</returns>
        internal static List<VentaProductoHelper> VincularVentasYProductos(List<Venta> ventas, List<Cliente> clientes, Producto producto)
        {
            List<VentaProductoHelper> ventasClientes = new List<VentaProductoHelper>();
            foreach (Venta venta in ventas)
            {
                Cliente ventaCliente = clientes.Find(cliente => cliente.Id == venta.IdCliente);

                if (ventaCliente != null) // No mostrar la venta si no se encuentra el cliente.
                    ventasClientes.Add(new VentaProductoHelper(venta, producto, ventaCliente));
            }

            return ventasClientes;
        }
    }
}
