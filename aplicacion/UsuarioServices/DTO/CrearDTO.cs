using System.ComponentModel.DataAnnotations;
using aplicacion.Base;
using Dominio.Negocio.Usuarios;

namespace Aplicacion.UsuarioServices.DTO;

public class CrearDTO
{
    [Required(ErrorMessage = "El campo Identificación es requerido")]
    [Range(1000000, 99999999999, ErrorMessage = "El valor debe ser mayor a cero.")]
    public int Identificacion { get; set; }
    
    [Required(ErrorMessage = "El campo Nombre es requerido")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 100 caracteres")]
    public string Nombre { get; set; }
    
    [Required(ErrorMessage = "El campo Apellido es requerido")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "El Apellido debe tener entre 3 y 100 caracteres")]
    public string Apellido { get; set; }
    
    [Required(ErrorMessage = "El campo Email es requerido")]
    [EmailAddress(ErrorMessage = "El Email debe contener un @ y un \".\" en el dominio.")]
    public string Email { get; set; }
    
    [Required(ErrorMessage = "El campo Telefono es requerido")]
    [StringLength(10, MinimumLength = 10, ErrorMessage = "El Telefono debe tener 10 caracteres")]
    public string Telefono { get; set; }
    
    [Required(ErrorMessage = "El campo Direccion es requerido")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "La Direccion debe tener almenos de 3 a 50 caracteres")]
    public string Direccion { get; set; }

    public Usuario Map()
    {
        var usuario = new Usuario();
        usuario.Identificacion = Identificacion;
        usuario.Nombre = Nombre;
        usuario.Apellido = Apellido;
        usuario.Email = Email;
        usuario.Telefono = Telefono;
        usuario.Direccion = Direccion;
        return usuario;
    }
}