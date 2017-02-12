namespace DrinkServer.Controllers
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;
    using DrinkServer.Model;
    using DrinkServer.Services;
    using DrinkServer.Utils;

    [Route("api/[controller]")]
    public class DrinksController : Controller
    {
        private readonly DataService dataService;

        public DrinksController(DataService dataService)
        {
            Precond.IsNotNull(dataService);

            this.dataService = dataService;
        }

        // GET api/drinks?quantity=10
        [HttpGet]
        public IEnumerable<Drink> Get(int? quantity)
        {
            if (quantity != null)
            {
                return dataService.GetByQuantity(quantity.Value);
            }

            return dataService.GetAll();
        }

        // GET api/drinks/coke
        [HttpGet("{name}")]
        public IActionResult Get(string name)
        {
            var drink = dataService.GetByName(name);
            
            if (drink == null)
            {
                return StatusCode(404);
            }

            return Ok(drink);
        }

        // POST api/drinks
        [HttpPost]
        public IActionResult Post([FromBody] Drink drink)
        {
            if (drink?.IsValid() != true)
            {
                return ReportError(400, "Invalid format.");
            }
            if (dataService.Contains(drink.Name))
            {
                return ReportError(409, "Duplicate.");
            }
            
            dataService.AddOrUpdate(drink);
            return Ok(drink);
        }

        // PUT api/drinks/coke
        [HttpPut]
        public IActionResult Put([FromBody]Drink drink)
        {
            if (drink?.IsValid() != true)
            {
                return ReportError(400, "Invalid format.");
            }

            dataService.AddOrUpdate(drink);
            return Ok(drink);
        }

        // DELETE api/drinks/coke
        [HttpDelete("{name}")]
        public IActionResult Delete(string name)
        {
            bool deleted = dataService.Remove(name);

            if (!deleted)
            {
                return ReportError(410, "Item did not exist.");
            }

            // to play nicer with client API
            return Ok(new { Message= name });
        }

        private ObjectResult ReportError(int statusCode, string error)
        {
            var responseError = new ResponseError
            {
                ErrorCode = statusCode.ToString(),
                Message = error
            };

            return StatusCode(statusCode, responseError);
        }
    }
}
