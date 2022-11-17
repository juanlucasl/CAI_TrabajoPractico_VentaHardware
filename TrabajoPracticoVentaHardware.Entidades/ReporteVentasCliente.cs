using System;
using System.Collections.Generic;

namespace TrabajoPracticoVentaHardware.Entidades
{
    /// <summary>Objeto dentro de la Lista de un Reporte de Ventas por Cliente.</summary>
    public class ReporteVentasCliente : Reporte<List<VentaProductoHelper>, Cliente>
    {
        public ReporteVentasCliente(List<VentaProductoHelper> item, Cliente grupo) : base(item, grupo) {}

        public override string ToString()
        {
            return $"Cliente: {Grupo.NombreCompleto}\n" +
                   $"Ventas:\n" +
                   $"{string.Join("\n", Item)}";
        }
    }
}
