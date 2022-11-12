using System;
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
            _productoServicio = new ProductoServicio();
            _proveedorServicio = new ProveedorServicio();
        }

        // Atributos
        private readonly ProductoServicio _productoServicio;
        private readonly ProveedorServicio _proveedorServicio;

        // Metodos

        /// <summary>
        /// Devuelve un reporte de todos los productos correspondientes al TP, clasificados en base al proveedor que los
        /// provee.
        /// </summary>
        public List<Reporte<Producto, Proveedor>> ObtenerReporteProductoPorProveedor()
        {
            List<Producto> productos = _productoServicio.ObtenerProductos();
            List<Proveedor> proveedores = _proveedorServicio.ObtenerProveedores();
            List<Reporte<Producto, Proveedor>> reporteProductoPorProveedor = new List<Reporte<Producto, Proveedor>>();

            foreach (Producto producto in productos)
            {
                Proveedor proveedorProducto = proveedores.Find(proveedor => proveedor.IdProducto == producto.Id);
                reporteProductoPorProveedor.Add(new Reporte<Producto, Proveedor>(producto, proveedorProducto));
            }

            return reporteProductoPorProveedor;
        }
    }
}
