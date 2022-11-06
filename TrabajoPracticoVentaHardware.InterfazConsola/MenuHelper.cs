using System;
using System.Configuration;

namespace TrabajoPracticoVentaHardware.InterfazConsola
{
    /// <summary>Clase helper para armado de menues.</summary>
    internal static class MenuHelper
    {
        internal static readonly string[] OpcionesMenuPrincipal = {
            $"{ConfigurationManager.AppSettings["TP_NAME"]}\n",
            "1) Menu de clientes",
            "2) Menu de productos",
            "9) Acerca de",
            "0) Salir del programa"
        };

        internal static readonly string[] OpcionesMenuCliente =
        {
            ConfigurationManager.AppSettings["TP_NAME"],
            "Menu de clientes\n",
            "1) Consultar clientes",
            "0) Salir del menu de clientes"
        };

        internal static readonly string[] OpcionesMenuProducto =
        {
            ConfigurationManager.AppSettings["TP_NAME"],
            "Menu de productos\n",
            "0) Salir del menu de productos"
        };

        internal static readonly string[] OpcionesMenuVenta =
        {
            ConfigurationManager.AppSettings["TP_NAME"],
            "Menu de ventas\n",
            "0) Salir del menu de ventas"
        };

        internal static readonly string[] OpcionesMenuProveedor =
        {
            ConfigurationManager.AppSettings["TP_NAME"],
            "Menu de proveedores\n",
            "0) Salir del menu de proveedores"
        };

        internal static readonly string[] OpcionesMenuReporte =
        {
            ConfigurationManager.AppSettings["TP_NAME"],
            "Menu de reportes\n",
            "0) Salir del menu de reportes"
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
            Console.WriteLine();
        }
    }
}
