using System;

namespace TrabajoPracticoVentaHardware.Entidades
{
    public class Venta
    {
        // Constructor
        public Venta() {}

        public Venta(int idCliente, int idProducto, int cantidad)
        {
            _idCliente = idCliente;
            _idProducto = idProducto;
            _cantidad = cantidad;
            _fechaAlta = DateTime.Now;
        }

        // Atributos
        private int _id;
        private int _idCliente;
        private int _idProducto;
        private int _cantidad;
        private DateTime _fechaAlta;

        // Propiedades
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public int IdCliente
        {
            get { return _idCliente; }
            set { _idCliente = value; }
        }

        public int IdProducto
        {
            get { return _idProducto; }
            set { _idProducto = value; }
        }

        public int Cantidad
        {
            get { return _cantidad; }
            set { _cantidad = value; }
        }

        public DateTime FechaAlta
        {
            get { return _fechaAlta; }
            set { _fechaAlta = value; }
        }
    }
}
