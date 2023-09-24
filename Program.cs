using System.Text;
<<<<<<< HEAD
=======

>>>>>>> bd3cfd8ccb2c0cc827390d14b7c9dd36e7c57e65
using Projeto.Models;

var historicopizza = new List<Pizza>();
var historicopedido = new List<Pedido>();

<<<<<<< HEAD
StatusPagamento = "Não";
=======
>>>>>>> bd3cfd8ccb2c0cc827390d14b7c9dd36e7c57e65

int opcao = 1;

while (opcao != 0){
    Console.WriteLine("Bem-Vindo ao Projeto de Pizzaria");
    Console.WriteLine("ESCOLHA UMA OPÇÃO: ");
    Console.WriteLine("1 - Adicionar Pizza ");
    Console.WriteLine("2 - Listar Pizza ");
    Console.WriteLine("3 - Realizar Pedidos");
    Console.WriteLine("4 - Consultar Pedidos");
    Console.WriteLine("0 - Encerrar ");

    Console.WriteLine("Digite sua opção ");
    opcao = int.Parse(Console.ReadLine());
    
    switch(opcao) {
        case 1: 
                Console.WriteLine("Adicionar uma pizza!");
                Console.WriteLine("Digite o nome da Pizza:");
                var nome = Console.ReadLine();
                Console.WriteLine("Digite os ingredientes da Pizza separados por vírgula:");
                var ingredientes = Console.ReadLine();
                Console.WriteLine("Digite o preço da Pizza (Formato 00,00):");
                var preco = float.Parse(Console.ReadLine());

                var pizza = new Pizza();
                pizza.Nome = nome;
                pizza.Ingredientes = ingredientes;
                pizza.Preco = preco;

                Console.WriteLine(pizza.Nome);
                Console.WriteLine(pizza.Ingredientes);
                Console.WriteLine(pizza.Preco);

                historicopizza.Add(pizza);
                Console.WriteLine(" PIZZA CRIADA COM SUCESSO!");
                break;
        case 2:
         Console.WriteLine("Listar as Pizzas!");
         Console.WriteLine("------------------------------------");

        foreach(Pizza item in historicopizza){
            Console.WriteLine("Nome: " + item.Nome);
            Console.WriteLine("Ingrediente: " + item.Ingredientes);
            Console.WriteLine("Preço: " + item.Preco);
            Console.WriteLine("------------------------------------");
        }
            break;
        case 3:
            Console.WriteLine("Criar Novo Pedido");
            var pedido = new Pedido();
            Console.WriteLine("Quem é o Cliente?");
            var nomecliente = Console.ReadLine();
            Console.WriteLine("Qual é o Telefone do Cliente");
            var telefone = int.Parse(Console.ReadLine());

            var cliente = new Cliente ();
            cliente.NomeCliente = nomecliente;
            cliente.Telefone = telefone;

<<<<<<< HEAD
            pedido.DadosCliente = cliente;
=======
            pedido.DadosCliente  = cliente;
>>>>>>> bd3cfd8ccb2c0cc827390d14b7c9dd36e7c57e65

            var escolha = 0;
            do{
                Console.WriteLine("Escolha uma pizza para adicionar: ");
                foreach(Pizza item in historicopizza) {
                    Console.WriteLine("Nome: " + item.Nome);
<<<<<<< HEAD
                    Console.WriteLine("Preço: " + item.Preco);
=======
                    Console.WriteLine("Preço" + item.Preco);
>>>>>>> bd3cfd8ccb2c0cc827390d14b7c9dd36e7c57e65
                }


                var nomeEscolhido = Console.ReadLine();

                foreach(Pizza item in historicopizza) {
                    if (item.Nome == nomeEscolhido) {
                        pedido.Pizzas.Add(item);
                        break;
                    }
                }

                
                Console.WriteLine("Deseja acrescentar mais uma pizza: 1 - SIM | 2 - NÃO");
                escolha = int.Parse(Console.ReadLine());
            } while (escolha == 1);
<<<<<<< HEAD

            historicopedido.Add(pedido);
            Console.WriteLine("Pedido Realizado");

            break;
        case 4:
            Console.WriteLine("Listar Pedidos!");
=======
            
            historicopedido.Add(pedido);

            Console.WriteLine("Pedido Realizado");
>>>>>>> bd3cfd8ccb2c0cc827390d14b7c9dd36e7c57e65

            

            foreach(Pedido item in historicopedido) {
                    
                Console.WriteLine("Cliente do Pedido: " + item.DadosCliente.NomeCliente);
                Console.WriteLine("Telefone do Cliente: " + item.DadosCliente.Telefone);
                Console.WriteLine("Total a pagar:R$"+ item.CalcularPreco());
                Console.WriteLine("Pizzas do Pedido: "+ item.Pizzas);
                
               }
                
         break;
        case 4:
            Console.WriteLine("Listar Pedido!");
            Console.WriteLine("Listar as Pizzas!");

            foreach(Pizza item in historicopizza){
            Console.WriteLine("Nome: " + item.Nome);
            Console.WriteLine("Ingrediente: " + item.Ingredientes);
            Console.WriteLine("Preço: " + item.Preco);
            }
            break;
        
        case 0:
            Console.WriteLine("Encerrando.");
        return; 
    }
}