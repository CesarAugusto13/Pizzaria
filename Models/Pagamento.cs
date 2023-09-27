using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto.Models
{

    public enum FormaPagamento
    {
        DINHEIRO = 1,
        CARTAO_DEBITO = 2,
        VALE_REFEICAO = 3

    }

    public class Pagamento
    {

        public FormaPagamento FormaPagamento { get; set; }

        public float ValorPago { get; set; }
    }
}
