namespace GATesteTecnico
{
    partial class TelaLocacao
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.dgvLocacoes = new System.Windows.Forms.DataGridView();
            this.btnRegistrarLocacao = new System.Windows.Forms.Button();
            this.btnFinalizarLocacao = new System.Windows.Forms.Button();
            this.btnLocacoesFinalizadas = new System.Windows.Forms.Button();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocacoes)).BeginInit();
            this.SuspendLayout();

            // label1
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Locações Ativas";

            // dgvLocacoes
            this.dgvLocacoes.AllowUserToAddRows = false;
            this.dgvLocacoes.AllowUserToDeleteRows = false;
            this.dgvLocacoes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLocacoes.Location = new System.Drawing.Point(12, 40);
            this.dgvLocacoes.Name = "dgvLocacoes";
            this.dgvLocacoes.ReadOnly = true;
            this.dgvLocacoes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLocacoes.Size = new System.Drawing.Size(900, 350);
            this.dgvLocacoes.TabIndex = 1;

            // btnRegistrarLocacao
            this.btnRegistrarLocacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnRegistrarLocacao.Location = new System.Drawing.Point(12, 405);
            this.btnRegistrarLocacao.Name = "btnRegistrarLocacao";
            this.btnRegistrarLocacao.Size = new System.Drawing.Size(120, 35);
            this.btnRegistrarLocacao.TabIndex = 2;
            this.btnRegistrarLocacao.Text = "Registrar Locação";
            this.btnRegistrarLocacao.UseVisualStyleBackColor = true;
            this.btnRegistrarLocacao.Click += new System.EventHandler(this.btnRegistrarLocacao_Click);

            // btnFinalizarLocacao
            this.btnFinalizarLocacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnFinalizarLocacao.Location = new System.Drawing.Point(140, 405);
            this.btnFinalizarLocacao.Name = "btnFinalizarLocacao";
            this.btnFinalizarLocacao.Size = new System.Drawing.Size(140, 35);
            this.btnFinalizarLocacao.TabIndex = 3;
            this.btnFinalizarLocacao.Text = "Finalizar/Devolver";
            this.btnFinalizarLocacao.UseVisualStyleBackColor = true;
            this.btnFinalizarLocacao.Click += new System.EventHandler(this.btnFinalizarLocacao_Click);

            // btnLocacoesFinalizadas
            this.btnLocacoesFinalizadas.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnLocacoesFinalizadas.Location = new System.Drawing.Point(288, 405);
            this.btnLocacoesFinalizadas.Name = "btnLocacoesFinalizadas";
            this.btnLocacoesFinalizadas.Size = new System.Drawing.Size(140, 35);
            this.btnLocacoesFinalizadas.TabIndex = 4;
            this.btnLocacoesFinalizadas.Text = "Locações Finalizadas";
            this.btnLocacoesFinalizadas.UseVisualStyleBackColor = true;
            this.btnLocacoesFinalizadas.Click += new System.EventHandler(this.btnLocacoesFinalizadas_Click);

            // btnVoltar
            this.btnVoltar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnVoltar.Location = new System.Drawing.Point(812, 405);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(100, 35);
            this.btnVoltar.TabIndex = 5;
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);

            // TelaLocacao
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 461);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.btnLocacoesFinalizadas);
            this.Controls.Add(this.btnFinalizarLocacao);
            this.Controls.Add(this.btnRegistrarLocacao);
            this.Controls.Add(this.dgvLocacoes);
            this.Controls.Add(this.label1);
            this.Name = "TelaLocacao";
            this.Text = "Locação";
            this.Load += new System.EventHandler(this.TelaLocacao_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocacoes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvLocacoes;
        private System.Windows.Forms.Button btnRegistrarLocacao;
        private System.Windows.Forms.Button btnFinalizarLocacao;
        private System.Windows.Forms.Button btnLocacoesFinalizadas;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.Label label1;
    }
}
