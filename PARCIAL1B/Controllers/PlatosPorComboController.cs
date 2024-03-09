using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PARCIAL1B.Model;
using Microsoft.EntityFrameworkCore;
using System.Security.AccessControl;

namespace PARCIAL1B.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatosPorComboController : ControllerBase
    {
        private readonly PContex _pContex;

        public PlatosPorComboController(PContex pContexto)
        {
            _pContex = pContexto;
        }

        //Leer la tabla platos por combo
        [HttpGet]
        [Route("GetAll")]

        public IActionResult Get()
        {
            List<PlatosPorCombo> ListadoPlatosPC = (from pcp in _pContex.platosPC
                                          select pcp).ToList();

            if (ListadoPlatosPC.Count() == 0)
            {
                return NotFound();
            }

            return Ok(ListadoPlatosPC);
        }
        //Fin de leer platos por combo
    }
}
