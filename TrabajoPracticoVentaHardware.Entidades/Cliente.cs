using System;

namespace TrabajoPracticoVentaHardware.Entidades
{
    public class Cliente : Persona
    {
        // Constructor
        public Cliente() : base() {}

        public Cliente(string nombre, string apellido, string direccion, long telefono, string mail) : base(nombre, apellido, direccion, telefono, mail)
        {
            _fechaAlta = DateTime.Now;
            _activo = true;
        }

        // Atributos
        private DateTime _fechaAlta;
        private bool _activo;

        // Propiedades

        public DateTime FechaAlta
        {
            get { return _fechaAlta; }
            set { _fechaAlta = value; }
        }

        public bool Activo
        {
            get { return _activo; }
            set { _activo = value; }
        }
    }
}
