using System;
using System.Globalization;

namespace TrabajoPracticoVentaHardware.InterfazConsola
{
    /// <summary>Clase helper para pedido de inputs.</summary>
    internal static class InputHelper
    {
        /// <summary>
        /// Solicita al usuario que ingrese un numero natural. Una vez que el usuario ingreso lo pedido, devuelve el
        /// valor. Opcionalmente recibe un mensaje para mostrar al usuario y un numero maximo. El minimo es siempre cero.
        /// </summary>
        /// <param name="mensaje">
        /// Mensaje para mostrarle al usuario antes de que ingrese el numero (default "Ingresar un numero natural")
        /// </param>
        /// <param name="max">Valor maximo para el numero que el usuario puede ingresar.</param>
        /// <returns>El numero que ingreso el usuario</returns>
        internal static int PedirNumeroNatural(string mensaje = "Ingresar un numero natural", int max = int.MaxValue)
        {
            double numeroReal;

            while (!EsInteger(numeroReal = PedirNumeroReal(mensaje, 0, max)))
            {
                Console.WriteLine("El numero ingresado no es valido. Ingresar un numero distinto:");
            }

            return (int)numeroReal;
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

            double numeroTelefonico;

            while (!EsInteger(numeroTelefonico = PedirNumeroReal(mensaje, rangoMinimo, rangoMaximo, obligatorio)))
            {
                Console.WriteLine("El numero ingresado no es valido. Ingresar un numero distinto:");
            }

            return (long)numeroTelefonico;
        }

        /// <summary>
        /// Solicita al usuario que ingrese un numero real. Una vez que el usuario ingreso lo pedido, devuelve el
        /// valor. Opcionalmente recibe un mensaje para mostrar al usuario, un numero minimo y un numero maximo.
        /// </summary>
        /// <param name="mensaje">
        /// Mensaje para mostrarle al usuario antes de que ingrese el numero (default "Ingresar un numero")
        /// </param>
        /// <param name="min">Valor minimo para el numero que el usuario puede ingresar.</param>
        /// <param name="max">Valor maximo para el numero que el usuario puede ingresar.</param>
        /// <param name="obligatorio">Flag que indica si se debe rechazar al numero ingresado si es cero.</param>
        /// <returns>El numero que ingreso el usuario</returns>
        internal static double PedirNumeroReal(
            string mensaje = "Ingresar un numero",
            double min = double.MinValue,
            double max = double.MaxValue,
            bool obligatorio = false
        )
        {
            double numeroReal;

            Console.WriteLine(mensaje);
            while (!double.TryParse(Console.ReadLine(), out numeroReal) || numeroReal < min || numeroReal > max)
            {
                if (!obligatorio && numeroReal == 0) return numeroReal;
                Console.WriteLine("El numero ingresado no es valido. Ingresar un numero distinto:");
            }

            return numeroReal;
        }

        /// <summary> Solicita al usuario que ingrese texto.</summary>
        /// <param name="mensaje">
        /// Mensaje para mostrarle al usuario antes de que ingrese el text (default "Ingresar texto")
        /// </param>
        /// <param name="obligatorio">
        /// Flag booleano que indica si se debe rechazar al texto ingresado si esta vacio (default false).
        /// </param>
        /// <returns type="string">El texto que ingreso el usuario</returns>
        internal static string PedirString(string mensaje = "Ingresar texto", bool obligatorio = false)
        {
            Console.WriteLine(mensaje);
            string inputString = Console.ReadLine();

            while (obligatorio && string.IsNullOrWhiteSpace(inputString))
            {
                Console.WriteLine("El texto ingresado no puede estar vacio. Ingrese un texto distinto.");
                inputString = Console.ReadLine();
            }

            return inputString;
        }

        /// <summary>Pide que presione una tecla para continuar.</summary>
        /// <param name="mensaje">Mensaje para mostrar al usuario.</param>
        internal static void PedirContinuacion(string mensaje = "")
        {
            if (!string.IsNullOrWhiteSpace(mensaje)) Console.WriteLine(mensaje);
            Console.WriteLine("Presionar una tecla para continuar");
            Console.ReadKey();
        }

        /// <summary>Recibe un numero como parametro y verifica si se trata de un numero entero.</summary>
        /// <param name="numero">Numero a verificar.</param>
        /// <returns>true si el numero es entero. De lo contrario false.</returns>
        private static bool EsInteger(double numero)
        {
            return !numero.ToString(CultureInfo.InvariantCulture).Contains(".");
        }
    }
}
