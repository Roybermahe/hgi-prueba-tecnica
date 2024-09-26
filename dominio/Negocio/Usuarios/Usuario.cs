using Dominio.Base;

namespace Dominio.Negocio.Usuarios;

public class Usuario: Entity<int>
{
    public Usuario() {}

    public Usuario(int identificacion, string nombre, string apellido, string direccion, string telefono, string email)
    {
        Identificacion = identificacion;
        Nombre = nombre;
        Apellido = apellido;
        Telefono = telefono;
        Email = email;
        Direccion = direccion;
    }
    
    public int Identificacion { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Telefono { get; set; }
    public string Email { get; set; }
    public string Direccion { get; set; }
}