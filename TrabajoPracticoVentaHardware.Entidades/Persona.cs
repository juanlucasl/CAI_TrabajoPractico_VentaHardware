using System;

namespace TrabajoPracticoVentaHardware.Entidades
{
    public abstract class Persona
    {
        // Constructor
        protected Persona() {}

        protected Persona(string nombre, string apellido, string direccion, long telefono, string mail)
        {
            _nombre = nombre ?? throw new ArgumentNullException(nameof(nombre));
            _apellido = apellido ?? throw new ArgumentNullException(nameof(apellido));
            _direccion = direccion ?? throw new ArgumentNullException(nameof(direccion));
            _telefono = telefono;
            _mail = mail ?? throw new ArgumentNullException(nameof(mail));
        }

        // Atributos
        private int _id;
        private string _nombre;
        private string _apellido;
        private string _direccion;
        private long _telefono;
        private string _mail;

        // Propiedades
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public string Apellido
        {
            get { return _apellido; }
            set { _apellido = value; }
        }

        public string Direccion
        {
            get { return _direccion; }
            set { _direccion = value; }
        }

        public long Telefono
        {
            get { return _telefono; }
            set { _telefono = value; }
        }

        public string Email
        {
            get { return _mail; }
            set { _mail = value; }
        }
    }
}
