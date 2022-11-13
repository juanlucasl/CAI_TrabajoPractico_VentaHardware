using System;

namespace TrabajoPracticoVentaHardware.Entidades
{
    /// <summary>Objeto dentro de la Lista de un Reporte de {T} por {U}.</summary>
    public class Reporte<T, U>
        where T : class
        where U : class
    {
        // Constructor
        public Reporte(T item, U grupo)
        {
            _item = item ?? throw new ArgumentNullException(nameof(item));
            _grupo = grupo;
        }

        // Atributos
        private readonly T _item;
        private readonly U _grupo;

        // Metodos
        public override string ToString()
        {
            string grupo = _grupo == null
                ? $"No se encontraron datos de {TipoDisplay(typeof(U))}"
                : _grupo.ToString();
            return $"{grupo}\n{_item}";
        }

        /// <summary>Devuelve el nombre de un Tipo sin el namespace.</summary>
        /// <param name="tipo">Tipo a mostrar.</param>
        /// <returns>Tipo sin el namespace.</returns>
        private string TipoDisplay(Type tipo)
        {
            return tipo.ToString().Replace("TrabajoPracticoVentaHardware.Entidades.", "");
        }
    }
}
