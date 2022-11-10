using System;

namespace TrabajoPracticoVentaHardware.Entidades
{
    public class Proveedor
    {
        // Constructor
        public Proveedor()
        {
        }

        public Proveedor(int idProducto, string nombre)
        {
            _idProducto = idProducto;
            _nombre = nombre;
            _fechaAlta = DateTime.Now;
        }

        // Atributos
        private int _id;
        private int _idProducto;
        private string _nombre;
        private DateTime _fechaAlta;
        private DateTime? _fechaBaja;

        // Propiedades
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public int IdProducto
        {
            get { return _idProducto; }
            set { _idProducto = value; }
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

        public DateTime? FechaBaja
        {
            get { return _fechaBaja; }
            set { _fechaBaja = value; }
        }

        // Metodos
        public override string ToString()
        {
            return $"{_id}) {_nombre}";
        }
    }
}
