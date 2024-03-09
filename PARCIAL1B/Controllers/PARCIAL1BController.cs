using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PARCIAL1B.Model;
using Microsoft.EntityFrameworkCore;
using System.Security.AccessControl;

namespace PARCIAL1B.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PARCIAL1BController : ControllerBase
    {
        private readonly PContex _pContex;

        public PARCIAL1BController(PContex pContexto)
        {
            _pContex = pContexto;
        }

        [HttpGet]
        [Route("GetAll")]

        public IActionResult Get()
        {
            List<Platos> ListadoPlatos = ( from p in _pContex.platos
                                           select p).ToList();

            if (ListadoPlatos.Count() == 0) {
                return NotFound();
            }

            return Ok(ListadoPlatos);
        }

        //Crear para Platos
        [HttpPost]
        [Route("AddPlatos")]
        public IActionResult GuardarPlato([FromBody] Platos plato)
        {
            try
            {
                _pContex.platos.Add(plato);
                _pContex.SaveChanges();
                return Ok(plato);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        //Fin de crear para platos


    }
}
