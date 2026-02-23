using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrabalhoFinal___Gerenciamento_de_Estoque
{
    public partial class Gerenciamento : UserControl
    {
        public Gerenciamento()
        {
            InitializeComponent();
        }

        private void CarregarDados()
        {
            try
            {
                ClienteD dao = new ClienteD();
                dgvGerenciamento.DataSource = dao.ListarClientes();

                // Verifica se a coluna existe antes de esconder para evitar erros
                if (dgvGerenciamento.Columns.Contains("id"))
                {
                    dgvGerenciamento.Columns["id"].Visible = false;
                }

                
                dgvGerenciamento.Columns["nome"].HeaderText = "Nome";
                dgvGerenciamento.Columns["aparelho"].HeaderText = "Aparelho";
                dgvGerenciamento.Columns["problema"].HeaderText = "Defeito";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }

        }

        private void Gerenciamento_Load(object sender, EventArgs e)
        {
            CarregarDados();
        }

        private void botaoAtualizar_Click(object sender, EventArgs e)
        {
            CarregarDados();
        }
    }
}
