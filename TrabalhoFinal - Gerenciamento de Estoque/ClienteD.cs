using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoFinal___Gerenciamento_de_Estoque
{
    internal class ClienteD
    {
        public void Inserir(Cliente cliente)
        {
            using (var conn = conexao.GetConexao())
            {
                string sql = @"INSERT INTO clientes (nome, endereco, numero, email, telefone, cpf, aparelho, problema) 
                           VALUES (@nome, @end, @num, @email, @tel, @cpf, @apa, @prob)";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@nome", cliente.Nome);
                cmd.Parameters.AddWithValue("@end", cliente.Endereco);
                cmd.Parameters.AddWithValue("@num", cliente.Numero);
                cmd.Parameters.AddWithValue("@email", cliente.Email);
                cmd.Parameters.AddWithValue("@tel", cliente.Telefone);
                cmd.Parameters.AddWithValue("@cpf", cliente.CPF);
                cmd.Parameters.AddWithValue("@apa", cliente.Aparelho);
                cmd.Parameters.AddWithValue("@prob", cliente.Problema);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public DataTable ListarClientes()
        {
            DataTable tabela = new DataTable();
            try
            {
                using (var conn = conexao.GetConexao())
                {
                    string sql = "SELECT * FROM clientes";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);

                    conn.Open();

                    // O DataAdapter preenche o DataTable automaticamente
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(tabela);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar clientes: " + ex.Message);
            }
            return tabela;
        }
    }
}
