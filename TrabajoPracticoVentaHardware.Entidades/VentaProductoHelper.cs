using System.Globalization;

namespace TrabajoPracticoVentaHardware.Entidades
{
    /// <summary>Entidad que representa a una Venta junto con el Producto que se vendio.</summary>
    public class VentaProductoHelper
    {
        public VentaProductoHelper(Venta venta, Producto producto)
        {
            _venta = venta;
            _producto = producto;
            _cliente = null;
        }

        public VentaProductoHelper(Venta venta, Producto producto, Cliente cliente)
        {
            _venta = venta;
            _producto = producto;
            _cliente = cliente;
        }

        // Atributos
        private readonly Venta _venta;
        private readonly Producto _producto;
        private readonly Cliente _cliente;

        // Metodos
        public override string ToString()
        {
            string encabezado = (_cliente == null)
                ? $"Producto: {_producto.Nombre} ({_producto.IdCategoria})"
                : $"Cliente: {_cliente.NombreCompleto}";

            return $"{encabezado}\n" +
                   $"Cantidad comprada: {_venta.Cantidad}\n" +
                   $"Valor a precio actual: {(_venta.Cantidad * _producto.Precio).ToString("C", CultureInfo.GetCultureInfo("es-AR"))}\n" +
                   $"Fecha de ejecucion: {_venta.FechaAlta}\n";
        }
    }
}
