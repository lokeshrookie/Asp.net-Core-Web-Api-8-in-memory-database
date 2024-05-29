using ContosoPizza.Models;

namespace ContosoPizza.Services
{
    public static class PizzaService
    {
        static List<Pizza> Pizzas { get; set; }
        static int nextId = 3;

        // Constructor
        static PizzaService()
        {
            Pizzas = new List<Pizza>()
            {
                new Pizza()
                {
                    Id = 1, 
                    Name = "Classic Italian",
                    IsGlutenFree = false
                },
                new Pizza()
                {
                    Id = 2,
                    Name = "Veggie",
                    IsGlutenFree = true
                }
            };
        }

        //Get All
        public static List<Pizza> GetAll()
        {

            return Pizzas;
        }

        //Get by Id
        public static Pizza? Get(int id)
        {
            return Pizzas.FirstOrDefault(x => x.Id == id);
        }
        
        // Add pizza
        public static void Add(Pizza pizza)
        {
            pizza.Id = nextId++;
            Pizzas.Add(pizza);
        }


        //Delete
        public static void Delete(int id)
        {
            Pizza item = Pizzas.FirstOrDefault(x => x.Id == id);
            if(item is null)
            {
                return;
            }
            Pizzas.Remove(item);
        }

        //Update
        public static void Update(int id,  Pizza pizza)
        {
            //// Get the pizza using id, 
            //Pizza item = Pizzas.Find(x => x.Id == id);
            //// update  the properties of pizza,
            //item.Name = pizza.Name;
            //item.IsGlutenFree = pizza.IsGlutenFree;

            //or

            // find the index of pizza you want to update, 
            // replace old one with new one.
            var index = Pizzas.FindIndex(x => x.Id == pizza.Id);
            if(index == -1)
            {
                return;
            }
            Pizzas[index] = pizza;
        }

    }
}
