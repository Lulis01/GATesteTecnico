using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using GATesteTecnico.Banco;
using GATesteTecnico.Modelo;

namespace GATesteTecnico
{
    public partial class CadastroCliente : Form
    {
        private Clientes telaClientes;
        private Cliente cliente;
        private int clienteId = 0;

        public CadastroCliente(Clientes tela, int id = 0)
        {
            InitializeComponent();
            telaClientes = tela;
            clienteId = id;

            if (id > 0)
            {
                cliente = ClienteDataAccess.PegarCliente(id);
                if (cliente != null)
                {
                    ClienteParaTela(cliente);
                    txtCPF.Enabled = false;
                }
            }
        }

        private void ClienteParaTela(Cliente c)
        {
            txtNome.Text = c.Nome.Trim();
            txtCPF.Text = c.CPF.Trim();
            txtTelefone.Text = c.Telefone?.Trim() ?? "";
            txtEmail.Text = c.Email?.Trim() ?? "";
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
            {
                return;
            }

            Cliente novoCliente;

            if (cliente != null)
            {
                novoCliente = cliente;
                novoCliente.DataUpdate = DateTime.Now;
            }
            else
            {
                novoCliente = new Cliente();
                novoCliente.DataCadastro = DateTime.Now;
            }

            novoCliente.Nome = txtNome.Text.Trim();
            novoCliente.CPF = txtCPF.Text.Trim().Replace(".", "").Replace("-", "");
            novoCliente.Telefone = txtTelefone.Text.Trim().Replace(".", "").Replace("-", "").Replace("(", "").Replace(")", "").Replace(" ", "");
            novoCliente.Email = txtEmail.Text.Trim();

            
            bool resultado;
            if (cliente != null)
            {
                resultado = ClienteDataAccess.AtualizarCliente(novoCliente);
            }
            else
            {
                resultado = ClienteDataAccess.SalvarCliente(novoCliente);
            }

            if (resultado)
            {
                MessageBox.Show("Cliente salvo com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                telaClientes.AtualizarGrid();
                this.Close();
            }
            else
            {
                lblErros.Text = "Erro ao salvar cliente no banco de dados.";
            }
        }

        private bool ValidarCampos()
        {
            lblErros.Text = "";

            
            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                lblErros.Text += "Nome é obrigatório.\n";
            }

           
            if (string.IsNullOrWhiteSpace(txtCPF.Text))
            {
                lblErros.Text += "CPF é obrigatório.\n";
                return false;
            }

            
            string cpfNumeros = txtCPF.Text.Trim().Replace(".", "").Replace("-", "");
            if (cpfNumeros.Length != 11)
            {
                lblErros.Text += "CPF deve ter exatamente 11 números.\n";
            }

            
            if (!System.Text.RegularExpressions.Regex.IsMatch(cpfNumeros, @"^\d{11}$"))
            {
                lblErros.Text += "CPF deve conter apenas números.\n";
            }

            
            if (!string.IsNullOrWhiteSpace(txtTelefone.Text))
            {
                string telefoneNumeros = txtTelefone.Text.Trim().Replace(".", "").Replace("-", "").Replace("(", "").Replace(")", "").Replace(" ", "");
                if (!System.Text.RegularExpressions.Regex.IsMatch(telefoneNumeros, @"^\d*$"))
                {
                    lblErros.Text += "Telefone deve conter apenas números.\n";
                }
                if (telefoneNumeros.Length > 11)
                {
                    lblErros.Text += "Telefone deve ter no máximo 11 números.\n";
                }
            }

            
            if (!string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                try
                {
                    var addr = new System.Net.Mail.MailAddress(txtEmail.Text.Trim());
                }
                catch
                {
                    lblErros.Text += "Email deve ser um endereço válido.\n";
                }
            }

            return string.IsNullOrWhiteSpace(lblErros.Text);
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CadastroCliente_Load(object sender, EventArgs e)
        {
            lblErros.Text = "";
        }
    }
}
