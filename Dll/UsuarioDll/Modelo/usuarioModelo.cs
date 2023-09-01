using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuarioDll
{
    public class usuarioModelo
    {
        public int Id_Usuario { get; set; }
        public string Nome_Usuario { get; set; }
        public string Email_Usuario { get; set; }
        public char Papel_Usuario { get; set; }
        public int Quantidade_Minimo_Visto { get; set; }
        public int Quantidade_Maximo_Visto { get; set; }
        public int Quantidade_Minimo_Aprovacao { get; set; }
        public int Quantidade_Maximo_Aprovacao { get; set; }
        public char Status_Usuario { get; set; }


    }
}
