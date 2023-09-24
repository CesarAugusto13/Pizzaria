namespace Projeto.Models;

using Projeto.Models;

public class Pedido {   
<<<<<<< HEAD
    public Cliente DadosCliente {get;set; } = new Cliente();
    public List<Pizza> Pizzas {get; set;} = new List<Pizza>();
    public string StatusPagamento {get; set;} 
    
    
    public float CalcularPreco(){
        float total = 0;
        foreach(Pizza item in Pizzas) {
                    
            total += item.Preco;
        }
        return total;
    }
    
    public float EfetuarPagamento(){

        
    }




}

=======
    public Cliente DadosCliente {get; set;} = new Cliente();

    public List<Pizza> Pizzas {get; set; } = new List<Pizza>();
} 
>>>>>>> bd3cfd8ccb2c0cc827390d14b7c9dd36e7c57e65
