namespace AplicacaoAprovacaoNota
{
    partial class frmCadUsuario
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txbNome = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txbEmail = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txbSenha = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txbConfirmaSenha = new System.Windows.Forms.TextBox();
            this.btnCadastrarUsuario = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txbQuantidadeMinimaVisto = new System.Windows.Forms.TextBox();
            this.txbQuantidadeMaximaVisto = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txbQuantidadeMinimaAprovacao = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txbQuantidadeMaximaAprovacao = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cboPapelUsuario = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome";
            // 
            // txbNome
            // 
            this.txbNome.Location = new System.Drawing.Point(72, 37);
            this.txbNome.Name = "txbNome";
            this.txbNome.Size = new System.Drawing.Size(481, 22);
            this.txbNome.TabIndex = 0;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(27, 65);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(41, 16);
            this.lblEmail.TabIndex = 2;
            this.lblEmail.Text = "Email";
            // 
            // txbEmail
            // 
            this.txbEmail.Location = new System.Drawing.Point(72, 65);
            this.txbEmail.Name = "txbEmail";
            this.txbEmail.Size = new System.Drawing.Size(481, 22);
            this.txbEmail.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Senha";
            // 
            // txbSenha
            // 
            this.txbSenha.Location = new System.Drawing.Point(72, 93);
            this.txbSenha.Name = "txbSenha";
            this.txbSenha.PasswordChar = '*';
            this.txbSenha.Size = new System.Drawing.Size(100, 22);
            this.txbSenha.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(200, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Confirma Senha";
            // 
            // txbConfirmaSenha
            // 
            this.txbConfirmaSenha.Location = new System.Drawing.Point(306, 93);
            this.txbConfirmaSenha.Name = "txbConfirmaSenha";
            this.txbConfirmaSenha.PasswordChar = '*';
            this.txbConfirmaSenha.Size = new System.Drawing.Size(100, 22);
            this.txbConfirmaSenha.TabIndex = 3;
            // 
            // btnCadastrarUsuario
            // 
            this.btnCadastrarUsuario.Location = new System.Drawing.Point(212, 221);
            this.btnCadastrarUsuario.Name = "btnCadastrarUsuario";
            this.btnCadastrarUsuario.Size = new System.Drawing.Size(149, 31);
            this.btnCadastrarUsuario.TabIndex = 9;
            this.btnCadastrarUsuario.Text = "Cadastrar";
            this.btnCadastrarUsuario.UseVisualStyleBackColor = true;
            this.btnCadastrarUsuario.Click += new System.EventHandler(this.btnCadastrarUsuario_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Papel Usuário";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 160);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(175, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "Quantidade Minima de Visto";
            // 
            // txbQuantidadeMinimaVisto
            // 
            this.txbQuantidadeMinimaVisto.Location = new System.Drawing.Point(212, 157);
            this.txbQuantidadeMinimaVisto.MaxLength = 3;
            this.txbQuantidadeMinimaVisto.Name = "txbQuantidadeMinimaVisto";
            this.txbQuantidadeMinimaVisto.Size = new System.Drawing.Size(53, 22);
            this.txbQuantidadeMinimaVisto.TabIndex = 5;
            // 
            // txbQuantidadeMaximaVisto
            // 
            this.txbQuantidadeMaximaVisto.Location = new System.Drawing.Point(212, 182);
            this.txbQuantidadeMaximaVisto.MaxLength = 3;
            this.txbQuantidadeMaximaVisto.Name = "txbQuantidadeMaximaVisto";
            this.txbQuantidadeMaximaVisto.Size = new System.Drawing.Size(53, 22);
            this.txbQuantidadeMaximaVisto.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(27, 185);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(179, 16);
            this.label6.TabIndex = 11;
            this.label6.Text = "Quantidade Máxima de Visto";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // txbQuantidadeMinimaAprovacao
            // 
            this.txbQuantidadeMinimaAprovacao.Location = new System.Drawing.Point(500, 157);
            this.txbQuantidadeMinimaAprovacao.MaxLength = 3;
            this.txbQuantidadeMinimaAprovacao.Name = "txbQuantidadeMinimaAprovacao";
            this.txbQuantidadeMinimaAprovacao.Size = new System.Drawing.Size(53, 22);
            this.txbQuantidadeMinimaAprovacao.TabIndex = 7;
            this.txbQuantidadeMinimaAprovacao.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(278, 157);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(212, 16);
            this.label7.TabIndex = 13;
            this.label7.Text = "Quantidade Minima de Aprovação";
            // 
            // txbQuantidadeMaximaAprovacao
            // 
            this.txbQuantidadeMaximaAprovacao.Location = new System.Drawing.Point(500, 185);
            this.txbQuantidadeMaximaAprovacao.MaxLength = 3;
            this.txbQuantidadeMaximaAprovacao.Name = "txbQuantidadeMaximaAprovacao";
            this.txbQuantidadeMaximaAprovacao.Size = new System.Drawing.Size(53, 22);
            this.txbQuantidadeMaximaAprovacao.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(278, 185);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(216, 16);
            this.label8.TabIndex = 15;
            this.label8.Text = "Quantidade Máxima de Aprovação";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(253, 124);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(176, 16);
            this.label9.TabIndex = 16;
            this.label9.Text = "Ex.: V - Visto / A - Aprovação";
            // 
            // cboPapelUsuario
            // 
            this.cboPapelUsuario.FormattingEnabled = true;
            this.cboPapelUsuario.Location = new System.Drawing.Point(126, 121);
            this.cboPapelUsuario.Name = "cboPapelUsuario";
            this.cboPapelUsuario.Size = new System.Drawing.Size(121, 24);
            this.cboPapelUsuario.TabIndex = 4;
            this.cboPapelUsuario.SelectedIndexChanged += new System.EventHandler(this.cboPapelUsuario_SelectedIndexChanged);
            // 
            // frmCadUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 280);
            this.Controls.Add(this.cboPapelUsuario);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txbQuantidadeMaximaAprovacao);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txbQuantidadeMinimaAprovacao);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txbQuantidadeMaximaVisto);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txbQuantidadeMinimaVisto);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCadastrarUsuario);
            this.Controls.Add(this.txbConfirmaSenha);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txbSenha);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txbEmail);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txbNome);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCadUsuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastrar Usuario";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmCadUsuario_FormClosed);
            this.Load += new System.EventHandler(this.frmCadUsuario_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbNome;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txbEmail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txbSenha;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txbConfirmaSenha;
        private System.Windows.Forms.Button btnCadastrarUsuario;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txbQuantidadeMinimaVisto;
        private System.Windows.Forms.TextBox txbQuantidadeMaximaVisto;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txbQuantidadeMinimaAprovacao;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txbQuantidadeMaximaAprovacao;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboPapelUsuario;
    }
}