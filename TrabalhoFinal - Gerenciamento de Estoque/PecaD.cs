using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoFinal___Gerenciamento_de_Estoque
{
    internal class PecaD
    {
        public void Inserir(Peca peca)
        {
            using (var conn = conexao.GetConexao())
            {
                string sql = @"INSERT INTO pecas (nome, quantidade, categoria, preco, condicao) 
                           VALUES (@nome, @qtd, @cat, @preco, @cond)";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@nome", peca.Nome);
                cmd.Parameters.AddWithValue("@qtd", peca.Quantidade);
                cmd.Parameters.AddWithValue("@cat", peca.Categoria);
                cmd.Parameters.AddWithValue("@preco", peca.Preco);
                cmd.Parameters.AddWithValue("@cond", peca.Condicao);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public DataTable ListarPecas()
        {
            DataTable tabela = new DataTable();
            using (var conn = conexao.GetConexao())
            {
                string sql = "SELECT * FROM pecas";
                MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                da.Fill(tabela);
            }
            return tabela;
        }
    }
}
