using System;
using System.Linq;
using TrabajoPracticoVentaHardware.Entidades;

namespace TrabajoPracticoVentaHardware.InterfazConsola
{
    /// <summary>Clase helper para pedido de inputs.</summary>
    internal static class InputHelper
    {
        /// <summary>
        /// Solicita al usuario que ingrese un numero natural del cero al nueve. Una vez que el usuario ingreso lo
        /// pedido, devuelve el valor. Devuelve cero si el usuario cancela la accion.
        /// </summary>
        /// <param name="mensaje">
        /// Mensaje para mostrarle al usuario antes de que ingrese el numero (default "Ingresar una opcion:")
        /// </param>
        /// <returns>El numero que ingreso el usuario, o cero si el usuario cancelo la accion.</returns>
        internal static int PedirOpcionMenu(string mensaje = "Ingresar una opcion:")
        {
            int opcionMenu;

            try
            {
                opcionMenu = (int)PedirNumeroEntero(mensaje, 0, 9, true);
            }
            catch (Exception)
            {
                return 0;
            }

            return opcionMenu;
        }

        /// <summary>
        /// Solicita al usuario que ingrese un numero telefonico. Una vez que el usuario ingreso lo pedido, devuelve el
        /// valor.
        /// </summary>
        /// <param name="mensaje">
        /// Mensaje para mostrarle al usuario antes de que ingrese el numero (default "Ingresar un numero telefonico
        /// (solo numeros, sin caracacteres especiales):")
        /// </param>
        /// <param name="obligatorio">Flag que indica si se debe rechazar al numero ingresado si es cero.</param>
        /// <returns>El numero que ingreso el usuario</returns>
        internal static long PedirNumeroTelefonico(
            string mensaje = "Ingresar un numero telefonico (solo numeros, sin caracacteres especiales):",
            bool obligatorio = false
        )
        {
            // El estandar E.164 permite un maximo de hasta 15 digitos para numeros telefonicos.
            const long rangoMaximo = 999999999999999;
            const long rangoMinimo = 1000;

            long numeroTelefonico = PedirNumeroEntero(mensaje, rangoMinimo, rangoMaximo, obligatorio);

            return numeroTelefonico;
        }

        /// <summary>
        /// Solicita al usuario que ingrese un codigo de Categoria. Una vez que el usuario ingreso lo pedido, devuelve
        /// el valor. Opcionalmente recibe un mensaje para mostrar al usuario.
        /// </summary>
        /// <param name="mensaje">
        /// Mensaje para mostrarle al usuario antes de que ingrese el numero (default "Ingresar un codigo de
        /// categoria:")
        /// </param>
        /// <param name="obligatorio">Flag que indica si se debe rechazar al numero ingresado si es cero.</param>
        /// <returns>El numero que ingreso el usuario</returns>
        internal static Categoria PedirCategoria(
            string mensaje = "Ingresar codigo de categoria:",
            bool obligatorio = false
        )
        {
            Categoria categoria = (Categoria)PedirNumeroNatural(mensaje, max: ObtenerIndiceEnumMasAlto(typeof(Categoria)), obligatorio: obligatorio);
            return categoria;
        }

        /// <summary>
        /// Solicita al usuario que ingrese un numero natural. Una vez que el usuario ingreso lo pedido, devuelve el
        /// valor. Opcionalmente recibe un mensaje para mostrar al usuario, un numero minimo y un numero maximo.
        /// </summary>
        /// <param name="mensaje">
        /// Mensaje para mostrarle al usuario antes de que ingrese el numero (default "Ingresar un numero:")
        /// </param>
        /// <param name="min">Valor minimo para el numero que el usuario puede ingresar.</param>
        /// <param name="max">Valor maximo para el numero que el usuario puede ingresar.</param>
        /// <param name="obligatorio">Flag que indica si se debe rechazar al numero ingresado si es cero.</param>
        /// <returns>El numero que ingreso el usuario</returns>
        internal static int PedirNumeroNatural(
            string mensaje = "Ingresar un numero:",
            int min = 0,
            int max = int.MaxValue,
            bool obligatorio = false
        )
        {
            int numeroEntero = (int)PedirNumeroEntero(mensaje, min, max, obligatorio);
            return numeroEntero;
        }

