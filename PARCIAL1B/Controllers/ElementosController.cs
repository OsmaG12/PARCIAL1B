using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PARCIAL1B.Model;

namespace PARCIAL1B.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ElementosController : ControllerBase
    {

        private readonly PContex _pContex;

        public ElementosController(PContex pContexto)
        {
            _pContex = pContexto;
        }

        //Leer Tablas

        [HttpGet]
        [Route("GetAll")]

        public IActionResult Get()
        {
            List<Elementos> ListadoElementos = (from p in _pContex.elementos
                                          select p).ToList();

            if (ListadoElementos.Count() == 0)
            {
                return NotFound();
            }

            return Ok(ListadoElementos);
        }

        //agregar

        [HttpGet]
        [Route("AddElementos")]

        public IActionResult GuardarElementos([FromBody] Elementos elementosAregar)
        {
            try
            {
                _pContex.elementos.Add(elementosAregar);
                _pContex.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Modificar 
        [HttpPut]
        [Route("ActualizarElementos/{id}")]
        public IActionResult ActualizarElementos(int id, [FromBody] Elementos elementosModificar)
        {
            Elementos? elementoActual = (from e in _pContex.elementos
                                         where e.ElementoID == id
                                         select e).FirstOrDefault();
            if (elementoActual == null)
            {
                return NotFound();
            }

            elementoActual.EmpresaID = elementosModificar.EmpresaID;
            elementoActual.Elemento = elementosModificar.Elemento;
            elementoActual.CantidadMinima = elementosModificar.CantidadMinima;
            elementoActual.UnidadMedida = elementosModificar.UnidadMedida;
            elementoActual.Costo = elementosModificar.Costo;
            elementoActual.Estado = elementosModificar.Estado;

            _pContex.Entry(elementoActual).State = EntityState.Modified;
            _pContex.SaveChanges();

            return Ok(elementosModificar);
        }


        //eleminar

        [HttpDelete]
        [Route("eliminar/{id}")]

        public IActionResult EliminarElemento(int id)
        {
            Elementos elementos = (from e in _pContex.elementos
                               where e.ElementoID == id
                               select e).FirstOrDefault();

            if (elementos == null)
                return NotFound();
            
            _pContex.elementos.Attach(elementos);
            _pContex.elementos.Remove(elementos);
            _pContex.SaveChanges();
            return Ok (elementos);

        }







    }
}
