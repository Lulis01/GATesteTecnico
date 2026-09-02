using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GATesteTecnico.Banco;
using GATesteTecnico.Modelo;

namespace GATesteTecnico
{
    public partial class CadastroLocacao : Form
    {
        private TelaLocacao telaLocacao;
        private int clienteIdSelecionado = 0;
        private int itemIdSelecionado = 0;

        public CadastroLocacao()
        {
            InitializeComponent();
        }

        public CadastroLocacao(TelaLocacao tela) : this()
        {
            telaLocacao = tela;
        }

        private void CadastroLocacao_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;

            lblErros.Text = string.Empty;
            CarregarClientes();
            CarregarItens();
        }

        private void CarregarClientes()
        {
            cmbCliente.Items.Clear();
            clienteIdSelecionado = 0;
            txtCliente.Text = string.Empty;

            List<Cliente> clientes = ClienteDataAccess.PegarClientes();
            foreach (Cliente c in clientes)
            {
                cmbCliente.Items.Add(new LocacaoComboItem(c.Id, c.Nome.Trim()));
            }

            cmbCliente.SelectedIndex = -1;
        }

        private void CarregarItens()
        {
            cmbItem.Items.Clear();
            itemIdSelecionado = 0;
            txtItem.Text = string.Empty;

            List<Item> itens = ItemDataAccess.PegarItens();
            foreach (Item i in itens)
            {
                string exibicao = i.Nome.Trim() + " [" + i.Status.ToString() + "]";
                cmbItem.Items.Add(new LocacaoComboItem(i.Id, exibicao));
            }

            cmbItem.SelectedIndex = -1;
        }

        private void cmbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            LocacaoComboItem selecionado = cmbCliente.SelectedItem as LocacaoComboItem;
            if (selecionado != null)
            {
                clienteIdSelecionado = selecionado.Id;
                txtCliente.Text = selecionado.Nome;
            }
        }

        private void cmbItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            LocacaoComboItem selecionado = cmbItem.SelectedItem as LocacaoComboItem;
            if (selecionado != null)
            {
                itemIdSelecionado = selecionado.Id;
                string nomeCompleto = selecionado.Nome;
                int idx = nomeCompleto.IndexOf(" [");
                txtItem.Text = idx >= 0 ? nomeCompleto.Substring(0, idx) : nomeCompleto;
                AtualizarPreviewValor();
            }
        }

        private void txtDias_TextChanged(object sender, EventArgs e)
        {
            AtualizarPreviewValor();
        }

        private void AtualizarPreviewValor()
        {
            lblPreviewDatas.Text = string.Empty;

            if (itemIdSelecionado <= 0) return;

            int dias;
            if (!int.TryParse(txtDias.Text.Trim(), out dias) || dias <= 0) return;

            DateTime dataRetirada = DateTime.Now;
            DateTime dataPrevistaDevolucao = dataRetirada.AddDays(dias);

            decimal valorTotal = LocacaoDataAccess.CalcularValorInicialLocacao(itemIdSelecionado, dias);

            lblPreviewDatas.Text =
                "Data Retirada:     " + dataRetirada.ToString("dd/MM/yyyy HH:mm") + Environment.NewLine +
                "Prev. Devolucao: " + dataPrevistaDevolucao.ToString("dd/MM/yyyy HH:mm") + Environment.NewLine +
                "Valor Estimado:  R$ " + valorTotal.ToString("F2");
        }

        private bool ValidarCampos()
        {
            lblErros.Text = string.Empty;

            if (clienteIdSelecionado <= 0)
            {
                lblErros.Text += "Nenhum cliente foi selecionado." + Environment.NewLine;
            }

            if (itemIdSelecionado <= 0)
            {
                lblErros.Text += "Nenhum item foi selecionado." + Environment.NewLine;
            }
            else
            {
                Item item = ItemDataAccess.PegarItem(itemIdSelecionado);
                if (item != null)
                {
                    if (item.Status == StatusItem.Locado)
                    {
                        lblErros.Text += "O item esta Locado e nao pode ser alugado." + Environment.NewLine;
                    }
                    else if (item.Status == StatusItem.Manutencao)
                    {
                        lblErros.Text += "O item esta em Manutencao e nao pode ser alugado." + Environment.NewLine;
                    }
                }
            }

            if (string.IsNullOrWhiteSpace(txtDias.Text))
            {
                lblErros.Text += "A quantidade de dias nao foi informada." + Environment.NewLine;
            }
            else
            {
                int dias;
                if (!int.TryParse(txtDias.Text.Trim(), out dias) || dias <= 0)
                {
                    lblErros.Text += "A quantidade de dias deve ser um numero inteiro maior que zero." + Environment.NewLine;
                }
            }

            return string.IsNullOrWhiteSpace(lblErros.Text);
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
            {
                return;
            }

            int quantidadeDias = int.Parse(txtDias.Text.Trim());
            DateTime dataRetirada = DateTime.Now;
            DateTime dataPrevistaDevolucao = dataRetirada.AddDays(quantidadeDias);

            decimal valorTotal = LocacaoDataAccess.CalcularValorInicialLocacao(itemIdSelecionado, quantidadeDias);

            Cliente cliente = ClienteDataAccess.PegarCliente(clienteIdSelecionado);
            Item item = ItemDataAccess.PegarItem(itemIdSelecionado);

            Locacao novaLocacao = new Locacao();
            novaLocacao.ClienteId = clienteIdSelecionado;
            novaLocacao.ItemId = itemIdSelecionado;
            novaLocacao.ClienteNome = cliente != null ? cliente.Nome.Trim() : string.Empty;
            novaLocacao.ItemNome = item != null ? item.Nome.Trim() : string.Empty;
            novaLocacao.DataRetirada = dataRetirada;
            novaLocacao.DataPrevistaDevolucao = dataPrevistaDevolucao;
            novaLocacao.ValorTotal = valorTotal;

            bool resultado = LocacaoDataAccess.SalvarLocacao(novaLocacao);

            if (resultado)
            {
                ItemDataAccess.AtualizarStatusItem(itemIdSelecionado, StatusItem.Locado);
                MessageBox.Show("Locacao registrada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                telaLocacao.AtualizarGridAtivas();
                this.Close();
            }
            else
            {
                lblErros.Text = "Erro ao registrar locacao.";
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }

    public class LocacaoComboItem
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public LocacaoComboItem(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public override string ToString()
        {
            return Nome;
        }
    }
}
