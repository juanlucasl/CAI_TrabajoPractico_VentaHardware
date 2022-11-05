using System;

namespace TrabajoPracticoVentaHardware.Entidades
{
    public class Producto
    {
        // Constructor
        public Producto() {}

        public Producto(int idCategoria, string nombre, double precio, int stock)
        {
            _idCategoria = idCategoria;
            _nombre = nombre ?? throw new ArgumentNullException(nameof(nombre));
            _fechaAlta = DateTime.Now;
            _precio = precio;
            _stock = stock;
        }

        // Atributos
        private int _id;
        private int _idCategoria;
        private string _nombre;
        private DateTime _fechaAlta;
        private double _precio;
        private int _stock;

        // Propiedades
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public int IdCategoria
        {
            get { return _idCategoria; }
            set { _idCategoria = value; }
        }

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public DateTime FechaAlta
        {
            get { return _fechaAlta; }
            set { _fechaAlta = value; }
        }

        public double Precio
        {
            get { return _precio; }
            set { _precio = value; }
        }

        public int Stock
        {
            get { return _stock; }
            set { _stock = value; }
        }
    }
}
