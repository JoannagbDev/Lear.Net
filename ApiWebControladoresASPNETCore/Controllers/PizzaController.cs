/* ADICIÖN DE UN CONTROLADOR DE PIZZA: 
    El controlador es una clase que maneja las solicitudes HTTP y genera respuestas HTTP para la aplicación. 
    En este caso, el controlador PizzaController maneja las solicitudes HTTP para las pizzas. 
    El controlador se encarga de la lógica de la aplicación, como recuperar, crear, actualizar y eliminar pizzas. 
    El controlador se comunica con el modelo de datos (Pizza) para realizar operaciones de CRUD (Crear, Leer, Actualizar, Eliminar) en las pizzas. */

using JGBPizza.Models; // Importa el espacio de nombres JGBPizza.Models
using JGBPizza.Services; // Importa el espacio de nombres JGBPizza.Services
using Microsoft.AspNetCore.Mvc; // Importa el espacio de nombres Microsoft.AspNetCore.Mvc

namespace JGBPizza.Controllers; // Define el espacio de nombres para los controladores 

[ApiController] // Atributo para indicar que la clase es un controlador de API
[Route("[Controller]")] // Atributo para especificar la ruta base para las solicitudes HTTP
public class PizzaController : ControllerBase // Clase base para los controladores de API 
{
    public PizzaController() // Constructor de la clase PizzaController
    {
    }

    // OBTENCION DE TODAS LAS PIZZAS	
    [HttpGet] // Atributo para indicar que el método maneja solicitudes HTTP GET
    public ActionResult<List<Pizza>> GetAll() => PizzaService.GetAll();
    /* Está acción: 
        - Responde solo al verbo HTPP GET.
        - Devuelve una instancia ActionResult de tipo List<Piza>. 
          El tipo ActionResult en la clase base para todos los resultados de acción en ASP:NET Core.
        - Consulta el servicio en busca de todas las pizzas u devuelve los datos cuto Content-Type es application/json. */

    //////////////////////////////////
    ///OBTENCIÓN DE UNA ÚNICA PIZZA 
    /* Se puede implementar otra acción GET que requiera un párametro id.
        - Se puede usar el atributo integrado [Http("´{id}")] */
    [HttpGet("{id}")]
    public ActionResult<Pizza> Get(int id)
    {
        var pizza = PizzaService.Get(id);
        if (pizza is null)
            return NotFound();
        return pizza;
    }

    //////////////////////////////////
    ///CREACIÓN DE UNA NUEVA PIZZA  
    /* Se puede implementar una acción POST que requiera un parámetro de tipo Pizza.
        - Se puede usar el atributo integrado [HttpPost] 
        - ASP.NET Core convierte automáticamente el cuerpo de la solicitud en un objeto Pizza. */
    [HttpPost]
    public IActionResult Create(Pizza pizza)
    {
        PizzaService.Add(pizza);
        return CreatedAtAction(nameof(Get), new { id = pizza.Id }, pizza);
    }
    /* Está acción: 
        - Responde solo al verbo HTTP POST.
        - Devuelve un resultado de tipo IActionResult.
        - Agrega una nueva pizza al servicio y devuelve un resultado 201 Created con la ubicación de la nueva pizza en la cabecera de respuesta. */

    ////////////////////////////
    ///ACTUALIZACIÓN DE UNA PIZZA
    /* La modificación de una pizza toma el parámetro id y un objeto Pizza.
        - Se puede usar el atributo integrado [HttpPut("{id}")]
        - ASP.NET Core convierte automáticamente el cuerpo de la solicitud en un objeto Pizza. */
    [HttpPut("{id}")]
    public IActionResult Update(int id, Pizza pizza)
    {
        if (id != pizza.Id)
            return BadRequest();
        var existingPizza = PizzaService.Get(id);
        if (existingPizza is null)
            return NotFound();

        PizzaService.Update(pizza);

        return NoContent();
        
    }
    /* Está acción: 
        - Responde solo al verbo HTTP PUT.
        - Devuelve un resultado de tipo IActionResult.
        - Actualiza una pizza existente en el servicio y devuelve un resultado 204 la pizza se ha actualizado
        400 BadReques (No encontrado). */

    ////////////////////////////
    /// ELIMINACIÓN DE UNA PIZZA
    /* La eliminación de una pizza toma el parámetro id.
        - Se puede usar el atributo integrado [HttpDelete("{id}")]
        - ASP.NET Core convierte automáticamente el cuerpo de la solicitud en un objeto Pizza. */
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var pizza = PizzaService.Get(id);
        if (pizza is null)
            return NotFound();
        
        PizzaService.Delete(id);
        return NoContent();
    }
    /* Está acción: 
        - Responde solo al verbo HTTP DELETE.
        - Devuelve un resultado de tipo IActionResult.
        - Elimina una pizza existente en el servicio y devuelve un resultado 204 la pizza se ha eliminado
        400 BadReques (No encontrado). */
}