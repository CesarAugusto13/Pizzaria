namespace Projeto.Models;

using Projeto.Models;

public class Pedido {   
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

