using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using L01_2021CP601_2021EM601.Models;
using Microsoft.EntityFrameworkCore;

namespace L01_2021CP601_2021EM601.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class pedidosController : ControllerBase
    {
        private readonly restauranteDBContext _pedidosContexto;

        public pedidosController(restauranteDBContext pedidosContexto)
        {
            _pedidosContexto = pedidosContexto;


        }
        [HttpGet]
        [Route("GetAll")]

        public IActionResult Get()
        {
            List<pedidos> listadoEquipo = (from e in _pedidosContexto.pedidos
                                           select e).ToList();
            if (listadoEquipo.Count() == 0)
            {
                return NotFound();
            }

            return Ok(listadoEquipo);
        }
        /// <summary>
        /// EndPoint que retorna los registros de una tabla filtrados por su ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetById/{id}")]
        public IActionResult Get(int id)
        {
            pedidos? pedidos = (from e in _pedidosContexto.pedidos
                               where e.pedidoId == id
                               select e).FirstOrDefault();
            if (pedidos == null)
            {
                return NotFound();
            }

            return Ok(pedidos);
        }

        /// <summary>
        /// EndPoint que retorna los registros de todos los equipos existentes 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Find/{filtro}")]

        public IActionResult FindByDescription(int id)
        {
            pedidos? equipo = (from e in _pedidosContexto.pedidos
                               where e.clienteId == id
                               select e).FirstOrDefault();

            if (equipo == null)
            {
                return NotFound();
            }
            return Ok(equipo);
        }

        [HttpPost]
        [Route("Add")]

        public IActionResult GuadarEquipo([FromBody] pedidos equipo)
        {

            try
            {

                _pedidosContexto.pedidos.Add(equipo);
                _pedidosContexto.SaveChanges();
                return Ok(equipo);


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }


        }
        [HttpPut]
        [Route("actualizar/{id}")]
        public IActionResult ActualizarEquipo(int id, [FromBody] pedidos pedidosModificar)
        {
            //Para actualizar un registro, se obtiene el registro original de la base de datos
            //al cual alteraremos alguna propiedad
            pedidos? pedidosActual = (from e in _pedidosContexto.pedidos
                                     where e.pedidoId== id
                                     select e).FirstOrDefault();

            //Verificamos que exista el registro segun su ID
            if (pedidosActual == null)
            { return NotFound(); }

            //Si se encuentra el registro, se alteran los campos modificables 
            pedidosActual.motoristaId = pedidosModificar.motoristaId;
            pedidosActual.clienteId = pedidosModificar.clienteId;
            pedidosActual.platoId = pedidosModificar.platoId;
            pedidosActual.cantidad = pedidosModificar.cantidad;
            pedidosActual.precio = pedidosModificar.precio;

            //Se marca el registro como modificado en el contexto
            //y se envia la modificacion a la base de datos

            _pedidosContexto.Entry(pedidosActual).State = EntityState.Modified;
            _pedidosContexto.SaveChanges();

            return Ok(pedidosModificar);
        }

        [HttpDelete]
        [Route("eliminar/{id}")]

        public IActionResult EliminarEquipo(int id)
        {
            pedidos? equipo = (from e in _pedidosContexto.pedidos
                               where e.pedidoId == id
                               select e).FirstOrDefault();

            if (equipo == null)
            {
                return NotFound();


                _pedidosContexto.pedidos.Attach(equipo);
                _pedidosContexto.pedidos.Remove(equipo);
                _pedidosContexto.SaveChanges();

            }
            return Ok(equipo);
        }
    }
}
