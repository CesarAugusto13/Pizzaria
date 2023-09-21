namespace Projeto.Models;

using Projeto.Models;

public class Pedido {   
    public Cliente DadosCliente {get; set;} = new Cliente();

    public List<Pizza> Pizzas {get; set; } = new List<Pizza>();
} 
