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
    public partial class GestaoPecas : UserControl
    {
        public GestaoPecas()
        {
            InitializeComponent();
        }

        private void botaoAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                
                Peca p = new Peca();
                p.Nome = txtNome.Text;
                p.Categoria = txtCategoria.Text;
                p.Condicao = txtCondicao.Text;

               
                p.Quantidade = int.Parse(txtQuantidade.Text);
                p.Preco = decimal.Parse(txtPreco.Text);

                
                PecaD dao = new PecaD();
                dao.Inserir(p);

                MessageBox.Show("Peça adicionada com sucesso!");

                //Limpar campos e atualizar o DataGrid
                LimparCampos();
                AtualizarGrade();
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor, insira valores válidos para Preço e Quantidade.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
        }

        private void AtualizarGrade()
        {
            PecaD dao = new PecaD();
            dgvPecas.DataSource = dao.ListarPecas();

            // Escondendo o ID para ficar mais limpo, como você preferiu antes
            if (dgvPecas.Columns.Contains("id"))
                dgvPecas.Columns["id"].Visible = false;
        }

        private void GestaoPecas_Load(object sender, EventArgs e)
        {
            AtualizarGrade();
        }

        private void LimparCampos()
        {

            foreach (Control c in this.Controls)
            {
                // Limpa TextBox comum
                if (c is TextBox)
                {
                    ((TextBox)c).Clear();
                }

                // Limpa MaskedTextBox (CPF, Telefone, etc)
                if (c is MaskedTextBox)
                {
                    ((MaskedTextBox)c).Clear();
                    
                    ((MaskedTextBox)c).Text = string.Empty;
                }

                // Limpa ComboBox e outros se necessário
                if (c is ComboBox)
                {
                    ((ComboBox)c).SelectedIndex = -1;
                }
            }

            // Devolve o foco para o primeiro campo
            txtNome.Focus();

        }
    }
}
