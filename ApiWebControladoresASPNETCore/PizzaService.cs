using JGBPizza.Models; // Importa el espacio de nombres JGBPizza.Models

namespace JGBPizza.Services; // Define el espacio de nombres para el servicio de pizzas

public static class PizzaService
{
    // Lista estática de pizzas
    static List<Pizza> Pizzas { get; }
    
    // Variable estática para el próximo Id
    static int nextId = 3;
    
    // Constructor estático para inicializar la lista de pizzas
    static PizzaService()
    {
        Pizzas = new List<Pizza>
        {
            new Pizza { Id = 1, Name = "Margherita", Description = "Tomato, mozzarella, and basil", Price = 5.99M, IsGlutenFree = false },
            new Pizza { Id = 2, Name = "Pepperoni", Description = "Pepperoni and mozzarella cheese", Price = 7.99M, IsGlutenFree = false },
            new Pizza { Id = 3, Name = "Hawaiian", Description = "Ham, pineapple, and mozzarella cheese", Price = 11.99M, IsGlutenFree = false }
        };
    }
    
    // Método para obtener todas las pizzas
    public static List<Pizza> GetAll() => Pizzas;
    
    // Método para obtener una pizza por Id
    public static Pizza Get(int id)
    {
        // Busca la pizza con el Id especificado en la lista de pizzas
        var pizza = Pizzas.FirstOrDefault(p => p.Id == id);
        
        // Si no se encuentra la pizza, lanza una excepción
        if (pizza == null)
        {
            throw new KeyNotFoundException($"Pizza with Id {id} not found.");
        }
        
        // Devuelve la pizza encontrada
        return pizza;
    }
    
    // Método para agregar una nueva pizza
    public static void Add(Pizza pizza)
    {
        pizza.Id = nextId++; // Asigna un nuevo Id a la pizza
        Pizzas.Add(pizza); // Agrega la pizza a la lista
    }

    // Método para eliminar una pizza por Id
    public static void Delete(int id)
    {
        var pizza = Get(id); // Obtiene la pizza por Id
        if (pizza is null) return; // Si la pizza no existe, retorna
        Pizzas.Remove(pizza); // Elimina la pizza de la lista
    }
    
    // Método para actualizar una pizza existente
    public static void Update(Pizza pizza)
    {
        var index = Pizzas.FindIndex(p => p.Id == pizza.Id); // Encuentra el índice de la pizza en la lista
        if (index == -1) return; // Si la pizza no existe, retorna
        Pizzas[index] = pizza; // Actualiza la pizza en la lista
    }
}