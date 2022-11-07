namespace TrabajoPracticoVentaHardware.Entidades
{
    public class ResultadoTransaccion
    {
        // Atributos
        private bool _isOk;
        private int _id;
        private string _error;

        // Propiedades
        public bool IsOk
        {
            get { return _isOk; }
            set { _isOk = value; }
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Error
        {
            get { return _error; }
            set { _error = value; }
        }
    }
}
