using aplicacion.Base;
using Aplicacion.UsuarioServices;
using Aplicacion.UsuarioServices.DTO;
using Dominio.Contratos;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsuariosController(IUnitOfWork _unitOfWork) : ControllerBase
{
    [HttpPost]
    public ActionResult<IResponses> Post(CrearDTO crearDto)
    {
        var service = new UsuarioServices(_unitOfWork);
        var result = service.Crear(crearDto);
        return result.code == 200 ? Ok(result): BadRequest(result);
    }

    [HttpPut("{id}")]
    public ActionResult<IResponses> Put(int id, [FromBody] ActualizarDTO actualizarDto)
    {
        var service = new UsuarioServices(_unitOfWork);
        var result = service.Actualizar(id, actualizarDto);
        return result.code == 200 ? Ok(result): BadRequest(result);
    }
    
    [HttpGet("Paginado")]
    public ActionResult<IResponses> Get(int pageSize, int page, string? keyword)
    {
        var service = new UsuarioServices(_unitOfWork);
        var result = service.ConsultarPaginado(page, pageSize, keyword);
        return result.code == 200 ? Ok(result): BadRequest(result);
    }
    
    [HttpGet("{id}")]
    public ActionResult<IResponses> Get(int id)
    {
        var service = new UsuarioServices(_unitOfWork);
        var result = service.Consultar(id);
        return result.code == 200 ? Ok(result): BadRequest(result);
    }

    [HttpDelete("{id}")]
    public ActionResult<IResponses> Delete(int id)
    {
        var service = new UsuarioServices(_unitOfWork);
        var result = service.Eliminar(id);
        return result.code == 200 ? Ok(result): BadRequest(result);
    }
    
}