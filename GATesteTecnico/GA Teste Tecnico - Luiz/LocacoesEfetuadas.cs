using System;
using System.Windows.Forms;
using GATesteTecnico.Banco;

namespace GATesteTecnico
{
    public partial class LocacoesEfetuadas : Form
    {
        public LocacoesEfetuadas()
        {
            InitializeComponent();
        }

        private void LocacoesEfetuadas_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
            AtualizarGrid();
        }

        private void AtualizarGrid()
        {
            try
            {
                dgvLocacoesFinalizadas.DataSource = LocacaoDataAccess.PegarLocacoesFinalizadas();

                // Configurar colunas
                if (dgvLocacoesFinalizadas.Columns.Count > 0)
                {
                    dgvLocacoesFinalizadas.Columns[0].HeaderText = "Id";
                    dgvLocacoesFinalizadas.Columns[1].HeaderText = "Cliente Id";
                    dgvLocacoesFinalizadas.Columns[2].HeaderText = "Item Id";
                    dgvLocacoesFinalizadas.Columns[3].HeaderText = "Cliente";
                    dgvLocacoesFinalizadas.Columns[4].HeaderText = "Item";
                    dgvLocacoesFinalizadas.Columns[5].HeaderText = "Data Retirada";
                    dgvLocacoesFinalizadas.Columns[6].HeaderText = "Data Prev. Devolução";
                    dgvLocacoesFinalizadas.Columns[7].HeaderText = "Valor Total";
                    dgvLocacoesFinalizadas.Columns[8].Visible = false; // Status

                    // Formatar datas
                    dgvLocacoesFinalizadas.Columns[5].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                    dgvLocacoesFinalizadas.Columns[6].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";

                    // Formatar valor
                    dgvLocacoesFinalizadas.Columns[7].DefaultCellStyle.Format = "C2";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar locações finalizadas: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
