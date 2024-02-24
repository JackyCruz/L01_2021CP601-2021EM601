using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using L01_2021CP601_2021EM601.Models;
using Microsoft.EntityFrameworkCore;

namespace L01_2021CP601_2021EM601.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class motoristasController : ControllerBase
    {

        private readonly restauranteDBContext _motoristasContexto;

        public motoristasController(restauranteDBContext motoristasContexto)
        {
            _motoristasContexto = motoristasContexto;


        }
        [HttpGet]
        [Route("Find/{filtro}")]

        public IActionResult FindByDescription(string filtro)
        {
            motoristas? motoristas = (from e in _motoristasContexto.motoristas
                                  where e.nombreMotorista.Contains(filtro)
                               select e).FirstOrDefault();

            if (motoristas == null)
            {
                return NotFound();
            }
            return Ok(motoristas);
        }
    }
}
