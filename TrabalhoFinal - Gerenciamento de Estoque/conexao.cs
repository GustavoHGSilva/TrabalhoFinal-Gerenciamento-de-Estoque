using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoFinal___Gerenciamento_de_Estoque
{
    internal class conexao
    {
        private static string strConexao = "Server=localhost;Database=AssistenciaTecnica;Uid=root;Pwd=23571113;";

        public static MySqlConnection GetConexao()
        {
            return new MySqlConnection(strConexao);
        }
    }
}
