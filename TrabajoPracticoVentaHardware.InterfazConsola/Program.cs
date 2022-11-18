using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using TrabajoPracticoVentaHardware.Entidades;
using TrabajoPracticoVentaHardware.Entidades.Excepciones;
using TrabajoPracticoVentaHardware.Servicio;

namespace TrabajoPracticoVentaHardware.InterfazConsola
{
    static class Program
    {
        private static ClienteServicio _clienteServicio;
        private static ProductoServicio _productoServicio;
        private static VentaServicio _ventaServicio;
        private static ProveedorServicio _proveedorServicio;
        private static ReporteServicio _reporteServicio;

        static void Main()
        {
            _clienteServicio = new ClienteServicio();
            _productoServicio = new ProductoServicio();
            _ventaServicio = new VentaServicio();
            _proveedorServicio = new ProveedorServicio();
            _reporteServicio = new ReporteServicio();

            int opcionMenu;

            do
            {
                MenuHelper.MostrarMenu(MenuHelper.OpcionesMenuPrincipal);
                opcionMenu = InputHelper.PedirOpcionMenu();

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

                    case 3: // Submenu de ventas
                    {
                        MenuVentas();
                        break;
                    }

                    case 4: // Submenu de proveedores
                    {
                        MenuProveedores();
                        break;
                    }

                    case 5: // Submenu de reportes
                    {
                        MenuReportes();
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
                opcionMenu = InputHelper.PedirOpcionMenu();

                switch (opcionMenu)
                {
                    case 1: // Consultar clientes
                    {
                        MostrarClientes();
                        break;
                    }

                    case 2: // Consultar cliente por Id
                    {
                        MostrarClientePorId();
                        break;
                    }

                    case 3: // Alta de cliente
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
            catch (Exception)
            {
                Console.WriteLine("Ocurrio un error al consultar los clientes. Vuelva a intentar en unos minutos.");
            }

            Console.WriteLine();
            InputHelper.PedirContinuacion();
        }

        /// <summary>Solicita al usuario un Id de Cliente y muestra el Cliente correspondiente.</summary>
        private static void MostrarClientePorId()
        {
            Console.WriteLine("(Ingresar 'c' para cancelar)");
            try
            {
                int idCliente = InputHelper.PedirNumeroNatural("Ingresar Id del Cliente:");
                Cliente cliente = _clienteServicio.ObtenerClientePorId(idCliente);

                if (cliente == null)
                {
                    InputHelper.PedirContinuacion($"No existe un cliente con Id {idCliente}.");
                    return;
                }

                Console.WriteLine(cliente);
            }
            catch (AccionCanceladaException accionCanceladaException)
            {
                Console.WriteLine(accionCanceladaException.Message);
            }
            catch (Exception)
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
            Console.WriteLine("(Ingresar 'c' para cancelar)");
            try
            {
                string nombre = InputHelper.PedirString("Ingresar nombre del cliente:", true);
                string apellido = InputHelper.PedirString("Ingresar apellido del cliente:");
                string direccion = InputHelper.PedirString("Ingresar direccion del cliente:");
                long telefono = InputHelper.PedirNumeroTelefonico();
                string email = InputHelper.PedirString("Ingresar email del cliente:");

                Cliente cliente = new Cliente(nombre, apellido, direccion, telefono, email);

                _clienteServicio.InsertarCliente(cliente);
                InputHelper.PedirContinuacion($"Cliente {cliente.NombreCompleto} ingresado con exito");
            }
            catch (AccionCanceladaException operationCanceledException)
            {
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
                opcionMenu = InputHelper.PedirOpcionMenu();

                switch (opcionMenu)
                {
                    case 1: // Consultar Productos
                    {
                        MostrarProductos();
                        break;
                    }

                    case 2: // Consultar Producto por Id
                    {
                        MostrarProductoPorId();
                        break;
                    }

                    case 3: // Alta de producto
                    {
                        AltaProducto();
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

        /// <summary>Muestra en consola un listado de todos los productos correspondientes al TP.</summary>
        private static void MostrarProductos()
        {
            try
            {
                List<Producto> productos = _productoServicio.ObtenerProductos();

                if (productos == null || !productos.Any())
                {
                    InputHelper.PedirContinuacion("No hay productos disponibles.");
                    return;
                }

                Console.WriteLine("Listado de productos:\n");
                foreach (Producto producto in productos) Console.WriteLine($"{producto}\n");
            }
            catch (Exception)
            {
                Console.WriteLine("Ocurrio un error consultar los productos. Vuelva a intentar en unos minutos.");
            }

            Console.WriteLine();
            InputHelper.PedirContinuacion();
        }

        /// <summary>Solicita al usuario un Id de Producto y muestra el Producto correspondiente.</summary>
        private static void MostrarProductoPorId()
        {
            Console.WriteLine("(Ingresar 'c' para cancelar)");
            try
            {
                int idProducto = InputHelper.PedirNumeroNatural("Ingresar Id del Producto:");
                Producto producto = _productoServicio.ObtenerProductoPorId(idProducto);

                if (producto == null)
                {
                    InputHelper.PedirContinuacion($"No existe un producto con Id {idProducto}.");
                    return;
                }

                Console.WriteLine(producto);
            }
            catch (AccionCanceladaException accionCanceladaException)
            {
                Console.WriteLine(accionCanceladaException.Message);
            }
            catch (Exception)
            {
                Console.WriteLine("Ocurrio un error consultar los productos. Vuelva a intentar en unos minutos.");
            }

            Console.WriteLine();
            InputHelper.PedirContinuacion();
        }

        /// <summary>
        /// Solicita informacion para dar de alta a un nuevo producto y envia la peticion de alta al servicio.
        /// </summary>
        private static void AltaProducto()
        {
            Console.WriteLine("(Ingresar 'c' para cancelar)");
            try
            {
                string nombre = InputHelper.PedirString("Ingresar nombre del producto:", true);
                Categoria idCategoria = InputHelper.PedirCategoria();
                double precio = InputHelper.PedirNumeroReal(
                    "Ingresar precio del producto (se redondeara a dos decimales):",
                    max: double.Parse(ConfigurationManager.AppSettings["PRODUCTO_PRECIO_MAXIMO"])
                );
                int stock = InputHelper.PedirNumeroNatural(
                    "Ingresar stock del producto",
                    max: int.Parse(ConfigurationManager.AppSettings["PRODUCTO_STOCK_MAXIMO"])
                );

                Producto producto = new Producto(idCategoria, nombre, precio, stock);

                _productoServicio.InsertarProducto(producto);
                InputHelper.PedirContinuacion($"Producto {producto.Nombre} ({producto.IdCategoria.ToString()}) ingresado con exito");
            }
            catch (AccionCanceladaException operationCanceledException)
            {
                InputHelper.PedirContinuacion(operationCanceledException.Message);
            }
            catch (Exception e)
            {
                InputHelper.PedirContinuacion($"Ocurrio un error al dar de alta al producto: {e.Message}");
            }
        }

        /// <summary>Muestra el menu de ventas.</summary>
        private static void MenuVentas()
        {
            int opcionMenu;

            do
            {
                MenuHelper.MostrarMenu(MenuHelper.OpcionesMenuVenta);
                opcionMenu = InputHelper.PedirOpcionMenu();

                switch (opcionMenu)
                {
                    case 1: // Consultar Ventas
                    {
                        MostrarVentas();
                        break;
                    }

                    case 2: // Alta de venta
                    {
                        AltaVenta();
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

        /// <summary>Muestra en consola un listado de todas las ventas correspondientes al TP.</summary>
        private static void MostrarVentas()
        {
            try
            {
                List<Venta> ventas = _ventaServicio.ObtenerVentas();

                if (ventas == null || !ventas.Any())
                {
                    InputHelper.PedirContinuacion("No hay ventas disponibles.");
                    return;
                }

                Console.WriteLine("Listado de ventas:\n");
                foreach (Venta venta in ventas) Console.WriteLine($"{venta}\n");
            }
            catch (Exception)
            {
                Console.WriteLine("Ocurrio un error consultar las ventas. Vuelva a intentar en unos minutos.");
            }

            Console.WriteLine();
            InputHelper.PedirContinuacion();
        }

        /// <summary>
        /// Solicita informacion para dar de alta a una nueva venta y envia la peticion de alta al servicio.
        /// </summary>
        private static void AltaVenta()
        {
            Console.WriteLine("(Ingresar 'c' para cancelar)");
            try
            {
                int idCliente = InputHelper.PedirNumeroNatural("Ingresar Id del cliente que fue participe de la venta:");
                int idProducto = InputHelper.PedirNumeroNatural("Ingresar Id del producto que se vendio al cliente:");
                int cantidad = InputHelper.PedirNumeroNatural(
                    "Ingresar cantidad de producto que se vendio al cliente:",
                    max: int.Parse(ConfigurationManager.AppSettings["PRODUCTO_STOCK_MAXIMO"])
                );

                Venta venta = new Venta(idCliente, idProducto, cantidad);

                _ventaServicio.InsertarVenta(venta);
                InputHelper.PedirContinuacion($"Venta ingresada con exito");
            }
            catch (AccionCanceladaException accionCanceladaException)
            {
                InputHelper.PedirContinuacion(accionCanceladaException.Message);
            }
            catch (DatosIngresadosInvalidosException datosIngresadosInvalidosException)
            {
                InputHelper.PedirContinuacion(datosIngresadosInvalidosException.Message);
            }
            catch (Exception e)
            {
                InputHelper.PedirContinuacion($"Ocurrio un error al dar de alta a la venta: {e.Message}");
            }
        }

        /// <summary>Muestra el menu de proveedores.</summary>
        private static void MenuProveedores()
        {
            int opcionMenu;

            do
            {
                MenuHelper.MostrarMenu(MenuHelper.OpcionesMenuProveedor);
                opcionMenu = InputHelper.PedirOpcionMenu();

                switch (opcionMenu)
                {
                    case 1: // Consultar Proveedores
                    {
                        MostrarProveedores();
                        break;
                    }

                    case 2: // Consultar Proveedor por Id de Producto
                    {
                        MostrarProveedorPorIdProducto();
                        break;
                    }

                    case 3: // Alta de Proveedor
                    {
                        AltaProveedor();
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

        /// <summary>Muestra en consola un listado de todos los proveedores correspondientes al TP.</summary>
        private static void MostrarProveedores()
        {
            try
            {
                List<Proveedor> proveedores = _proveedorServicio.ObtenerProveedores();

                if (proveedores == null || !proveedores.Any())
                {
                    InputHelper.PedirContinuacion("No hay proveedores disponibles.");
                    return;
                }

                Console.WriteLine("Listado de proveedores:\n");
                foreach (Proveedor proveedor in proveedores) Console.WriteLine($"{proveedor}\n");
            }
            catch (Exception)
            {
                Console.WriteLine("Ocurrio un error consultar los proveedores. Vuelva a intentar en unos minutos.");
            }

            Console.WriteLine();
            InputHelper.PedirContinuacion();
        }

        /// <summary>Solicita al usuario un Id de Producto y muestra el Producto correspondiente.</summary>
        private static void MostrarProveedorPorIdProducto()
        {
            Console.WriteLine("(Ingresar 'c' para cancelar)");
            try
            {
                int idProducto = InputHelper.PedirNumeroNatural("Ingresar Id del Producto:");
                Producto producto = _productoServicio.ObtenerProductoPorId(idProducto);

                if (producto == null)
                {
                    InputHelper.PedirContinuacion($"No existe un producto con Id {idProducto}.");
                    return;
                }

                Proveedor proveedor = _proveedorServicio.ObtenerProveedorPorProducto(idProducto);
                if (proveedor == null)
                {
                    InputHelper.PedirContinuacion($"No existe un proveedor para el Producto {producto.Nombre}.");
                    return;
                }

                Console.WriteLine(new ReporteProductoProveedor(producto, proveedor));
            }
            catch (AccionCanceladaException accionCanceladaException)
            {
                Console.WriteLine(accionCanceladaException.Message);
            }
            catch (Exception)
            {
                Console.WriteLine("Ocurrio un error consultar los productos. Vuelva a intentar en unos minutos.");
            }

            Console.WriteLine();
            InputHelper.PedirContinuacion();
        }

        /// <summary>
        /// Solicita informacion para dar de alta a un nuevo proveedor y envia la peticion de alta al servicio.
        /// </summary>
        private static void AltaProveedor()
        {
            Console.WriteLine("(Ingresar 'c' para cancelar)");
            try
            {
                string nombre = InputHelper.PedirString("Ingresar nombre del proveedor:", true);
                int idProducto = InputHelper.PedirNumeroNatural("Ingresar Id del producto que provee el proveedor:");

                Proveedor proveedor = new Proveedor(idProducto, nombre);

                _proveedorServicio.InsertarProveedor(proveedor);
                InputHelper.PedirContinuacion($"Proveedor {proveedor.Nombre} ingresado con exito");
            }
            catch (AccionCanceladaException accionCanceladaException)
            {
                InputHelper.PedirContinuacion(accionCanceladaException.Message);
            }
            catch (DatosIngresadosInvalidosException datosIngresadosInvalidosException)
            {
                InputHelper.PedirContinuacion(datosIngresadosInvalidosException.Message);
            }
            catch (Exception e)
            {
                InputHelper.PedirContinuacion($"Ocurrio un error al dar de alta al proveedor: {e.Message}");
            }
        }

        /// <summary>Muestra el menu de reportes.</summary>
        private static void MenuReportes()
        {
            int opcionMenu;

            do
            {
                MenuHelper.MostrarMenu(MenuHelper.OpcionesMenuReporte);
                opcionMenu = InputHelper.PedirOpcionMenu();

                switch (opcionMenu)
                {
                    case 0: // Volver al Menu principal.
                    {
                        break;
                    }

                    case 1: // Ver reporte de ventas por cliente
                    {
                        MostrarReporteVentasPorCliente();
                        break;
                    }

                    case 2: // Ver reporte de producto por proveedor
                    {
                        MostrarReporteProductoPorProveedor();
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

        /// <summary>
        /// Muestra en consola un reporte de todas las ventas correspondientes al TP, clasificadas en base al cliente
        /// que las realizo.
        /// </summary>
        private static void MostrarReporteVentasPorCliente()
        {
            try
            {
                List<ReporteVentasCliente> reporteVentasPorCliente = _reporteServicio.ObtenerReporteVentasPorCliente();

                if (reporteVentasPorCliente == null || !reporteVentasPorCliente.Any())
                {
                    InputHelper.PedirContinuacion("No hay datos para mostrar.");
                    return;
                }

                Console.WriteLine("Reporte de Ventas por cliente:\n");
                foreach (ReporteVentasCliente ventasCliente in reporteVentasPorCliente)
                    Console.WriteLine($"{ventasCliente}\n");
            }
            catch (Exception)
            {
                Console.WriteLine("Ocurrio un error al emitir el reporte de ventas por cliente. Vuelva a intentar en unos minutos.");
            }

            Console.WriteLine();
            InputHelper.PedirContinuacion();
        }

        /// <summary>
        /// Muestra en consola un reporte de todos los productos correspondientes al TP, clasificados en base al
        /// proveedor que los provee.
        /// </summary>
        private static void MostrarReporteProductoPorProveedor()
        {
            try
            {
                List<ReporteProductoProveedor> reporteProductoPorProveedor = _reporteServicio.ObtenerReporteProductoPorProveedor();

                if (reporteProductoPorProveedor == null || !reporteProductoPorProveedor.Any())
                {
                    InputHelper.PedirContinuacion("No hay datos para mostrar.");
                    return;
                }

                Console.WriteLine("Reporte de Producto por Proveedor:\n");
                foreach (ReporteProductoProveedor productoProveedor in reporteProductoPorProveedor)
                    Console.WriteLine($"{productoProveedor}\n");
            }
            catch (Exception)
            {
                Console.WriteLine("Ocurrio un error al emitir el reporte de producto por proveedor. Vuelva a intentar en unos minutos.");
            }

            Console.WriteLine();
            InputHelper.PedirContinuacion();
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
