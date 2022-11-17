using System;
using System.Globalization;

namespace TrabajoPracticoVentaHardware.Entidades
{
    public class Producto
    {
        // Constructor
        public Producto() {}

        public Producto(Categoria idCategoria, string nombre, double precio, int stock)
        {
            _idCategoria = idCategoria;
            _nombre = nombre ?? throw new ArgumentNullException(nameof(nombre));
            _fechaAlta = DateTime.Now;
            _precio = precio;
            _stock = stock;
        }

        // Atributos
        private int _id;
        private Categoria _idCategoria;
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

        public Categoria IdCategoria
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

        // Metodos
        public override string ToString()
        {
            return $"{_id}) {_nombre}\n" +
                   $"Categoria: {_idCategoria}\n" +
                   $"Precio: {_precio.ToString("C", CultureInfo.GetCultureInfo("es-AR"))}\n" +
                   $"Stock: {_stock}";
        }
    }
}
