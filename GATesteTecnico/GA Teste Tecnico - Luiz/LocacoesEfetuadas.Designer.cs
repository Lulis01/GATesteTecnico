namespace GATesteTecnico
{
    partial class LocacoesEfetuadas
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
            this.dgvLocacoesFinalizadas = new System.Windows.Forms.DataGridView();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocacoesFinalizadas)).BeginInit();
            this.SuspendLayout();

            // label1
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(250, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Lista de Locações Efetuadas";

            // dgvLocacoesFinalizadas
            this.dgvLocacoesFinalizadas.AllowUserToAddRows = false;
            this.dgvLocacoesFinalizadas.AllowUserToDeleteRows = false;
            this.dgvLocacoesFinalizadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLocacoesFinalizadas.Location = new System.Drawing.Point(12, 40);
            this.dgvLocacoesFinalizadas.Name = "dgvLocacoesFinalizadas";
            this.dgvLocacoesFinalizadas.ReadOnly = true;
            this.dgvLocacoesFinalizadas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLocacoesFinalizadas.Size = new System.Drawing.Size(900, 350);
            this.dgvLocacoesFinalizadas.TabIndex = 1;

            // btnVoltar
            this.btnVoltar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnVoltar.Location = new System.Drawing.Point(812, 405);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(100, 35);
            this.btnVoltar.TabIndex = 2;
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);

            // LocacoesEfetuadas
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 461);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.dgvLocacoesFinalizadas);
            this.Controls.Add(this.label1);
            this.Name = "LocacoesEfetuadas";
            this.Text = "Locações Efetuadas";
            this.Load += new System.EventHandler(this.LocacoesEfetuadas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocacoesFinalizadas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.DataGridView dgvLocacoesFinalizadas;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.Label label1;
    }
}
