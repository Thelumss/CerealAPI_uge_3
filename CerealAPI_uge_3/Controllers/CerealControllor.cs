using CerealAPI_uge_3.Interface;
using CerealAPI_uge_3.Models;
using Microsoft.AspNetCore.Mvc;


namespace CerealAPI_uge_3.Controllers
{
    [Route("api/[controller]")]
    [Microsoft.AspNetCore.Mvc.ApiController]
    public class CerealControllor: Controller
    {
        private readonly ICereal cereal;

        public CerealControllor(ICereal cereal)
        {
            this.cereal = cereal;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Cereal>))]
        public IActionResult GetCereal()
        {
            var cereals = cereal.GetCereals();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else {
                return Ok(cereals);
            }
        }
    }
}
