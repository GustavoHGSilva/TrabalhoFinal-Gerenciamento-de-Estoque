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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        //Utilização de POO para facilitar na criação e troca de User Control
        public static class Navegador
        {
            public static void ExibirControl(Panel painelDestino, UserControl novoControl)
            {
                // Limpa o que quer que esteja no painel no momento
                if (painelDestino.Controls.Count > 0)
                {
                    painelDestino.Controls.Clear();
                }

                // Ajusta o UserControl para preencher todo o espaço do painel
                novoControl.Dock = DockStyle.Fill;

                // Adiciona e traz para a frente
                painelDestino.Controls.Add(novoControl);
                novoControl.BringToFront();
            }
        }

        private void BotaoSair_Click(object sender, EventArgs e)
        {
            Form1 tela = new Form1();
            tela.Show();
            this.Hide();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void BotaoTelaPrincipal_Click(object sender, EventArgs e)
        {
            TelaPrincipal tl = new TelaPrincipal();
            Navegador.ExibirControl(panel2, tl);
        }

        private void BotaoCadastroC_Click(object sender, EventArgs e)
        {
            CadastroC tl = new CadastroC();
            Navegador.ExibirControl(panel2, tl);
        }

        private void BotaoCadastroT_Click(object sender, EventArgs e)
        {
            CadastroT tl = new CadastroT();
            Navegador.ExibirControl(panel2, tl);
        }

        private void BotaoGerenciamento_Click(object sender, EventArgs e)
        {
            Gerenciamento tl = new Gerenciamento();
            Navegador.ExibirControl(panel2, tl);
        }

        private void botaoRelatorio_Click(object sender, EventArgs e)
        {
            Relatorio tl = new Relatorio();
            Navegador.ExibirControl(panel2, tl);
        }

        private void botaoPecas_Click(object sender, EventArgs e)
        {
            GestaoPecas tl = new GestaoPecas();
            Navegador.ExibirControl(panel2, tl);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            TelaPrincipal tl = new TelaPrincipal();
            Navegador.ExibirControl(panel2, tl);
        }
    }
}
