using CerealAPI_uge_3.Interface;
using CerealAPI_uge_3.Models;
using Microsoft.AspNetCore.Authorization;
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

        [HttpGet("/CerealbyId{CerealId}")]
        [ProducesResponseType(200, Type = typeof(Cereal))]
        [ProducesResponseType(400)]
        public IActionResult getCerealbyId(int CerealId)
        {
            
            var cereals = cerealrepository.GetCerealById(CerealId);

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

        [HttpPost("/post{CerealId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult createCereal([FromBody] Cereal cerealCreate)
        {
            if(cerealCreate == null)
            {
                return BadRequest(ModelState);
            }

            bool cereal = cerealrepository.cerealExists(cerealCreate.Id);

            if(cereal)
            {
                cerealrepository.UpdateCereal(cerealCreate);
                return Ok("Cereal Successfully Updated");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (cerealCreate.Id != 0)
            {
                ModelState.AddModelError("", "Can't give id ");
                return StatusCode(500, ModelState);
            }
            cerealrepository.createCereal(cerealCreate);

            return Ok("Successfully created");
        }

        
        [HttpDelete("/delete{CerealId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteCereal(int cerealId)
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
