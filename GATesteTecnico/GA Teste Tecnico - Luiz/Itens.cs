using System;
using System.Windows.Forms;
using GATesteTecnico.Banco;

namespace GATesteTecnico
{
    public partial class Itens : Form
    {
        public Itens()
        {
            InitializeComponent();
        }

        private void Itens_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
            AtualizarGrid();
        }

        public void AtualizarGrid()
        {
            try
            {
                dgvItens.DataSource = ItemDataAccess.PegarItens();

                // Configurar colunas
                if (dgvItens.Columns.Count > 0)
                {
                    dgvItens.Columns[0].HeaderText = "Id";
                    dgvItens.Columns[1].HeaderText = "Nome";
                    dgvItens.Columns[2].HeaderText = "Categoria";
                    dgvItens.Columns[3].HeaderText = "Valor Diária";
                    dgvItens.Columns[4].HeaderText = "Status";
                    dgvItens.Columns[5].Visible = false; // DataCadastro
                    dgvItens.Columns[6].Visible = false; // DataUpdate

                    // Formatar coluna de valor
                    dgvItens.Columns[3].DefaultCellStyle.Format = "C2";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar itens: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            CadastroItem telaCadastro = new CadastroItem(this);
            telaCadastro.ShowDialog();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            if (dgvItens.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um item antes de atualizar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = (int)dgvItens.SelectedRows[0].Cells[0].Value;
            CadastroItem telaCadastro = new CadastroItem(this, id);
            telaCadastro.ShowDialog();
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (dgvItens.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um item antes de remover.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult resultado = MessageBox.Show("Tem certeza que deseja remover este item?", "Confirmar Remoção", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                int id = (int)dgvItens.SelectedRows[0].Cells[0].Value;
                if (ItemDataAccess.DeletarItem(id))
                {
                    MessageBox.Show("Item removido com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    AtualizarGrid();
                }
                else
                {
                    MessageBox.Show("Erro ao remover item.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
