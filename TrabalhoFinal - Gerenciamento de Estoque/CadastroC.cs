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
    public partial class CadastroC : UserControl
    {
        public CadastroC()
        {
            InitializeComponent();
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
                    // Opcional: define o texto como vazio caso o Clear() não remova a máscara
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

        private void AtualizarGrade()
        {
            try
            {
                ClienteD dao = new ClienteD();
                // O DataSource é a "fonte de dados" do componente
                dgvClientes.DataSource = dao.ListarClientes();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void botaoFinalizar_Click(object sender, EventArgs e)
        {
            Cliente obj = new Cliente();
            obj.Nome = txtNome.Text;
            obj.Endereco = txtEndereco.Text;
            obj.Numero = txtNumero.Text;
            obj.Email = txtEmail.Text;
            obj.Telefone = txtTelefone.Text;
            obj.CPF = txtCpf.Text;
            obj.Aparelho = txtAparelho.Text;
            obj.Problema = txtProblema.Text;

            // 2. Chama o método de inserção
            try
            {
                ClienteD dao = new ClienteD();
                dao.Inserir(obj);

                MessageBox.Show("Cliente salvo com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimparCampos();

                AtualizarGrade();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao conectar com o MySQL: " + ex.Message);
            }
        }

        private void CadastroC_Load(object sender, EventArgs e)
        {
            AtualizarGrade();
        }
    }
}
