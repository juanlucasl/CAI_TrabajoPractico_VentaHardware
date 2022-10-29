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

        /// <summary>
        /// Recibe una lista de opciones para mostrar al usuario y le pide que ingrese un numero. Devuelve el numero ingresado.
        /// </summary>
        /// <param name="opciones">Opciones a mostrar</param>
        /// <returns type="int">La opcion que ingreso el usuario.</returns>
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
