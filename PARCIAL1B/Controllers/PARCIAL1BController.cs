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
            List<Platos> ListadoPlatos = (from p in _pContex.platos
                                          select p).ToList();

            if (ListadoPlatos.Count() == 0)
            {
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

        //Modificar platos
        [HttpPut]
        [Route("ActualizarPlato/{id}")]
        public IActionResult ActualizarPlato(int id, [FromBody] Platos platoModificar)
        {
            Platos? platoActual = (from p in _pContex.platos
                                   where p.PlatoID == id
                                   select p).FirstOrDefault();
            if (platoActual == null)
            {
                return NotFound();
            }

            platoActual.PlatoID = platoModificar.PlatoID;
            platoActual.EmpresaID = platoModificar.EmpresaID;
            platoActual.GrupoID = platoModificar.GrupoID;
            platoActual.NombrePlato = platoModificar.NombrePlato;
            platoActual.DescripcionPlato = platoModificar.DescripcionPlato;
            platoActual.Precio = platoModificar.Precio;

            _pContex.Entry(platoActual).State = EntityState.Modified;
            _pContex.SaveChanges();

            return Ok(platoModificar);
        }
        //Fin de modificar platos

        //Borrar platos
        [HttpDelete]
        [Route("EliminarPlato/{id}")]
        public IActionResult EliminarPlato(int id)
        {
            Platos? plato = (from p in _pContex.platos
                             where p.PlatoID == id
                             select p).FirstOrDefault();
            if (plato == null)
            {
                return NotFound();
            }

            _pContex.platos.Attach(plato);
            _pContex.platos.Remove(plato);
            _pContex.SaveChanges();

            return Ok(plato);
            //Fin de borrar platos

        }
    }
}
