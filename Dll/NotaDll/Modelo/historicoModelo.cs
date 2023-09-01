using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotaDll.Modelo
{
    public class historicoModelo
    {
        public int Id_Historico { get; set; }
        public DateTime Data_Historico { get; set; }
        public int Id_Usuario_Historico { get; set; }
        public string Operacao_Historico { get; set; }
        public int Id_Nota_Historico { get; set; }
        public int Quantidade_Visto_Historico { get; set; }
        public int Quantidade_Aprovacao_Historico { get; set; }
        public int Id_Configuracao_Faixa_Valor_Historico { get; set; }
        public char Status_Historico { get; set; }
        public DateTime Data_Inclusao_Historico { get; set; }
        public DateTime Data_Alteracao_Historico { get; set; }
    }
}
