using ContosoPizza.Models;
using ContosoPizza.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContosoPizza.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PizzaController : ControllerBase
    {
        public PizzaController() { }

        // GET All Action
        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<Pizza>> GetPizzas()
        {
            return PizzaService.GetAll();
        }

        // GET By Id Action
        [HttpGet("Get/{id}")]
        public ActionResult<Pizza> Get(int id)
        {
            var pizza = PizzaService.Get(id);
            if(pizza == null)
            {
                return NotFound();
            }
            return pizza;
        }

        // POST Action
        [HttpPost("Create")]
        public IActionResult Create(Pizza pizza)
        {
            PizzaService.Add(pizza);
            return CreatedAtAction(nameof(Get), new { id = pizza.Id }, pizza);
        }

        // PUT Action
        [HttpPut("{id}")]
        public IActionResult Update(int id, Pizza pizza)
        {
            if (id != pizza.Id) return BadRequest();
            
            var existingPizza = PizzaService.Get(id);

            if(existingPizza == null)
            {
                return NotFound();
            }

            PizzaService.Update(id, pizza);
            return NoContent(); // return 204. means the pizza is updated.

        }

        // DELETE Action
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var pizza = PizzaService.Get(id);

            if (pizza == null) return NotFound();

            PizzaService.Delete(id);
            
            return NoContent(); // 204, means pizza is deleted.
        }
    }
}
