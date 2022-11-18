using System.Collections.Generic;
using TrabajoPracticoVentaHardware.AccesoDatos;
using TrabajoPracticoVentaHardware.Entidades;
using TrabajoPracticoVentaHardware.Entidades.Excepciones;

namespace TrabajoPracticoVentaHardware.Servicio
{
    public class ProveedorServicio
    {
        // Constructor
        public ProveedorServicio()
        {
            _proveedorDatos = new ProveedorDatos();
            _productoServicio = new ProductoServicio();
        }

        // Atributos
        private readonly ProveedorDatos _proveedorDatos;
        private readonly ProductoServicio _productoServicio;

        // Metodos

        /// <summary>Devuelve una coleccion con todos los proveedores correspondientes al TP.</summary>
        /// <returns>Coleccion con todos los proveedores correspondientes al TP.</returns>
        public List<Proveedor> ObtenerProveedores()
        {
            return _proveedorDatos.ObtenerTodos();
        }

        /// <summary>Recibe un proveedor para almacenar en el sistema.</summary>
        /// <param name="proveedor">Proveedor a almacenar.</param>
        /// <returns>Resultado de la transaccion.</returns>
        public int InsertarProveedor(Proveedor proveedor)
        {
            Producto productoProveedor = _productoServicio.ObtenerProductoPorId(proveedor.IdProducto);
            if (productoProveedor == null)
                throw new DatosIngresadosInvalidosException($"No existe un Producto con Id {proveedor.IdProducto}");

            ResultadoTransaccion resultadoTransaccion = _proveedorDatos.InsertarProveedor(proveedor);

            if (!resultadoTransaccion.IsOk) throw new TransaccionFallidaException(resultadoTransaccion.Error);

            return resultadoTransaccion.Id;
        }
    }
}
