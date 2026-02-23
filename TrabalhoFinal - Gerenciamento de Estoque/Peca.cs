using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoFinal___Gerenciamento_de_Estoque
{
    internal class Peca
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public string Categoria { get; set; }
        public decimal Preco { get; set; }
        public string Condicao { get; set; }
    }
}
