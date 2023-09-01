using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotaDll.Modelo
{
    public class configuracaoFaixaObter
    {
        public int Id_Configuracao { get; set; }
        public int Quantidade_Visto_Configuracao { get; set; }
        public int Quantidade_Aprovacao_Configuracao { get; set; }
        public decimal Faixa_Minima_Configuracao { get; set; }
        public decimal Faixa_Maxima_Configuracao { get; set; }
    }
}
