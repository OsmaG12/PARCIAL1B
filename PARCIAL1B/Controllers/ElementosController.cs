using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        ///agregar

        [HttpGet]
        [Route("Add")]

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


        //eleminar

        [HttpDelete]
        [Route("eliminar/{id}")]

        public IActionResult EliminarEquipo(int id)
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
