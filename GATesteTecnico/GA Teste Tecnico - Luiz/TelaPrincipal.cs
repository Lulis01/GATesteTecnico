using System;
using System.Windows.Forms;

namespace GATesteTecnico
{
    public partial class TelaPrincipal : Form
    {
        public TelaPrincipal()
        {
            InitializeComponent();
        }

        private void TelaPrincipal_Load(object sender, EventArgs e)
        {
            // Configurações iniciais se necessário
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            Clientes telaClientes = new Clientes();
            telaClientes.ShowDialog();
        }

        private void btnItens_Click(object sender, EventArgs e)
        {
            Itens telaItens = new Itens();
            telaItens.ShowDialog();
        }

        private void btnLocacao_Click(object sender, EventArgs e)
        {
            TelaLocacao telaLocacao = new TelaLocacao();
            telaLocacao.ShowDialog();
        }
    }
}
