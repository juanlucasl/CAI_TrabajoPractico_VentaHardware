using System.Collections.Generic;
using System.Linq;
using TrabajoPracticoVentaHardware.Entidades;

namespace TrabajoPracticoVentaHardware.Servicio
{
    public class ReporteServicio
    {
        // Constructor
        public ReporteServicio()
        {
            _clienteServicio = new ClienteServicio();
            _productoServicio = new ProductoServicio();
            _ventaServicio = new VentaServicio();
            _proveedorServicio = new ProveedorServicio();
        }

        // Atributos
        private readonly ClienteServicio _clienteServicio;
        private readonly ProductoServicio _productoServicio;
        private readonly VentaServicio _ventaServicio;
        private readonly ProveedorServicio _proveedorServicio;

        // Metodos

        /// <summary>
        /// Devuelve un reporte de todas las ventas correspondientes al TP, clasificadas en base al cliente que las
        /// realizo.
        /// </summary>
        public List<ReporteVentasCliente> ObtenerReporteVentasPorCliente()
        {
            List<Cliente> clientes = _clienteServicio.ObtenerClientes();
            List<Venta> ventas = _ventaServicio.ObtenerVentas();
            List<Producto> productos = _productoServicio.ObtenerProductos();
            List<ReporteVentasCliente> reporteVentasPorCliente = new List<ReporteVentasCliente>();

            foreach (Cliente cliente in clientes)
            {
                List<Venta> ventasAlCliente = ventas.FindAll(venta => venta.IdCliente == cliente.Id);
                if(!ventasAlCliente.Any()) continue; // No incluir al Cliente en el Reporte si no tiene ventas asociadas.

                List<VentaProductoHelper> productosVentasCliente = ReporteHelper.VincularVentasYProductos(ventasAlCliente, productos);

                reporteVentasPorCliente.Add(new ReporteVentasCliente(productosVentasCliente, cliente));
            }

            return reporteVentasPorCliente;
        }

        /// <summary>
        /// Devuelve un reporte de todos los productos correspondientes al TP, clasificados en base al proveedor que los
        /// provee.
        /// </summary>
        public List<ReporteProductoProveedor> ObtenerReporteProductoPorProveedor()
        {
            List<Producto> productos = _productoServicio.ObtenerProductos();
            List<Proveedor> proveedores = _proveedorServicio.ObtenerProveedores();
            List<ReporteProductoProveedor> reporteProductoPorProveedor = new List<ReporteProductoProveedor>();

            foreach (Producto producto in productos)
            {
                Proveedor proveedorProducto = proveedores.Find(proveedor => proveedor.IdProducto == producto.Id);
                reporteProductoPorProveedor.Add(new ReporteProductoProveedor(producto, proveedorProducto));
            }

            return reporteProductoPorProveedor;
        }
    }
}
