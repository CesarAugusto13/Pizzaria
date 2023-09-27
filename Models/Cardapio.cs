using projeto.Models;


namespace projeto.Models
{
    public class Cardapio
    {
        public List<Pizza> Pizzas { get; set; }

        public Cardapio()
        {
            Pizzas = new List<Pizza>();


        }

        public void Add(Pizza pizza)
        {
            Pizzas.Add(pizza);
        }
    }
}
