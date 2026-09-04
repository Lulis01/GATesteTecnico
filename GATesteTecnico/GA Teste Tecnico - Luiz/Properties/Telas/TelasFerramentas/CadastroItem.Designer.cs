namespace GATesteTecnico
{
    partial class CadastroItem
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rdbManuais = new System.Windows.Forms.RadioButton();
            this.rdbEletricas = new System.Windows.Forms.RadioButton();
            this.rdbMedicao = new System.Windows.Forms.RadioButton();
            this.rdbCorte = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.txtValorDiaria = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.lblErros = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // label1
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cadastro de Item";

            // label2 - Nome
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nome:";

            // txtNome
            this.txtNome.Location = new System.Drawing.Point(12, 70);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(300, 20);
            this.txtNome.TabIndex = 2;

            // label3 - Categoria
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Categoria:";

            // rdbManuais
            this.rdbManuais.AutoSize = true;
            this.rdbManuais.Location = new System.Drawing.Point(12, 120);
            this.rdbManuais.Name = "rdbManuais";
            this.rdbManuais.Size = new System.Drawing.Size(63, 17);
            this.rdbManuais.TabIndex = 4;
            this.rdbManuais.Text = "Manuais";
            this.rdbManuais.UseVisualStyleBackColor = true;

            // rdbEletricas
            this.rdbEletricas.AutoSize = true;
            this.rdbEletricas.Location = new System.Drawing.Point(80, 120);
            this.rdbEletricas.Name = "rdbEletricas";
            this.rdbEletricas.Size = new System.Drawing.Size(67, 17);
            this.rdbEletricas.TabIndex = 5;
            this.rdbEletricas.Text = "Elétricas";
            this.rdbEletricas.UseVisualStyleBackColor = true;

            // rdbMedicao
            this.rdbMedicao.AutoSize = true;
            this.rdbMedicao.Location = new System.Drawing.Point(150, 120);
            this.rdbMedicao.Name = "rdbMedicao";
            this.rdbMedicao.Size = new System.Drawing.Size(62, 17);
            this.rdbMedicao.TabIndex = 6;
            this.rdbMedicao.Text = "Medição";
            this.rdbMedicao.UseVisualStyleBackColor = true;

            // rdbCorte
            this.rdbCorte.AutoSize = true;
            this.rdbCorte.Location = new System.Drawing.Point(215, 120);
            this.rdbCorte.Name = "rdbCorte";
            this.rdbCorte.Size = new System.Drawing.Size(52, 17);
            this.rdbCorte.TabIndex = 7;
            this.rdbCorte.Text = "Corte";
            this.rdbCorte.UseVisualStyleBackColor = true;

            // label4 - Valor Diária
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Valor Diária (R$):";

            // txtValorDiaria
            this.txtValorDiaria.Location = new System.Drawing.Point(12, 170);
            this.txtValorDiaria.Name = "txtValorDiaria";
            this.txtValorDiaria.Size = new System.Drawing.Size(150, 20);
            this.txtValorDiaria.TabIndex = 9;

            // label5 - Status
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 200);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Status:";

            // cmbStatus
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(12, 220);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(150, 21);
            this.cmbStatus.TabIndex = 11;

            // lblErros
            this.lblErros.AutoSize = true;
            this.lblErros.ForeColor = System.Drawing.Color.Red;
            this.lblErros.Location = new System.Drawing.Point(12, 250);
            this.lblErros.Name = "lblErros";
            this.lblErros.Size = new System.Drawing.Size(0, 13);
            this.lblErros.TabIndex = 12;

            // btnSalvar
            this.btnSalvar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnSalvar.Location = new System.Drawing.Point(12, 280);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(100, 30);
            this.btnSalvar.TabIndex = 13;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);

            // btnVoltar
            this.btnVoltar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnVoltar.Location = new System.Drawing.Point(120, 280);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(100, 30);
            this.btnVoltar.TabIndex = 14;
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);

            // CadastroItem
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 330);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.lblErros);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtValorDiaria);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.rdbCorte);
            this.Controls.Add(this.rdbMedicao);
            this.Controls.Add(this.rdbEletricas);
            this.Controls.Add(this.rdbManuais);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "CadastroItem";
            this.Text = "Cadastro de Item";
            this.Load += new System.EventHandler(this.CadastroItem_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rdbManuais;
        private System.Windows.Forms.RadioButton rdbEletricas;
        private System.Windows.Forms.RadioButton rdbMedicao;
        private System.Windows.Forms.RadioButton rdbCorte;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtValorDiaria;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.Label lblErros;
    }
}
