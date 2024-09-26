using System.ComponentModel.DataAnnotations;
using Dominio.Negocio.Usuarios;

namespace Aplicacion.UsuarioServices.DTO;

public class ActualizarDTO
{
    [Range(1000000, 99999999999, ErrorMessage = "El valor debe ser mayor a cero.")]
    public int? Identificacion { get; set; }
    
    [StringLength(100, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 100 caracteres")]
    public string? Nombre { get; set; }
    
    [StringLength(100, MinimumLength = 3, ErrorMessage = "El apellido debe tener entre 3 y 100 caracteres")]
    public string? Apellido { get; set; }
    
    [EmailAddress(ErrorMessage = "El Email debe contener un @ y un \".\" en el dominio.")]
    public string? Email { get; set; }
    
    [StringLength(10, MinimumLength = 10, ErrorMessage = "El telefono debe tener 10 caracteres")]
    public string? Telefono { get; set; }
 
    [StringLength(50, MinimumLength = 3, ErrorMessage = "La dirección debe tener almenos de 3 a 50 caracteres")]
    public string? Direccion { get; set; }

    public Usuario Map(Usuario usuario)
    {
        if (Identificacion != null)
        {
            usuario.Identificacion = Identificacion.Value;
        }

        if (Nombre != null)
        {
            usuario.Nombre = Nombre;
        }

        if (Apellido != null)
        {
            usuario.Apellido = Apellido;
        }

        if (Email != null)
        {
            usuario.Email = Email;
        }

        if (Telefono != null)
        {
            usuario.Telefono = Telefono;
        }

        if (Direccion != null)
        {
            usuario.Direccion = Direccion;
        }

        return usuario;
    }
}