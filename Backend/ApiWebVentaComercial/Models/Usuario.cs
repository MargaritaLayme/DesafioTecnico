namespace ApiWebVentaComercial.Models
{
    public class Usuario
    {
        public string idUsuario { get; set; }
        public string usuario { get; set; }
        public string pasword { get; set; }
        public string rol { get; set; }

    public static List<Usuario> DB()
        {

            List<Usuario> usuarios = new List<Usuario>
            {
                new Usuario
                {
                    idUsuario = "1",
                    usuario = "mceleste",
                    pasword = "123",
                    rol = "asesor"
                },
                new Usuario
                {
                    idUsuario = "2",
                    usuario = "jmamani",
                    pasword = "123",
                    rol = "asesor"
                },
                new Usuario
                {
                    idUsuario = "3",
                    usuario = "aquispe",
                    pasword = "123",
                    rol = "asesor"
                },
                new Usuario
                {
                    idUsuario = "4",
                    usuario = "jperez",
                    pasword = "123",
                    rol = "administrador"
                }
            };

            return usuarios;
        }
    }
}
