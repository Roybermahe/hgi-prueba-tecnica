using aplicacion.Base;
using Aplicacion.UsuarioServices.DTO;

using Dominio.Contratos;
using Infraestructura.Repositorios;

namespace Aplicacion.UsuarioServices;

public class UsuarioServices(IUnitOfWork unitOfWork)
{
    public Response Crear(CrearDTO usuarioDto)
    {
        try
        {
            var usuario = usuarioDto.Map();
            var data = unitOfWork.UsuarioRepository.Add(usuario);
            var message = "Usuario creado correctamente";
            var codeResult = unitOfWork.Commit();
            if (codeResult == "23505")
                throw new Exception("No se pudo crear el usuario porque ya existe uno con la misma Identificación.");
            return new Response() { data = data, message = message, code = 200 };
        }
        catch (Exception e)
        {
            return new Response() { data = { }, message = e.Message, code = 400 };
        }
        finally
        {
            unitOfWork.Dispose();
        }
    }
    public Response Actualizar(int id, ActualizarDTO usuarioDto)
    {
        try
        {
           var usuario = unitOfWork.UsuarioRepository.Find(id);
           if(usuario == null) throw new Exception("No se encontro el usuario.");
           var usuarioUpdate = usuarioDto.Map(usuario);
           var data = unitOfWork.UsuarioRepository.Edit(usuarioUpdate);
           var message = "Usuario actualizado correctamente";
           var codeResult = unitOfWork.Commit();
           return new Response() { data = data, message = message, code = 200 };
        }
        catch (Exception e)
        {
            return new Response() { data = { }, message = e.Message, code = 400 };
        }
        finally
        {
            unitOfWork.Dispose();
        }
    }
    public Response ConsultarPaginado( int page, int pageSize, string? keyword = "")
    {
        try
        {
            var data = ((UsuarioRepository)unitOfWork.UsuarioRepository!)
                .ObtenerUsuariosPaginados( page, pageSize, keyword);
            return new Response() { data = data, message = "Se consultaron los datos correctamente" ,code = 200 };
        }
        catch (Exception e)
        {
            return new Response() { data = {}, message = "Ocurrio un problema consultado los datos", code = 400 };
        }
        finally
        {
            unitOfWork.Dispose();
        }
    }

    public Response Consultar(int id)
    {
        try
        {
            var data = unitOfWork.UsuarioRepository.Find(id);
            if (data == null) throw new Exception("No se encontro el usuario.");
            return new Response() { data = data, message = "Se consultaron los datos correctamente" ,code = 200 };
        }
        catch (Exception e)
        {
            return new Response() { data = {}, message = e.Message, code = 400 };
        }
        finally
        {
            unitOfWork.Dispose();
        } 
    }
    public Response Eliminar(int id)
    {
        try
        {
            var usuario = unitOfWork.UsuarioRepository.Find(id);
            if (usuario == null) throw new Exception("No se encontro el usuario.");
            unitOfWork.UsuarioRepository.Delete(usuario);
            unitOfWork.Commit();
            var message = "Fue borrado correctamente el usuario";
            return new Response() { data = { }, message = message, code = 200 };
        }
        catch (Exception e)
        {
            return new Response() { data = { }, message = e.Message, code = 400 };
        }
        finally
        {
            unitOfWork.Dispose();
        }
    }
}