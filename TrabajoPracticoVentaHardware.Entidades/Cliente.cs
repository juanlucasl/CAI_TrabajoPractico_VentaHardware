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

        // Metodos
        public override string ToString()
        {
            string apellido = string.IsNullOrWhiteSpace(Apellido) ? "" : $"{Apellido}, ";

            return $"{Id}) {apellido}{Nombre}\n" +
                   $"Telefono: {PropiedadDisplay(Telefono.ToString())}\n" +
                   $"Email: {PropiedadDisplay(Email)}\n" +
                   $"Direccion: {PropiedadDisplay(Direccion)}";
        }

        /// <summary>Devuelve "N/A" si un string es vacio, null o "0". De lo contrario devuelve el string.</summary>
        /// <param name="propiedad">Propiedad a mostrar.</param>
        /// <returns>String recibido o "N/A".</returns>
        private string PropiedadDisplay(string propiedad)
        {
            return (string.IsNullOrWhiteSpace(propiedad) || propiedad == "0") ? "N/A" : propiedad;
        }
    }
}
