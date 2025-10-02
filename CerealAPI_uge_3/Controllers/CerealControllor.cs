using CerealAPI_uge_3.Interface;
using CerealAPI_uge_3.Models;
using CerealAPI_uge_3.Repostitory;
using Microsoft.AspNetCore.Mvc;


namespace CerealAPI_uge_3.Controllers
{
    [Route("api/[controller]")]
    [Microsoft.AspNetCore.Mvc.ApiController]
    public class CerealControllor: Controller
    {
        private readonly ICerealRepository cerealrepository;

        public CerealControllor(ICerealRepository cereal)
        {
            this.cerealrepository = cereal;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Cereal>))]
        public IActionResult GetCereal()
        {
            var cereals = cerealrepository.GetCereals();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else {
                return Ok(cereals);
            }
        }

        [HttpGet("/CerealId{CerealId}")]
        [ProducesResponseType(200, Type = typeof(Cereal))]
        [ProducesResponseType(400)]
        public IActionResult getCerealbyId(int id)
        {
            
            var cereals = cerealrepository.GetCerealById(id);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                return Ok(cereals);
            }
        }

        [HttpGet("/sugar{sugar}")]
        [ProducesResponseType(200, Type = typeof(Cereal))]
        [ProducesResponseType(400)]
        public IActionResult getCerealbysugar(int sugar)
        {

            var cereals = cerealrepository.getCerealbySugars(sugar);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                return Ok(cereals);
            }
        }

        [HttpGet("/brand{brand}")]
        [ProducesResponseType(200, Type = typeof(Cereal))]
        [ProducesResponseType(400)]
        public IActionResult getCerealbyBrand(string brand)
        {

            var cereals = cerealrepository.getCerealByBrand(brand);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                return Ok(cereals);
            }
        }

        [HttpDelete("{pokeId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeletePokemon(int cerealId)
        {
            if (!cerealrepository.cerealExists(cerealId))
            {
                return NotFound();
            }

            var cerealToDelte = cerealrepository.GetCerealById(cerealId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);



            if (!cerealrepository.deleteCerealByCereal(cerealToDelte))
            {
                ModelState.AddModelError("", "Something went wrong deleting owner");
            }

            return NoContent();
        }
    }
}
