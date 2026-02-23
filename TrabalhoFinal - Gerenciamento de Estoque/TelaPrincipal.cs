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
    public partial class TelaPrincipal : UserControl
    {
        public TelaPrincipal()
        {
            InitializeComponent();
        }

        private void CarregarDados()
        {
            try
            {
                ClienteD dao = new ClienteD();
                dvgResumo.DataSource = dao.ListarClientes();

                // Verifica se a coluna existe antes de esconder para evitar erros
                if (dvgResumo.Columns.Contains("id"))
                {
                    dvgResumo.Columns["id"].Visible = false;
                }


                dvgResumo.Columns["nome"].HeaderText = "Nome";
                dvgResumo.Columns["aparelho"].HeaderText = "Aparelho";
                dvgResumo.Columns["problema"].HeaderText = "Defeito";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }

        }

        private void TelaPrincipal_Load(object sender, EventArgs e)
        {
            CarregarDados();
        }
    }
}
