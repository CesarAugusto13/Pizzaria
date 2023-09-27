using System.Security.Cryptography;
using System.Text;
using projeto.Models;


//Lista de opções de pizzas
Cardapio cardapio = new Cardapio();

//Historico de pedidos
var historicopedido = new List<Pedido>();


string StatusPagamento = "Não";


string opcao = "1";

while (opcao != "0")
{
    Console.WriteLine("Bem-Vindo ao Projeto de Pizzaria");
    Console.WriteLine("ESCOLHA UMA OPÇÃO: ");
    Console.WriteLine("1 - Adicionar Pizza ");
    Console.WriteLine("2 - Listar Pizza ");
    Console.WriteLine("3 - Realizar Pedidos");
    Console.WriteLine("4 - Listar Pedidos");
    Console.WriteLine("5 - Pagar Pedido");
    Console.WriteLine("0 - Encerrar ");

    Console.WriteLine("Digite sua opção ");
    opcao = Console.ReadLine();

    switch (opcao)
    {
        case "1":
            AdicionarPizza();
            break;
        case "2":
            ListarPizza();
            break;
        case "3":
            RealizarPedido();
            break;
        case "4":
            ConsultarPedidos();
            break;
        case "5":
            PagarPedido();
            break;
        case "0":
            Console.WriteLine("Encerrando.");
            return;
        default:
            Console.WriteLine("Opção invalida!");
            Fim();
            break;
    }
}


///REALIZA PAGAMENTO DO PEDIDO
void PagarPedido()
{
    try
    {


        Console.WriteLine("Digite o codigo do pedido: ");
        foreach (Pedido pedido in historicopedido)
        {
            if (pedido.PedidoPago == PedidoPago.NAO)
            {
                Console.WriteLine("\t------------------------------------");
                Console.WriteLine("\t#" + pedido.Codigo + " - Cliente: " + pedido.DadosCliente.NomeCliente + " - Falta: " + pedido.FaltaPagar().ToString("C"));
            }

        }


        var codPedidoEscolhida = Console.ReadLine();



        foreach (Pedido pedido in historicopedido)
        {
            if (pedido.Codigo.ToString() == codPedidoEscolhida)
            {
                if (pedido.PedidoPago == PedidoPago.SIM)
                {
                    Console.WriteLine("PEDIDO INVALIDO!");

                    break;
                }
                else
                {

                    Console.Clear();

                    Console.WriteLine("PEDIDO: " + pedido.Codigo);

                    Console.WriteLine("Cliente: " + pedido.DadosCliente.NomeCliente + " " + pedido.DadosCliente.Telefone);


                    foreach (Pizza pizza in pedido.Pizzas)
                    {
                        Console.WriteLine(+pizza.Codigo + " - " + pizza.Nome + " - " + pizza.Preco.ToString("C"));


                    }

                    Console.WriteLine("Total: " + pedido.Total().ToString("C"));
                    Console.WriteLine("Quanto Falta para Pagar: " + pedido.FaltaPagar().ToString("C"));
                    Console.WriteLine("Pago: " + pedido.PedidoPago.ToString());


                    Console.WriteLine("ESCOLHA A FORMA DE PAGAMENTO:");
                    Console.WriteLine("------------------------------------");
                    Console.WriteLine("1 - Dinheiro ");
                    Console.WriteLine("2 - Cartão Debito");
                    Console.WriteLine("3 - Vale-Refeição");
                    var pagamento = new Pagamento();


                    var codFormaPagamentoEscolhida = int.Parse(Console.ReadLine());
                    pagamento.FormaPagamento = (FormaPagamento)codFormaPagamentoEscolhida;


                    Console.WriteLine("Qual valor  (Formato 00,00):");

                    var valorapagar = float.Parse(Console.ReadLine());
                    pagamento.ValorPago = valorapagar;

                    pedido.EfetuarPagamento(pagamento);

                    Console.WriteLine("VALOR RECEBIDO COM SUCESSO!");

                    Console.WriteLine("TOTAL PAGO:" + pedido.TotalPago().ToString("C") + " " + pedido.ListaFormaPagamento());
                    Console.WriteLine("FALTA:" + pedido.FaltaPagar().ToString("C"));
                    Console.WriteLine("TROCO:" + pedido.Troco().ToString("C"));


                    break;
                }
            }
        }




        Fim();
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine(" ERRO -  " + ex.Message);
        Fim();
    }
    catch (Exception ex)
    {
        Console.WriteLine(" ERRO - TENTE NOVAMENTE");
        Fim();
    }


}

