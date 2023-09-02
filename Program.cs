using System.Text;
using projeto.Models;
using Projeto.Models;

var historicopizza = new List<Pizza>();
var historicopedido = new List<string>();

int opcao = 1;

while (opcao != 0){
    Console.WriteLine("Bem-Vindo ao Projeto de Pizzaria");
    Console.WriteLine("ESCOLHA UMA OPÇÃO: ");
    Console.WriteLine("1 - Adicionar Pizza ");
    Console.WriteLine("2 - Listar Pizza ");
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

        foreach(Pizza item in historicopizza){
            Console.WriteLine("Nome: " + item.Nome);
            Console.WriteLine("Ingrediente: " + item.Ingredientes);
            Console.WriteLine("Preço: " + item.Preco);
        }
            break;
        case 3:
            Console.WriteLine("Criar Novo Pedido");
            Console.WriteLine("Quem é o Cliente?");
            var nomecliente = Console.ReadLine();
            Console.WriteLine("Qual é o Telefone do Cliente");
            var telefone = int.Parse(Console.ReadLine());

            var cliente = new Cliente ();
            cliente.NomeCliente = nomecliente;
            cliente.Telefone = telefone;

            Console.WriteLine("Escolha uma pizza para adicionar: ");
            foreach(Pizza item in historicopizza) {
                Console.WriteLine("Nome: " + item.Nome);
            }
            var pedido = Console.ReadLine();
  
            Console.WriteLine("Deseja acrescentar mais uma pizza: 1 - SIM | 2 - NÃO");
            var escolha = int.Parse(Console.ReadLine());


            
         break;
        case 0:
            Console.WriteLine("Encerrando.");
        return; 
    }
}