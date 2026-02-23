using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoFinal___Gerenciamento_de_Estoque
{
    internal class TecnicoD
    {
        public void Inserir(Tecnico tecnico)
        {
            using (var conn = conexao.GetConexao())
            {
                string sql = @"INSERT INTO funcionarios (nome, endereco, numero, email, telefone, cpf, especialidade) 
                           VALUES (@nome, @end, @num, @email, @tel, @cpf, @esp)";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@nome", tecnico.Nome);
                cmd.Parameters.AddWithValue("@end", tecnico.Endereco);
                cmd.Parameters.AddWithValue("@num", tecnico.Numero);
                cmd.Parameters.AddWithValue("@email", tecnico.Email);
                cmd.Parameters.AddWithValue("@tel", tecnico.Telefone);
                cmd.Parameters.AddWithValue("@cpf", tecnico.CPF);
                cmd.Parameters.AddWithValue("@esp", tecnico.Especialidade);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public DataTable ListarTecnicos()
        {
            DataTable tabela = new DataTable();
            using (var conn = conexao.GetConexao())
            {
                string sql = "SELECT * FROM funcionarios";
                MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                da.Fill(tabela);
            }
            return tabela;
        }
    }
}
