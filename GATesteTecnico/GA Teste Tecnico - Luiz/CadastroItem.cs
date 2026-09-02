using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using GATesteTecnico.Banco;
using GATesteTecnico.Modelo;

namespace GATesteTecnico
{
    public partial class CadastroItem : Form
    {
        private Itens telaItens;
        private Item item;
        private int itemId = 0;

        public CadastroItem()
        {
            InitializeComponent();
        }

        public CadastroItem(Itens tela, int id = 0) : this()
        {
            telaItens = tela;
            itemId = id;

            if (id > 0)
            {
                item = ItemDataAccess.PegarItem(id);
                if (item != null)
                {
                    ItemParaTela(item);
                }
            }
        }

        private void ItemParaTela(Item i)
        {
            txtNome.Text = i.Nome.Trim();

            
            if (i.Categoria == "Manuais") rdbManuais.Checked = true;
            else if (i.Categoria == "Elétricas") rdbEletricas.Checked = true;
            else if (i.Categoria == "Medição") rdbMedicao.Checked = true;
            else if (i.Categoria == "Corte") rdbCorte.Checked = true;

            txtValorDiaria.Text = i.ValorDiaria.ToString("F2");

            
            cmbStatus.SelectedItem = i.Status.ToString();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
            {
                return;
            }

            Item novoItem;

            if (item != null)
            {
                novoItem = item;
                novoItem.DataUpdate = DateTime.Now;
            }
            else
            {
                novoItem = new Item();
                novoItem.DataCadastro = DateTime.Now;
            }

            novoItem.Nome = txtNome.Text.Trim();

            
            if (rdbManuais.Checked) novoItem.Categoria = "Manuais";
            else if (rdbEletricas.Checked) novoItem.Categoria = "Elétricas";
            else if (rdbMedicao.Checked) novoItem.Categoria = "Medição";
            else if (rdbCorte.Checked) novoItem.Categoria = "Corte";

            novoItem.ValorDiaria = decimal.Parse(txtValorDiaria.Text.Trim());
            novoItem.Status = (StatusItem)Enum.Parse(typeof(StatusItem), cmbStatus.SelectedItem.ToString());

            
            bool resultado;
            if (item != null)
            {
                resultado = ItemDataAccess.AtualizarItem(novoItem);
            }
            else
            {
                resultado = ItemDataAccess.SalvarItem(novoItem);
            }

            if (resultado)
            {
                MessageBox.Show("Item salvo com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                telaItens.AtualizarGrid();
                this.Close();
            }
            else
            {
                lblErros.Text = "Erro ao salvar item no banco de dados.";
            }
        }

        private bool ValidarCampos()
        {
            lblErros.Text = "";

            
            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                lblErros.Text += "Nome é obrigatório.\n";
            }

            
            if (!rdbManuais.Checked && !rdbEletricas.Checked && !rdbMedicao.Checked && !rdbCorte.Checked)
            {
                lblErros.Text += "Selecione uma categoria.\n";
            }

            
            if (string.IsNullOrWhiteSpace(txtValorDiaria.Text))
            {
                lblErros.Text += "Valor da diária é obrigatório.\n";
            }
            else if (!decimal.TryParse(txtValorDiaria.Text, out decimal valor) || valor <= 0)
            {
                lblErros.Text += "Valor da diária deve ser um número maior que zero.\n";
            }

            
            if (cmbStatus.SelectedItem == null)
            {
                lblErros.Text += "Selecione um status.\n";
            }

            return string.IsNullOrWhiteSpace(lblErros.Text);
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CadastroItem_Load(object sender, EventArgs e)
        {
            lblErros.Text = "";

            
            cmbStatus.Items.Clear();
            cmbStatus.Items.Add(StatusItem.Disponivel.ToString());
            cmbStatus.Items.Add(StatusItem.Locado.ToString());
            cmbStatus.Items.Add(StatusItem.Manutencao.ToString());
            cmbStatus.SelectedIndex = 0;
        }
    }
}
