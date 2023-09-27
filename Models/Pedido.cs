using projeto.Models;


namespace projeto.Models
{
    public enum  PedidoPago
    {
        NAO = 0,
        SIM = 1 

    }
    public class Pedido
    {
        public int Codigo { get; set; }
        public Cliente DadosCliente { get; set; } = new Cliente();
        public List<Pizza> Pizzas { get; set; } = new List<Pizza>(); 
        public List<Pagamento> Pagamentos { get; set; } = new List<Pagamento>();
        public PedidoPago PedidoPago { get; set; }

        public int PagamentoCartao = 0;


        /// <summary>
        /// Valor total do pedido
        /// </summary>
        /// <returns></returns>
        public float Total()
        {
            float total = 0;
            foreach (Pizza item in Pizzas)
            {

                total += item.Preco;
            }
            return total;
        }


        /// <summary>
        /// Registra os pagamentos
        /// </summary>
        /// <param name="pagamento"></param>
        /// <exception cref="ArgumentException"></exception>
        public void EfetuarPagamento(Pagamento pagamento)
        {
           

            if(pagamento.ValorPago < 0 )
                throw new ArgumentException("Valor de pagamento invalido.");

            if(Pagamentos.Select(x => x.FormaPagamento).Distinct().Count() >= 2 && Pagamentos.Where(o=>o.FormaPagamento == pagamento.FormaPagamento).Count()== 0)
                throw new ArgumentException("Permitido apenas 2 formas de pagamento");

           

            //5  - SE CARTAO NAO PERMITIR TROCO
            if ((pagamento.ValorPago <= FaltaPagar() && PagamentoCartao == 1) || PagamentoCartao == 0)
                Pagamentos.Add(pagamento);
            else
                throw new ArgumentException("Valor superior ao em aberto do pedido.");

            if (pagamento.FormaPagamento == FormaPagamento.VALE_REFEICAO || pagamento.FormaPagamento == FormaPagamento.CARTAO_DEBITO)
                PagamentoCartao = 1;

            if (FaltaPagar() == 0)
                PedidoPago = PedidoPago.SIM;

        }


        /// <summary>
        /// Valor total Pago
        /// </summary>
        /// <returns></returns>
        public float TotalPago()
        {
            float total = 0;
            foreach (Pagamento pagamento in Pagamentos)
            {

                total += pagamento.ValorPago;
            }
            return total;

        }

        /// <summary>
        /// FormaPagamento Pago
        /// </summary>
        /// <returns></returns>
        public string ListaFormaPagamento()
        {
            string formas = "(";
            foreach (Pagamento pagamento in Pagamentos)
            {

                formas += pagamento.FormaPagamento.ToString() +" ";
            }
            return formas +")";

        }




        /// <summary>
        /// Valor falta pagar
        /// </summary>
        /// <returns></returns>
        public float FaltaPagar()
        {
            if (Total() > TotalPago())
                return Total() - TotalPago();
            else return 0;


        }


        /// <summary>
        /// Troco
        /// </summary>
        /// <returns></returns>
        public float Troco()
        {
            if (TotalPago() > Total())
                return TotalPago() - Total();
            else
                return 0;

        }



    }
}