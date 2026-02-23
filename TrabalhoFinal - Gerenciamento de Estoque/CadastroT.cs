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
    public partial class CadastroT : UserControl
    {
        public CadastroT()
        {
            InitializeComponent();
        }

        private void botaoFinalizar_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Criar o objeto técnico
                Tecnico t = new Tecnico();
                t.Nome = txtNome.Text;
                t.Endereco = txtEndereco.Text;
                t.Numero = txtNumero.Text;
                t.Email = txtEmail.Text;
                t.Telefone = txtTelefone.Text;
                t.CPF = txtCpf.Text;          
                t.Especialidade = txtEspecialidade.Text;

                // 2. Salvar no Banco
                TecnicoD dao = new TecnicoD();
                dao.Inserir(t);

                MessageBox.Show("Técnico cadastrado com sucesso!");

                // 3. Limpar e Atualizar
                LimparCampos(); // Use aquele método que limpa MaskedTextBox que fizemos
                
                AtualizarGrade();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
        }

        private void AtualizarGrade()
        {
            TecnicoD dao = new TecnicoD();
            dgvTecnicos.DataSource = dao.ListarTecnicos();
        }

        private void CadastroT_Load(object sender, EventArgs e)
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
