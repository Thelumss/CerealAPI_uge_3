using CerealAPI_uge_3.Interface;
using CerealAPI_uge_3.Models;
using Microsoft.AspNetCore.Authentication.BearerToken;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Common;


namespace CerealAPI_uge_3.Controllers
{
    /*
     * the controller for Cereal and all of its end points
     */
    [Route("api/[controller]")]
    [Microsoft.AspNetCore.Mvc.ApiController]
    public class CerealControllor: Controller
    {
        private readonly ICerealRepository cerealrepository;

        public CerealControllor(ICerealRepository cereal)
        {
            this.cerealrepository = cereal;
        }
        /*
        * simple get request that gets all of the Cereals in the database 
        */
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


        /*
         * simple get request that get the cereal by its id
         */
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

        /*
         * simple get request that gets the cereal with a spicift amount of sugar in it
         */
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

        /*
         * a get request that get all of the cereal of that brand 
         */
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

        /*
         * post request to insert a new cereal into the database
         */
        [HttpPost("/post")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult createCereal([FromBody] Cereal cerealCreate)
        {
            //first check if cereal to creat is actuly contatins something
            if(cerealCreate == null)
            {
                return BadRequest(ModelState);
            }

            //her we find out if the cereal exist and then overwrite it with new data
            if(cerealrepository.cerealExists(cerealCreate.Id))
            {
                cerealrepository.UpdateCereal(cerealCreate);
                return Ok("Cereal Successfully Updated");
            }

            //check if the model is corect
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // see if the cereal has a id default it is set to 0 
            if (cerealCreate.Id != 0)
            {
                ModelState.AddModelError("", "Can't give id ");
                return StatusCode(500, ModelState);
            }

            //create the new cereal
            cerealrepository.createCereal(cerealCreate);

            return Ok("Successfully created");
        }

        /*
         * and deletes the cereal from the database with that id
         */
        [HttpDelete("/delete{CerealId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteCereal(int cerealId)
        {
            //first check if a cereal with that id exist
            if (!cerealrepository.cerealExists(cerealId))
            {
                return NotFound();
            }

            var cerealToDelte = cerealrepository.GetCerealById(cerealId);


            //her we delte the cereal if something goes wrong that is the error message
            if (!cerealrepository.deleteCerealByCereal(cerealToDelte))
            {
                ModelState.AddModelError("", "Something went wrong deleting Cereal");
            }

            return NoContent();
        }
    }
}
