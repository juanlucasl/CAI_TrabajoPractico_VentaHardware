using System.Collections.Generic;
using TrabajoPracticoVentaHardware.AccesoDatos;
using TrabajoPracticoVentaHardware.Entidades;

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

        /// <summary>Devuelve una coleccion con todos los productos correspondientes al TP.</summary>
        /// <returns>Coleccion con todos los productos correspondientes al TP.</returns>
        public List<Producto> ObtenerProductos()
        {
            return _productoDatos.ObtenerTodos();
        }
    }
}
