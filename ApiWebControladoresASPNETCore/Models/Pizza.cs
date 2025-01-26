
/* AlMACENAMIENTO DE DATOS DE PIZZA: 
    La clase MODEL (Pizza) es un modelo de datos que representa una pizza en la aplicación.
    El modelo de datos se utiliza para almacenar y manipular información  y pasar datos entre diferentes partes de la aplicación.
    En este caso, la clase Pizza tiene propiedades que representan los atributos de una pizza, como el nombre, la descripción, el precio y si es sin gluten.
    Ese almacén de datos será un servicio de almacenmamiento de caché en memoria local simple. En una aplicación se consideraría una base da datos, 
    como SQL Server, con Entity Framework Core para acceder a los datos. */

namespace JGBPizza.Models
{
    public class Pizza
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public bool IsGlutenFree { get; set; }
    }
}