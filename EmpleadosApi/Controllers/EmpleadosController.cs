using Microsoft.AspNetCore.Mvc;
using EmpleadosApi.Models;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmpleadosApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadosController : ControllerBase
    {
        //Hacemos una instancia del DB-Context
        private EmpleadosContext _context = new EmpleadosContext();
        // GET: api/<EmpleadosController>
        [HttpGet("GetAll")]
        public async Task<List<Usuario>> GetAll()
        {
            try
            {
                return await _context.Usuarios.ToListAsync();//Obtenemos una lista de todos los empleados
            }
            catch (Exception)
            {

                throw;
            }
        }

        // GET api/<EmpleadosController>/5
        [HttpGet("Get")]
        public async Task<Usuario> Get(int id)
        {
            var empleado = await _context.Usuarios.FirstOrDefaultAsync(c => c.Id == id);//Buscamos el empleado en base al id que nos pasan por parametros
            try
            {
                if(empleado == null) return null;//sino encontramos ningun empleado retornamos null

                //sino...

                return empleado;//retornamos el empleado encontrado
            }
            catch (Exception)
            {

                throw;
            }

        }

        // POST api/<EmpleadosController>
        [HttpPost("Create")]
        public async Task<bool> Create(Usuario usuario)
        {
            try
            {
                _context.Usuarios.Add(usuario);//Agregamos el nuevo carro o modelo que nos pasan por parametros.
                await _context.SaveChangesAsync();//Guardamos todos los cambios
                return true;//Retornamos verdadero en caso de que se haya agregado correctamente
            }
            catch (Exception ex)
            {
                return false;//Retornamos falso en caso de que no se haya creado
            }
        }

        // PUT api/<EmpleadosController>/5
        [HttpPut("Update")]
        public async Task<bool> Update(Usuario usuario)
        {
            try
            {
                _context.Usuarios.Update(usuario);//Actualizamos el empleado que nos pasan por parametros
                await _context.SaveChangesAsync();//Guardamos todos los cambios
                return true;//Retornamos verdadero en caso de que se haya actulizado correctamente
            }
            catch (Exception)
            {
                return false;//Retornamos falso en caso de que no se haya actualizado
            }
        }

        // DELETE api/<EmpleadosController>/5
        [HttpDelete("Delete")]
        public async Task<bool> Delete(int id)
        {
            try
            {
                var empleado = await _context.Usuarios.FirstOrDefaultAsync(c => c.Id == id);//Buscamos el empleado que queremos eliminar en base al id que nos pasan por parametros
                if (empleado != null)//si encontramos algun empleado entonces(si la variable car tiene algo o es diferente de null)...
                {
                    _context.Usuarios.Remove(empleado);//Eliminamos el empleado encontrado anteriormente
                    await _context.SaveChangesAsync();//Guardamos todos los cambios

                }
                return true;//Retornamos verdadero en caso de que se haya eliminado correctamente

            }
            catch (Exception)
            {
                return false;//Retornamos falso en caso de que no se haya eliminado
            }
        }
    }
}
