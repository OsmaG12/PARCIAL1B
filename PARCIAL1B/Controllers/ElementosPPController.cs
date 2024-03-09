using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PARCIAL1B.Model;

namespace PARCIAL1B.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ElementosPPController : ControllerBase
    {
        private readonly PContex _pContex;

        public ElementosPPController(PContex pContexto)
        {
            _pContex = pContexto;
        }


        [HttpGet]
        [Route("GetAll")]

        public IActionResult Get()
        {
            List<ElementosPorPlato> ListadoElementosPP = (from p in _pContex.elementosPP
                                                          select p).ToList();

            if (ListadoElementosPP.Count() == 0)
            {
                return NotFound();
            }

            return Ok(ListadoElementosPP);
        }

        //agregar un registros 

        [HttpGet]
        [Route("AddElementosPP")]

        public IActionResult GuardarElementosPP([FromBody] ElementosPorPlato elementoAgregar)
        {
            try
            {
                _pContex.elementosPP.Add(elementoAgregar);
                _pContex.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Modificar un registro
        [HttpPut]
        [Route("ActualizarElementosPP/{id}")]
        public IActionResult ActualizarElementosPP(int id, [FromBody] ElementosPorPlato elementosPPModificar)
        {
            ElementosPorPlato? elementoPPActual = (from e in _pContex.elementosPP
                                                   where e.ElementoPorPlatoID == id
                                                   select e).FirstOrDefault();
            if (elementoPPActual == null)
            {
                return NotFound();
            }

            elementoPPActual.ElementoPorPlatoID = elementoPPActual.ElementoPorPlatoID;
            elementoPPActual.EmpresaID = elementoPPActual.EmpresaID;
            elementoPPActual.PlatoID = elementoPPActual.PlatoID;
            elementoPPActual.ElementoID = elementoPPActual.ElementoID;
            elementoPPActual.Cantidad = elementoPPActual.Cantidad;
            elementoPPActual.Estado = elementoPPActual.Estado;



            _pContex.Entry(elementoPPActual).State = EntityState.Modified;
            _pContex.SaveChanges();

            return Ok(elementosPPModificar);
        }

        // eliminar 

        [HttpDelete]
        [Route("eliminar/{id}")]

        public IActionResult EliminarElementoPP(int id)
        {
            ElementosPorPlato elementosPP = (from ee in _pContex.elementosPP
                                             where ee.ElementoPorPlatoID == id
                                             select ee).FirstOrDefault();

            if (elementosPP == null)
                return NotFound();

            _pContex.elementosPP.Attach(elementosPP);
            _pContex.elementosPP.Remove(elementosPP);
            _pContex.SaveChanges();
            return Ok(elementosPP);

        }

    }
}
