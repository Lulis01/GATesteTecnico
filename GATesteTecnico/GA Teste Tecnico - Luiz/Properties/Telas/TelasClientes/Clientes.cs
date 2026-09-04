using System;
using System.Windows.Forms;
using GATesteTecnico.Banco;

namespace GATesteTecnico
{
    public partial class Clientes : Form
    {
        public Clientes()
        {
            InitializeComponent();
        }

        private void Clientes_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
            AtualizarGrid();
        }

        public void AtualizarGrid()
        {
            try
            {
                dgvClientes.DataSource = ClienteDataAccess.PegarClientes();

                if (dgvClientes.Columns.Count > 0)
                {
                    dgvClientes.Columns[0].HeaderText = "Id";
                    dgvClientes.Columns[1].HeaderText = "Nome";
                    dgvClientes.Columns[2].HeaderText = "CPF";
                    dgvClientes.Columns[3].HeaderText = "Telefone";
                    dgvClientes.Columns[4].HeaderText = "Email";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar clientes: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            CadastroCliente telaCadastro = new CadastroCliente(this);
            telaCadastro.ShowDialog();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um cliente antes de atualizar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = (int)dgvClientes.SelectedRows[0].Cells[0].Value;
            CadastroCliente telaCadastro = new CadastroCliente(this, id);
            telaCadastro.ShowDialog();
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um cliente antes de remover.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult resultado = MessageBox.Show("Tem certeza que deseja remover este cliente?", "Confirmar Remoção", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                int id = (int)dgvClientes.SelectedRows[0].Cells[0].Value;
                if (ClienteDataAccess.DeletarCliente(id))
                {
                    MessageBox.Show("Cliente removido com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    AtualizarGrid();
                }
                else
                {
                    MessageBox.Show("Erro ao remover cliente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
