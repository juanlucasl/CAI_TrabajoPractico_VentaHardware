using System;

namespace TrabajoPracticoVentaHardware.InterfazConsola
{
    /// <summary>Clase helper para armado de menues.</summary>
    internal static class MenuHelper
    {
        internal static readonly string[] OpcionesMenuPrincipal = {
            "Hardware Springfield - Venta de hardware\n",
            "9- Acerca de",
            "0- Salir del programa"
        };

        /// <summary>Muestra una lista de opciones en la consola.</summary>
        /// <param name="opciones">Opciones a mostrar.</param>
        internal static void MostrarMenu(string[] opciones)
        {
            Console.Clear();

            foreach (string opcion in opciones)
            {
                Console.WriteLine(opcion);
            }
        }
    }
}
