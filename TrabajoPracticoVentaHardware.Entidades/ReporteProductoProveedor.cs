namespace TrabajoPracticoVentaHardware.Entidades
{
    /// <summary>Objeto dentro de la Lista de un Reporte de Producto por Proveedor.</summary>
    public class ReporteProductoProveedor : Reporte<Producto, Proveedor>
    {
        public ReporteProductoProveedor(Producto grupo, Proveedor item) : base(grupo, item) {}
        
        // Metodos
        public override string ToString()
        {
            string grupo = Grupo == null
                ? "Sin datos de Proveedor"
                : $"Proveedor: {Grupo.Nombre}";
            return $"{grupo}\nProducto {Item}";
        }
    }
}
