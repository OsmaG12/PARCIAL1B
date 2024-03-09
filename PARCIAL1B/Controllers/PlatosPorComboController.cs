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
            List<PlatosPorCombo> ListadoPlatosPC = (from pcp in _pContex.platosporcombo
                                                    select pcp).ToList();

            if (ListadoPlatosPC.Count() == 0)
            {
                return NotFound();
            }

            return Ok(ListadoPlatosPC);
        }
        //Fin de leer platos por combo

        //Crear para Platos por combo
        [HttpPost]
        [Route("AddPlatosPorCombo")]
        public IActionResult GuardarPlatoPorCombo([FromBody] PlatosPorCombo platopc)
        {
            try
            {
                _pContex.platosporcombo.Add(platopc);
                _pContex.SaveChanges();
                return Ok(platopc);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        //Fin de crear para platos por combo

        //Modificar platos
        [HttpPut]
        [Route("ActualizarPlatoPorCombo/{id}")]
        public IActionResult ActualizarPlatoPorCombo(int id, [FromBody] PlatosPorCombo platoPCModificar)
        {
            PlatosPorCombo? platoPCActual = (from pcp in _pContex.platosporcombo
                                             where pcp.PlatosPorComboID == id
                                             select pcp).FirstOrDefault();
            if (platoPCActual == null)
            {
                return NotFound();
            }

            platoPCActual.PlatosPorComboID = platoPCModificar.PlatosPorComboID;
            platoPCActual.EmpresaID = platoPCModificar.EmpresaID;
            platoPCActual.ComboID = platoPCModificar.ComboID;
            platoPCActual.PlatoID = platoPCModificar.PlatoID;
            platoPCActual.Estado = platoPCModificar.Estado;

            _pContex.Entry(platoPCActual).State = EntityState.Modified;
            _pContex.SaveChanges();

            return Ok(platoPCModificar);
        }
        //Fin de modificar platos

        //Borrar platos
        [HttpDelete]
        [Route("EliminarPlatoPorCombo/{id}")]
        public IActionResult EliminarPlatoPorCombo(int id)
        {
            PlatosPorCombo? platoPC = (from pcp in _pContex.platosporcombo
                             where pcp.PlatosPorComboID == id
                             select pcp).FirstOrDefault();
            if (platoPC == null)
            {
                return NotFound();
            }

            _pContex.platosporcombo.Attach(platoPC);
            _pContex.platosporcombo.Remove(platoPC);
            _pContex.SaveChanges();

            return Ok(platoPC);
            //Fin de borrar platos
        }
    }
}
