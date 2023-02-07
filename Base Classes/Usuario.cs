namespace Proyecto_Final_Coder2023.Models
{
    public class Usuario
    {
        private long id;
        private string nombre;
        private string apellido;
        private string username;
        private string contrasena;
        private string email;

        public long Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Username { get => username; set => username = value; }
        public string Contrasena { get => contrasena; set => contrasena = value; }
        public string Email { get => email; set => email = value; }
    }
}
