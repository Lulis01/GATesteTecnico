using System;
using System.Windows.Forms;
using GATesteTecnico.Banco;
using GATesteTecnico.Modelo;

namespace GATesteTecnico
{
    public partial class TelaLocacao : Form
    {
        public TelaLocacao()
        {
            InitializeComponent();
        }

        private void TelaLocacao_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
            AtualizarGridAtivas();
        }

        public void AtualizarGridAtivas()
        {
            try
            {
                dgvLocacoes.DataSource = LocacaoDataAccess.PegarLocacoesAtivas();

                if (dgvLocacoes.Columns.Count > 0)
                {
                    dgvLocacoes.Columns[0].HeaderText = "Id";
                    dgvLocacoes.Columns[1].HeaderText = "Cliente Id";
                    dgvLocacoes.Columns[2].HeaderText = "Item Id";
                    dgvLocacoes.Columns[3].HeaderText = "Cliente";
                    dgvLocacoes.Columns[4].HeaderText = "Item";
                    dgvLocacoes.Columns[5].HeaderText = "Data Retirada";
                    dgvLocacoes.Columns[6].HeaderText = "Data Prev. Devolução";
                    dgvLocacoes.Columns[7].HeaderText = "Data Devolução";
                    dgvLocacoes.Columns[8].HeaderText = "Valor Total";
                    dgvLocacoes.Columns[7].Visible = false; // ainda não devolvida, não faz sentido mostrar
                    dgvLocacoes.Columns[9].Visible = false; // Status

                    dgvLocacoes.Columns[5].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                    dgvLocacoes.Columns[6].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";

                    dgvLocacoes.Columns[8].DefaultCellStyle.Format = "C2";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar locações: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegistrarLocacao_Click(object sender, EventArgs e)
        {
            CadastroLocacao telaCadastro = new CadastroLocacao(this);
            telaCadastro.ShowDialog();
        }

        private void btnFinalizarLocacao_Click(object sender, EventArgs e)
        {
            if (dgvLocacoes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione uma locação antes de finalizar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = (int)dgvLocacoes.SelectedRows[0].Cells[0].Value;

            if (LocacaoDataAccess.FinalizarLocacao(id, DateTime.Now))
            {
                MessageBox.Show("Locação finalizada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                AtualizarGridAtivas();
            }
            else
            {
                MessageBox.Show("Erro ao finalizar locação.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLocacoesFinalizadas_Click(object sender, EventArgs e)
        {
            LocacoesEfetuadas telaFinalizadas = new LocacoesEfetuadas();
            telaFinalizadas.ShowDialog();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
