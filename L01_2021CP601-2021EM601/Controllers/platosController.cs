using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using L01_2021CP601_2021EM601.Models;
using Microsoft.EntityFrameworkCore;

namespace L01_2021CP601_2021EM601.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class platosController : ControllerBase
    {

        private readonly restauranteDBContext _platosContexto;

        public platosController(restauranteDBContext platosContexto)
        {
            _platosContexto = platosContexto;


        }
    }
}