        /// <summary>
        /// Solicita al usuario que ingrese un numero entero. Una vez que el usuario ingreso lo pedido, devuelve el
        /// valor. Opcionalmente recibe un mensaje para mostrar al usuario, un numero minimo y un numero maximo.
        /// </summary>
        /// <param name="mensaje">
        /// Mensaje para mostrarle al usuario antes de que ingrese el numero (default "Ingresar un numero:")
        /// </param>
        /// <param name="min">Valor minimo para el numero que el usuario puede ingresar.</param>
        /// <param name="max">Valor maximo para el numero que el usuario puede ingresar.</param>
        /// <param name="obligatorio">Flag que indica si se debe rechazar al numero ingresado si es cero.</param>
        /// <returns>El numero que ingreso el usuario</returns>
        internal static long PedirNumeroEntero(
            string mensaje = "Ingresar un numero:",
            long min = long.MinValue,
            long max = long.MaxValue,
            bool obligatorio = false
        )
        {
            long numeroEntero;
            string input;

            Console.WriteLine(mensaje);
            while (!long.TryParse(input = Console.ReadLine(), out numeroEntero) || numeroEntero < min || numeroEntero > max)
            {
                CancelarSiEsC(input);
                if (!obligatorio && string.IsNullOrWhiteSpace(input)) return numeroEntero;
                Console.WriteLine("El numero ingresado no es valido. Ingresar un numero distinto:");
            }

            return numeroEntero;
        }

        /// <summary>
        /// Solicita al usuario que ingrese un numero real. Una vez que el usuario ingreso lo pedido, devuelve el
        /// valor. Opcionalmente recibe un mensaje para mostrar al usuario, un numero minimo y un numero maximo.
        /// </summary>
        /// <param name="mensaje">
        /// Mensaje para mostrarle al usuario antes de que ingrese el numero (default "Ingresar un numero:")
        /// </param>
        /// <param name="min">Valor minimo para el numero que el usuario puede ingresar.</param>
        /// <param name="max">Valor maximo para el numero que el usuario puede ingresar.</param>
        /// <param name="obligatorio">Flag que indica si se debe rechazar al numero ingresado si es cero.</param>
        /// <returns>El numero que ingreso el usuario</returns>
        internal static double PedirNumeroReal(
            string mensaje = "Ingresar un numero:",
            double min = double.MinValue,
            double max = double.MaxValue,
            bool obligatorio = false
        )
        {
            double numeroReal;
            string input;

            Console.WriteLine(mensaje);
            while (!double.TryParse(input = Console.ReadLine(), out numeroReal) || numeroReal < min || numeroReal > max)
            {
                CancelarSiEsC(input);
                if (!obligatorio && string.IsNullOrWhiteSpace(input)) return numeroReal;
                Console.WriteLine("El numero ingresado no es valido. Ingresar un numero distinto:");
            }

            return numeroReal;
        }

        /// <summary> Solicita al usuario que ingrese texto.</summary>
        /// <param name="mensaje">
        /// Mensaje para mostrarle al usuario antes de que ingrese el text (default "Ingresar texto:")
        /// </param>
        /// <param name="obligatorio">
        /// Flag booleano que indica si se debe rechazar al texto ingresado si esta vacio (default false).
        /// </param>
        /// <returns type="string">El texto que ingreso el usuario</returns>
        internal static string PedirString(string mensaje = "Ingresar texto:", bool obligatorio = false)
        {
            Console.WriteLine(mensaje);
            string input = Console.ReadLine();
            CancelarSiEsC(input);

            while (obligatorio && string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("El texto ingresado no puede estar vacio. Ingresar un texto distinto:");
                input = Console.ReadLine();
            }

            return input;
        }

        /// <summary>Pide que presione una tecla para continuar.</summary>
        /// <param name="mensaje">Mensaje para mostrar al usuario.</param>
        internal static void PedirContinuacion(string mensaje = "")
        {
            if (!string.IsNullOrWhiteSpace(mensaje)) Console.WriteLine(mensaje);
            Console.WriteLine("Presionar una tecla para continuar");
            Console.ReadKey();
        }

        /// <summary>Devuelve el valor mas alto posible de un enum.</summary>
        /// <param name="enumEvaluado">Enum a evaluar.</param>
        /// <returns>Valor mas alto posible del enum evaluado.</returns>
        internal static int ObtenerIndiceEnumMasAlto(Type enumEvaluado)
        {
            return Enum.GetValues(enumEvaluado).Cast<int>().Max();
        }

        /// <summary>Recibe un string y, si es igual a "c", lanza una OperationCanceledException.</summary>
        /// <param name="input">String a comparar.</param>
        /// <exception cref="OperationCanceledException">Si el string que se recibio es igual a "c".</exception>
        private static void CancelarSiEsC(string input)
        {
            if (input == "c") throw new OperationCanceledException("Accion cancelada.");
        }
    }
}