///ADICIONA PIZZA AO CARDAPIO
void AdicionarPizza()
{
    try
    {
        Console.WriteLine("Adicionar uma pizza!");
        Console.WriteLine("------------------------------------");
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
        pizza.Codigo = cardapio.Pizzas.Count() + 1;


        cardapio.Add(pizza);
        Console.WriteLine("------------------------------------");
        Console.WriteLine("Codigo: " + pizza.Codigo);
        Console.WriteLine("Nome: " + pizza.Nome);
        Console.WriteLine("Ingrediente: " + pizza.Ingredientes);
        Console.WriteLine("Preço: " + pizza.Preco.ToString("C"));
        Console.WriteLine("------------------------------------");
        Console.WriteLine();


        Console.WriteLine(" PIZZA CRIADA COM SUCESSO!");


        Fim();

    }
    catch (Exception ex)
    {
        Console.WriteLine(" ERRO - TENTE NOVAMENTE");
        Fim();
    }
}

///LISTA CARDAPIO DE PIZZAS
void ListarPizza()
{
    try
    {
        Console.WriteLine("Listar as Pizzas!");
        Console.WriteLine("------------------------------------");

        foreach (Pizza item in cardapio.Pizzas)
        {
            Console.WriteLine("Codigo: " + item.Codigo);
            Console.WriteLine("Nome: " + item.Nome);
            Console.WriteLine("Ingrediente: " + item.Ingredientes);
            Console.WriteLine("Preço: " + item.Preco.ToString("C"));
            Console.WriteLine("------------------------------------");
        }


        Fim();

    }
    catch (Exception ex)
    {
        Console.WriteLine(" ERRO - TENTE NOVAMENTE");
        Fim();

    }
}

///CRIA PEDIDO
void RealizarPedido()
{
    try
    {
        Console.WriteLine("Criar Novo Pedido");
        Console.WriteLine("------------------------------------");
        var pedido = new Pedido();


        Console.WriteLine("Quem é o Cliente?");
        var nomecliente = Console.ReadLine();

        Console.WriteLine("Qual é o Telefone do Cliente");
        var telefone = long.Parse(Console.ReadLine());

        var cliente = new Cliente();
        cliente.NomeCliente = nomecliente;
        cliente.Telefone = telefone;


        pedido.DadosCliente = cliente;

        pedido.Codigo = historicopedido.Count() + 1;

        pedido.PedidoPago = PedidoPago.NAO;


        var escolha = 0;
        do
        {
            Console.WriteLine("Digite o codigo para adicionar uma pizza ao pedido: ");
            Console.WriteLine("------------------------------------");
            foreach (Pizza item in cardapio.Pizzas)
            {
                Console.WriteLine("Codigo: " + item.Codigo);

                Console.WriteLine("Nome: " + item.Nome);

                Console.WriteLine("Preço: " + item.Preco.ToString("C"));
                Console.WriteLine("------------------------------------");
            }


            var codPizzaEscolhida = Console.ReadLine();

            foreach (Pizza item in cardapio.Pizzas)
            {
                if (item.Codigo.ToString() == codPizzaEscolhida)
                {
                    pedido.Pizzas.Add(item);
                    break;
                }
            }


            Console.WriteLine("Deseja acrescentar mais uma pizza: 1 - SIM | 2 - NÃO");
            escolha = int.Parse(Console.ReadLine());
        } while (escolha == 1);

        Console.WriteLine("------------------------------------");

        historicopedido.Add(pedido);
        Console.WriteLine("Pedido Realizado");


        Fim();

    }
    catch (Exception ex)
    {
        Console.WriteLine(" ERRO - TENTE NOVAMENTE");

        Fim();
    }
}


///LISTA TODOS OS PEDIDOS
void ConsultarPedidos()
{
    try
    {
        Console.WriteLine("Listar Pedido!");
        Console.WriteLine("------------------------------------");
        foreach (Pedido pedido in historicopedido)
        {
            Console.WriteLine("Numero Pedido: " + pedido.Codigo);
            Console.WriteLine("Cliente: " + pedido.DadosCliente.NomeCliente);
            Console.WriteLine("Telefone: " + pedido.DadosCliente.Telefone);

            Console.WriteLine("Itens do pedido:");
            foreach (Pizza pizza in pedido.Pizzas)
            {
                Console.WriteLine("\t----------------------------");
                Console.WriteLine("\tCodigo: " + pizza.Codigo);
                Console.WriteLine("\tNome: " + pizza.Nome);
                Console.WriteLine("\tIngrediente: " + pizza.Ingredientes);
                Console.WriteLine("\tPreço: " + pizza.Preco.ToString("C"));


            }
            Console.WriteLine("Total: " + pedido.Total().ToString("C"));
            Console.WriteLine("Quanto Falta para Pagar: " + pedido.FaltaPagar().ToString("C"));
            Console.WriteLine("Pago: " + pedido.PedidoPago.ToString());
            Console.WriteLine("------------------------------------");
        }


        Fim();
    }
    catch (Exception ex)
    {
        Console.WriteLine(" ERRO - TENTE NOVAMENTE");

        Fim();
    }
}

static void Fim()
{
    Console.WriteLine("Clique Enter para continuar...");
    Console.ReadLine();
    Console.Clear();
}