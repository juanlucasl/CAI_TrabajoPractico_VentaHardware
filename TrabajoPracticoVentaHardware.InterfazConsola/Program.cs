﻿using System;
using System.Collections.Generic;
using System.Linq;
using TrabajoPracticoVentaHardware.Entidades;
using TrabajoPracticoVentaHardware.Servicio;

namespace TrabajoPracticoVentaHardware.InterfazConsola
{
    static class Program
    {
        private static ClienteServicio _clienteServicio;

        static void Main(string[] args)
        {
            _clienteServicio = new ClienteServicio();

            int opcionMenu;

            do
            {
                MenuHelper.MostrarMenu(MenuHelper.OpcionesMenuPrincipal);
                opcionMenu = InputHelper.PedirNumeroNatural("Ingresar una opcion:");

                switch (opcionMenu)
                {
                    case 1: // Submenu de clientes
                    {
                        MenuClientes();
                        break;
                    }

                    case 2: // Submenu de productos
                    {
                        MenuProductos();
                        break;
                    }

                    case 9: // Acerca de
                    {
                        MostrarAcercaDe();
                        break;
                    }

                    case 0: // Salir del programa
                    {
                        Console.WriteLine("Salir del programa");
                        break;
                    }

                    default: // Opcion invalida
                    {
                        InputHelper.PedirContinuacion($"La opcion {opcionMenu} no es valida.");
                        break;
                    }
                }
            } while (opcionMenu != 0);
        }

        /// <summary>Muestra el menu de clientes.</summary>
        private static void MenuClientes()
        {
            int opcionMenu;

            do
            {
                MenuHelper.MostrarMenu(MenuHelper.OpcionesMenuCliente);
                opcionMenu = InputHelper.PedirNumeroNatural("Ingresar una opcion:");

                switch (opcionMenu)
                {
                    case 1: // Consultar clientes
                    {
                        MostrarClientes();
                        break;
                    }

                    case 2: // Alta de cliente
                    {
                        AltaCliente();
                        break;
                    }

                    case 0: // Volver al Menu principal.
                    {
                        break;
                    }

                    default: // Opcion invalida
                    {
                        InputHelper.PedirContinuacion($"La opcion {opcionMenu} no es valida.");
                        break;
                    }
                }
            } while (opcionMenu != 0);
        }

        /// <summary>Muestra en consola un listado de todos los clientes correspondientes al TP.</summary>
        private static void MostrarClientes()
        {
            try
            {
                List<Cliente> clientes = _clienteServicio.ObtenerClientes();

                if (clientes == null || !clientes.Any())
                {
                    InputHelper.PedirContinuacion("No hay clientes para mostrar.");
                    return;
                }

                Console.WriteLine("Listado de clientes:\n");
                foreach (Cliente cliente in clientes) Console.WriteLine($"{cliente}\n");
            }
            catch (Exception e)
            {
                Console.WriteLine("Ocurrio un error consultar los clientes. Vuelva a intentar en unos minutos.");
            }

            Console.WriteLine();
            InputHelper.PedirContinuacion();
        }

        /// <summary>
        /// Solicita informacion para dar de alta a un nuevo cliente y envia la peticion de alta al servicio.
        /// </summary>
        private static void AltaCliente()
        {
            try
            {
                string nombre = InputHelper.PedirString("Ingresar nombre del cliente:", true);
                string apellido = InputHelper.PedirString("Ingresar apellido del cliente:");
                string direccion = InputHelper.PedirString("Ingresar direccion del cliente:");
                long telefono = InputHelper.PedirNumeroTelefonico();
                string mail = InputHelper.PedirString("Ingresar email del cliente:");

                Cliente cliente = new Cliente(nombre, apellido, direccion, telefono, mail);

                _clienteServicio.InsertarCliente(cliente);
                InputHelper.PedirContinuacion($"Cliente {cliente.Nombre} ingresado con exito");
            }
            catch (OperationCanceledException operationCanceledException) {
                InputHelper.PedirContinuacion(operationCanceledException.Message);
            }
            catch (Exception e)
            {
                InputHelper.PedirContinuacion($"Ocurrio un error al dar de alta al cliente: {e.Message}");
            }
        }

        /// <summary>Muestra el menu de productos.</summary>
        private static void MenuProductos()
        {
            int opcionMenu;

            do
            {
                MenuHelper.MostrarMenu(MenuHelper.OpcionesMenuProducto);
                opcionMenu = InputHelper.PedirNumeroNatural("Ingresar una opcion:");

                switch (opcionMenu)
                {
                    case 0: // Volver al Menu principal.
                    {
                        break;
                    }

                    default: // Opcion invalida
                    {
                        InputHelper.PedirContinuacion($"La opcion {opcionMenu} no es valida.");
                        break;
                    }
                }
            } while (opcionMenu != 0);
        }

        private static void MostrarAcercaDe()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Trabajo Practico Venta de Hardware\n");
            Console.WriteLine("Facu P.");
            Console.WriteLine("Fran B.");
            Console.WriteLine("Juan L.");
            Console.ResetColor();
            InputHelper.PedirContinuacion();
        }
    }
}
