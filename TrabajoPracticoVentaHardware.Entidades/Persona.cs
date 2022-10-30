namespace TrabajoPracticoVentaHardware.Entidades
{
    public abstract class Persona
    {
        // Atributos
        private readonly int _id;
        private string _nombre;
        private string _apellido;
        private string _direccion;
        private long _telefono;
        private string _mail;

        // Propiedades
        protected int Id
        {
            get { return _id; }
        }

        protected string Nombre
        {
            get { return _nombre; }
        }

        protected string Apellido
        {
            get { return _apellido; }
        }

        protected string Direccion
        {
            get { return _direccion; }
        }

        protected long Telefono
        {
            get { return _telefono; }
        }

        protected string Mail
        {
            get { return _mail; }
        }
    }
}
