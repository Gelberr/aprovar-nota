using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotaDll.Modelo
{
    public class cadastrarNota
    {
        public DateTime Data_Emissao_Nota { get; set; }
        public double Valor_Mercadoria_Nota { get; set; }
        public double Valor_Desconto_Nota { get; set; }
        public double Valor_Frete_Nota { get; set; }
        public double Valor_Total_Nota { get; set; }
        public int Id_Configuracao_Faixa_Valor_Nota { get; set; }
        public int Quantidade_Visto_Nota { get; set; }
        public int Quantidade_Aprovacao_Nota { get; set; }
        public char Status_Nota { get; set; }
    }
}
