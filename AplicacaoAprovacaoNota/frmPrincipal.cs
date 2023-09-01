using ConexaoDll;
using NotaDll;
using NotaDll.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UsuarioDll;

namespace AplicacaoAprovacaoNota
{
    public partial class frmPrincipal : Form
    {
        private DataGridView dtgNotas;
        private Button btnVistoNota;
        private Button btnAprovarNota;
        private MaskedTextBox mtbDataInicio;
        private MaskedTextBox mtbDataFinal;
        private Label label1;
        private Label label2;
        private GroupBox groupBox1;
        private Button btnFiltrar;
        private MaskedTextBox mtbDataEmissao;
        private ComboBox cboFaixaValorNota;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label lblTotalNota;
        private Label label8;
        private Button btncadastarNota;
        private TextBox txbValorMercadoria;
        private TextBox txbValorDesconto;
        private TextBox txbValorFrete;
        private Button btnListarHistorico;
        usuarioModelo usuarioSistema;

        public frmPrincipal( usuarioModelo useModelo)
        {
            InitializeComponent();

            usuarioSistema = new usuarioModelo();

            usuarioSistema = useModelo;
        }

        private void InitializeComponent()
        {
            this.dtgNotas = new System.Windows.Forms.DataGridView();
            this.btnVistoNota = new System.Windows.Forms.Button();
            this.btnAprovarNota = new System.Windows.Forms.Button();
            this.mtbDataInicio = new System.Windows.Forms.MaskedTextBox();
            this.mtbDataFinal = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.mtbDataEmissao = new System.Windows.Forms.MaskedTextBox();
            this.cboFaixaValorNota = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblTotalNota = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btncadastarNota = new System.Windows.Forms.Button();
            this.txbValorMercadoria = new System.Windows.Forms.TextBox();
            this.txbValorDesconto = new System.Windows.Forms.TextBox();
            this.txbValorFrete = new System.Windows.Forms.TextBox();
            this.btnListarHistorico = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgNotas)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtgNotas
            // 
            this.dtgNotas.AllowUserToAddRows = false;
            this.dtgNotas.AllowUserToDeleteRows = false;
            this.dtgNotas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgNotas.Location = new System.Drawing.Point(12, 276);
            this.dtgNotas.Name = "dtgNotas";
            this.dtgNotas.ReadOnly = true;
            this.dtgNotas.RowHeadersWidth = 51;
            this.dtgNotas.RowTemplate.Height = 24;
            this.dtgNotas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgNotas.Size = new System.Drawing.Size(884, 271);
            this.dtgNotas.TabIndex = 11;
            // 
            // btnVistoNota
            // 
            this.btnVistoNota.Location = new System.Drawing.Point(12, 553);
            this.btnVistoNota.Name = "btnVistoNota";
            this.btnVistoNota.Size = new System.Drawing.Size(229, 31);
            this.btnVistoNota.TabIndex = 9;
            this.btnVistoNota.Text = "Vistoriar Notas Selecionadas";
            this.btnVistoNota.UseVisualStyleBackColor = true;
            this.btnVistoNota.Click += new System.EventHandler(this.btnVistoNota_Click);
            // 
            // btnAprovarNota
            // 
            this.btnAprovarNota.Location = new System.Drawing.Point(359, 553);
            this.btnAprovarNota.Name = "btnAprovarNota";
            this.btnAprovarNota.Size = new System.Drawing.Size(222, 31);
            this.btnAprovarNota.TabIndex = 10;
            this.btnAprovarNota.Text = "Aprovar Nota Selecionada";
            this.btnAprovarNota.UseVisualStyleBackColor = true;
            this.btnAprovarNota.Click += new System.EventHandler(this.btnAprovarNota_Click);
            // 
            // mtbDataInicio
            // 
            this.mtbDataInicio.Location = new System.Drawing.Point(131, 31);
            this.mtbDataInicio.Mask = "##/##/####";
            this.mtbDataInicio.Name = "mtbDataInicio";
            this.mtbDataInicio.Size = new System.Drawing.Size(100, 22);
            this.mtbDataInicio.TabIndex = 6;
            // 
            // mtbDataFinal
            // 
            this.mtbDataFinal.Location = new System.Drawing.Point(341, 31);
            this.mtbDataFinal.Mask = "##/##/####";
            this.mtbDataFinal.Name = "mtbDataFinal";
            this.mtbDataFinal.Size = new System.Drawing.Size(100, 22);
            this.mtbDataFinal.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Data Início";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(267, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Data Final";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.btnFiltrar);
            this.groupBox1.Controls.Add(this.mtbDataFinal);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.mtbDataInicio);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 199);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(884, 71);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtro";
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Location = new System.Drawing.Point(497, 31);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(133, 26);
            this.btnFiltrar.TabIndex = 8;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = true;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // mtbDataEmissao
            // 
            this.mtbDataEmissao.Location = new System.Drawing.Point(12, 42);
            this.mtbDataEmissao.Mask = "00/00/0000";
            this.mtbDataEmissao.Name = "mtbDataEmissao";
            this.mtbDataEmissao.Size = new System.Drawing.Size(100, 22);
            this.mtbDataEmissao.TabIndex = 0;
            this.mtbDataEmissao.ValidatingType = typeof(System.DateTime);
            // 
            // cboFaixaValorNota
            // 
            this.cboFaixaValorNota.FormattingEnabled = true;
            this.cboFaixaValorNota.Location = new System.Drawing.Point(12, 140);
            this.cboFaixaValorNota.Name = "cboFaixaValorNota";
            this.cboFaixaValorNota.Size = new System.Drawing.Size(380, 24);
            this.cboFaixaValorNota.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(162, 16);
            this.label3.TabIndex = 13;
            this.label3.Text = "Data da Emissão da Nota";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 16);
            this.label4.TabIndex = 14;
            this.label4.Text = "Valor da Mercadoria";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(213, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(170, 16);
            this.label5.TabIndex = 15;
            this.label5.Text = "Valor do Desconto da Nota";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(417, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 16);
            this.label6.TabIndex = 16;
            this.label6.Text = "Valor do Frete";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(621, 73);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(124, 16);
            this.label7.TabIndex = 17;
            this.label7.Text = "Valor Total da Nota";
            // 
            // lblTotalNota
            // 
            this.lblTotalNota.BackColor = System.Drawing.SystemColors.Control;
            this.lblTotalNota.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotalNota.Location = new System.Drawing.Point(624, 96);
            this.lblTotalNota.Name = "lblTotalNota";
            this.lblTotalNota.Size = new System.Drawing.Size(198, 22);
            this.lblTotalNota.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 121);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(145, 16);
            this.label8.TabIndex = 19;
            this.label8.Text = "Faixa de Valor da Nota";
            // 
            // btncadastarNota
            // 
            this.btncadastarNota.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncadastarNota.Location = new System.Drawing.Point(457, 133);
            this.btncadastarNota.Name = "btncadastarNota";
            this.btncadastarNota.Size = new System.Drawing.Size(167, 37);
            this.btncadastarNota.TabIndex = 5;
            this.btncadastarNota.Text = "Cadastrar Nota";
            this.btncadastarNota.UseVisualStyleBackColor = true;
            this.btncadastarNota.Click += new System.EventHandler(this.btncadastarNota_Click);
            // 
            // txbValorMercadoria
            // 
            this.txbValorMercadoria.Location = new System.Drawing.Point(12, 96);
            this.txbValorMercadoria.Name = "txbValorMercadoria";
            this.txbValorMercadoria.Size = new System.Drawing.Size(198, 22);
            this.txbValorMercadoria.TabIndex = 1;
            this.txbValorMercadoria.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbValorMercadoria_KeyPress);
            this.txbValorMercadoria.Leave += new System.EventHandler(this.txbValorMercadoria_Leave);
            // 
            // txbValorDesconto
            // 
            this.txbValorDesconto.Location = new System.Drawing.Point(216, 96);
            this.txbValorDesconto.Name = "txbValorDesconto";
            this.txbValorDesconto.Size = new System.Drawing.Size(198, 22);
            this.txbValorDesconto.TabIndex = 2;
            this.txbValorDesconto.Text = "0";
            this.txbValorDesconto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbValorDesconto_KeyPress);
            this.txbValorDesconto.Leave += new System.EventHandler(this.txbValorDesconto_Leave);
            // 
            // txbValorFrete
            // 
            this.txbValorFrete.Location = new System.Drawing.Point(420, 96);
            this.txbValorFrete.Name = "txbValorFrete";
            this.txbValorFrete.Size = new System.Drawing.Size(198, 22);
            this.txbValorFrete.TabIndex = 3;
            this.txbValorFrete.Text = "0";
            this.txbValorFrete.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValorFrete_KeyPress);
            this.txbValorFrete.Leave += new System.EventHandler(this.txtValorFrete_Leave);
            // 
            // btnListarHistorico
            // 
            this.btnListarHistorico.Location = new System.Drawing.Point(674, 553);
            this.btnListarHistorico.Name = "btnListarHistorico";
            this.btnListarHistorico.Size = new System.Drawing.Size(222, 31);
            this.btnListarHistorico.TabIndex = 20;
            this.btnListarHistorico.Text = "Listar Histórico";
            this.btnListarHistorico.UseVisualStyleBackColor = true;
            this.btnListarHistorico.Click += new System.EventHandler(this.btnListarHistorico_Click);
            // 
            // frmPrincipal
            // 
            this.ClientSize = new System.Drawing.Size(908, 637);
            this.Controls.Add(this.btnListarHistorico);
            this.Controls.Add(this.txbValorFrete);
            this.Controls.Add(this.txbValorDesconto);
            this.Controls.Add(this.txbValorMercadoria);
            this.Controls.Add(this.btncadastarNota);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblTotalNota);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboFaixaValorNota);
            this.Controls.Add(this.mtbDataEmissao);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnAprovarNota);
            this.Controls.Add(this.btnVistoNota);
            this.Controls.Add(this.dtgNotas);
            this.Name = "frmPrincipal";
            this.Text = "Sistema de Aprovação de Nota";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmPrincipal_FormClosed);
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.Shown += new System.EventHandler(this.frmPrincipal_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dtgNotas)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            if(usuarioSistema.Papel_Usuario == 'V')
            {
                btnVistoNota.Enabled = true;
                btnAprovarNota.Enabled = false;
            }
            else if (usuarioSistema.Papel_Usuario == 'A')
            {
                btnVistoNota.Enabled = false;
                btnAprovarNota.Enabled = true;
            }

            carregaComboFaixaValor();
        }

        private void frmPrincipal_Shown(object sender, EventArgs e)
        {

            carregaGridNota();
        }

        private void btnVistoNota_Click(object sender, EventArgs e)
        {
            

            try
            {
                nota n = new nota();
                DataTable t = new DataTable();
                cadastrarHistorico cadHist = new cadastrarHistorico();
                List<historicoModelo> histModelo = new List<historicoModelo>();
                configuracaoFaixaObter obterFaixConfig = new configuracaoFaixaObter();
                obterNota obterNota = new obterNota();

                int countHist = 0;
                int idUseHist = 0;
                int idNota = 0;

                //-------------------------------------------------------------------

                if (dtgNotas.RowCount <= 0)
                {
                    MessageBox.Show("Nenhuma nota selecionada", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                idNota = Convert.ToInt32(dtgNotas.SelectedRows[0].Cells[0].Value);
                
                histModelo = n.ObterListaHistoricoPorIdNota(idNota);

                obterFaixConfig = n.ObterConfiguracaoFaixaPorIdNota(idNota);

                obterNota = n.ObterNotaPorIdNota(idNota);

                if(obterNota.Valor_Total_Nota <= 1000)
                {
                    if (histModelo != null && histModelo.Count > 0)
                    {
                        for (int i = 0; i < histModelo.Count; i++)
                        {
                            if (histModelo[i].Quantidade_Visto_Historico != 0)
                            {
                                MessageBox.Show("Nota já vistoriada e aprovada.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                    }

                    if (obterNota.Quantidade_Visto_Nota == 0 && obterNota.Quantidade_Aprovacao_Nota == 0)
                    {

                        cadHist.Data_Historico = DateTime.Now;
                        cadHist.Id_Usuario_Historico = usuarioSistema.Id_Usuario;
                        cadHist.Operacao_Historico = "Visto";
                        cadHist.Id_Nota_Historico = idNota;
                        cadHist.Quantidade_Visto_Historico = 1;
                        cadHist.Quantidade_Aprovacao_Historico = 0;
                        cadHist.Id_Configuracao_Faixa_Valor_Historico = obterNota.Id_Configuracao_Faixa_Valor_Nota;

                        if (n.CadastarNotaHistorico(cadHist))
                        {
                            if (n.VistoNotaAprovacao(idNota, 1))
                            {
                                t = n.CarregaDadosGridNota();

                                dtgNotas.DataSource = t;
                                dtgNotas.Refresh();

                                MessageBox.Show("Nota vistoriada e aprovada com sucesso", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }

                        
                    }

                }
                else if (obterNota.Valor_Total_Nota > 1000 && obterNota.Valor_Total_Nota <= 10000)
                {

                    if (histModelo != null && histModelo.Count > 0)
                    {
                        for (int i = 0; i < histModelo.Count; i++)
                        {
                            if (histModelo[i].Quantidade_Visto_Historico != 0)
                            {
                                MessageBox.Show("Nota já vistoriada e aguardando aprovação.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                    }

                    if (obterNota.Quantidade_Visto_Nota < 1)
                    {

                        cadHist.Data_Historico = DateTime.Now;
                        cadHist.Id_Usuario_Historico = usuarioSistema.Id_Usuario;
                        cadHist.Operacao_Historico = "Visto";
                        cadHist.Id_Nota_Historico = idNota;
                        cadHist.Quantidade_Visto_Historico = 1;
                        cadHist.Quantidade_Aprovacao_Historico = 0;
                        cadHist.Id_Configuracao_Faixa_Valor_Historico = obterNota.Id_Configuracao_Faixa_Valor_Nota;

                        if (n.CadastarNotaHistorico(cadHist))
                        {
                            if (n.VistoNota(idNota, 1))
                            {
                                t = n.CarregaDadosGridNota();

                                dtgNotas.DataSource = t;
                                dtgNotas.Refresh();

                                MessageBox.Show("Nota vistoriada com sucesso", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }

                }
                else if (obterNota.Valor_Total_Nota > 10000 && obterNota.Valor_Total_Nota <= 50000)
                {


                    if (histModelo != null && histModelo.Count > 0)
                    {
                        for (int i = 0; i < histModelo.Count; i++)
                        {
                            if (histModelo[i].Quantidade_Visto_Historico != 0)
                            {
                                countHist++;
                                idUseHist = histModelo[i].Id_Usuario_Historico;
                            }
                        }
                    }

                    if(countHist == 2)
                    {
                        MessageBox.Show("Nota já vistoriada e aguardando aprovação.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else if (countHist == 1)
                    {
                        if(usuarioSistema.Id_Usuario == idUseHist)
                        {
                            MessageBox.Show("Usuário sem permissão de visto por já te dado na nota.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }

                    if (obterNota.Quantidade_Visto_Nota == 0)
                    {
                        cadHist.Data_Historico = DateTime.Now;
                        cadHist.Id_Usuario_Historico = usuarioSistema.Id_Usuario;
                        cadHist.Operacao_Historico = "Visto";
                        cadHist.Id_Nota_Historico = idNota;
                        cadHist.Quantidade_Visto_Historico = 1;
                        cadHist.Quantidade_Aprovacao_Historico = 0;
                        cadHist.Id_Configuracao_Faixa_Valor_Historico = obterNota.Id_Configuracao_Faixa_Valor_Nota;

                        if (n.CadastarNotaHistorico(cadHist))
                        {
                            if (n.VistoNota(idNota, 1))
                            {
                                t = n.CarregaDadosGridNota();

                                dtgNotas.DataSource = t;
                                dtgNotas.Refresh();

                                MessageBox.Show("Nota vistoriada com sucesso", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    else if (obterNota.Quantidade_Visto_Nota > 0 && obterNota.Quantidade_Visto_Nota < 2)
                    {

                        cadHist.Data_Historico = DateTime.Now;
                        cadHist.Id_Usuario_Historico = usuarioSistema.Id_Usuario;
                        cadHist.Operacao_Historico = "Visto";
                        cadHist.Id_Nota_Historico = idNota;
                        cadHist.Quantidade_Visto_Historico = 1;
                        cadHist.Quantidade_Aprovacao_Historico = 0;
                        cadHist.Id_Configuracao_Faixa_Valor_Historico = obterNota.Id_Configuracao_Faixa_Valor_Nota;

                        if (n.CadastarNotaHistorico(cadHist))
                        {
                            if (n.VistoNota(idNota, 2))
                            {
                                t = n.CarregaDadosGridNota();

                                dtgNotas.DataSource = t;
                                dtgNotas.Refresh();

                                MessageBox.Show("Nota vistoriada com sucesso", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
                else if (obterNota.Valor_Total_Nota > 50000 && obterNota.Valor_Total_Nota <= 999999.99)
                {
                    if (histModelo != null && histModelo.Count > 0)
                    {
                        for (int i = 0; i < histModelo.Count; i++)
                        {
                            if (histModelo[i].Quantidade_Visto_Historico != 0)
                            {
                                countHist++;
                                idUseHist = histModelo[i].Id_Usuario_Historico;
                            }
                        }
                    }

                    if (countHist == 2)
                    {
                        MessageBox.Show("Nota já vistoriada e aguardando aprovação.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else if (countHist == 1)
                    {
                        if (usuarioSistema.Id_Usuario == idUseHist)
                        {
                            MessageBox.Show("Usuário sem permissão de visto por já te dado na nota.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }

                    if (obterNota.Quantidade_Visto_Nota == 0)
                    {

                        cadHist.Data_Historico = DateTime.Now;
                        cadHist.Id_Usuario_Historico = usuarioSistema.Id_Usuario;
                        cadHist.Operacao_Historico = "Visto";
                        cadHist.Id_Nota_Historico = idNota;
                        cadHist.Quantidade_Visto_Historico = 1;
                        cadHist.Quantidade_Aprovacao_Historico = 0;
                        cadHist.Id_Configuracao_Faixa_Valor_Historico = obterNota.Id_Configuracao_Faixa_Valor_Nota;

                        if (n.CadastarNotaHistorico(cadHist))
                        {
                            if (n.VistoNota(idNota, 1))
                            {
                                t = n.CarregaDadosGridNota();

                                dtgNotas.DataSource = t;
                                dtgNotas.Refresh();

                                MessageBox.Show("Nota vistoriada com sucesso", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    else if (obterNota.Quantidade_Visto_Nota > 0 && obterNota.Quantidade_Visto_Nota < 2)
                    {
                        cadHist.Data_Historico = DateTime.Now;
                        cadHist.Id_Usuario_Historico = usuarioSistema.Id_Usuario;
                        cadHist.Operacao_Historico = "Visto";
                        cadHist.Id_Nota_Historico = idNota;
                        cadHist.Quantidade_Visto_Historico = 1;
                        cadHist.Quantidade_Aprovacao_Historico = 0;
                        cadHist.Id_Configuracao_Faixa_Valor_Historico = obterNota.Id_Configuracao_Faixa_Valor_Nota;

                        if (n.CadastarNotaHistorico(cadHist))
                        {
                            if (n.VistoNota(idNota, 2))
                            {
                                t = n.CarregaDadosGridNota();

                                dtgNotas.DataSource = t;
                                dtgNotas.Refresh();

                                MessageBox.Show("Nota vistoriada com sucesso", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult dialog = new DialogResult();

            dialog = MessageBox.Show("Quer mesmo sair?", "Alert!", MessageBoxButtons.YesNo);

            if (dialog == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            try
            {
                if(mtbDataInicio.Text == "  /  /")
                {
                    MessageBox.Show("Data início inválida", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (mtbDataFinal.Text == "  /  /")
                {
                    MessageBox.Show("Data final inválida", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                nota n = new nota();
                DataTable t = new DataTable();

                if (usuarioSistema.Papel_Usuario == 'V')
                {
                    t = n.CarregaDadosGridNotaFiltroData(mtbDataInicio.Text, mtbDataFinal.Text);

                    dtgNotas.DataSource = t;
                }
                else if (usuarioSistema.Papel_Usuario == 'A')
                {
                    t = n.CarregaDadosGridNotaAprovacaoFiltroData(mtbDataInicio.Text, mtbDataFinal.Text);

                    dtgNotas.DataSource = t;
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAprovarNota_Click(object sender, EventArgs e)
        {

            try
            {
                nota n = new nota();
                DataTable t = new DataTable();
                cadastrarHistorico cadHist = new cadastrarHistorico();
                List<historicoModelo> histModelo = new List<historicoModelo>();
                configuracaoFaixaObter obterFaixConfig = new configuracaoFaixaObter();
                obterNota obterNota = new obterNota();

                int countHist = 0;
                int idUseHist = 0;
                int idNota = 0;

                //-------------------------------------------------------------------

                if(dtgNotas.RowCount <= 0)
                {
                    MessageBox.Show("Nenhuma nota selecionada", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }


                idNota = Convert.ToInt32(dtgNotas.SelectedRows[0].Cells[0].Value);

                histModelo = n.ObterListaHistoricoPorIdNota(idNota);

                obterFaixConfig = n.ObterConfiguracaoFaixaPorIdNota(idNota);

                obterNota = n.ObterNotaPorIdNota(idNota);

                if (obterNota.Valor_Total_Nota > 1000 && obterNota.Valor_Total_Nota <= 10000)
                {

                    if (histModelo != null && histModelo.Count > 0)
                    {
                        for (int i = 0; i < histModelo.Count; i++)
                        {
                            if (histModelo[i].Quantidade_Visto_Historico == 1 && histModelo[i].Quantidade_Aprovacao_Historico == 1)
                            {
                                MessageBox.Show("Nota já aprovação.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                    }

                    if (obterNota.Quantidade_Visto_Nota == 1 && obterNota.Quantidade_Aprovacao_Nota == 0)
                    {

                        cadHist.Data_Historico = DateTime.Now;
                        cadHist.Id_Usuario_Historico = usuarioSistema.Id_Usuario;
                        cadHist.Operacao_Historico = "Aprovação";
                        cadHist.Id_Nota_Historico = idNota;
                        cadHist.Quantidade_Visto_Historico = 0;
                        cadHist.Quantidade_Aprovacao_Historico = 1;
                        cadHist.Id_Configuracao_Faixa_Valor_Historico = obterNota.Id_Configuracao_Faixa_Valor_Nota;

                        if (n.CadastarNotaHistorico(cadHist))
                        {
                            if (n.AprovacaoNotaDefinitiva(idNota, 1))
                            {
                                t = n.CarregaDadosGridNotaAprovacao();

                                dtgNotas.DataSource = t;
                                dtgNotas.Refresh();

                                MessageBox.Show("Nota aprovada com sucesso", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }

                }
                else if (obterNota.Valor_Total_Nota > 10000 && obterNota.Valor_Total_Nota <= 50000)
                {
                    if (obterNota.Quantidade_Visto_Nota == 2 && obterNota.Quantidade_Aprovacao_Nota == 0)
                    {
                        cadHist.Data_Historico = DateTime.Now;
                        cadHist.Id_Usuario_Historico = usuarioSistema.Id_Usuario;
                        cadHist.Operacao_Historico = "Aprovação";
                        cadHist.Id_Nota_Historico = idNota;
                        cadHist.Quantidade_Visto_Historico = 0;
                        cadHist.Quantidade_Aprovacao_Historico = 1;
                        cadHist.Id_Configuracao_Faixa_Valor_Historico = obterNota.Id_Configuracao_Faixa_Valor_Nota;

                        if (n.CadastarNotaHistorico(cadHist))
                        {
                            if (n.AprovacaoNotaDefinitiva(idNota, 1))
                            {
                                t = n.CarregaDadosGridNotaAprovacao();

                                dtgNotas.DataSource = t;
                                dtgNotas.Refresh();

                                MessageBox.Show("Nota aprovada com sucesso", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    
                }
                else if (obterNota.Valor_Total_Nota > 50000 && obterNota.Valor_Total_Nota <= 999999.99)
                {
                    if (histModelo != null && histModelo.Count > 0)
                    {
                        for (int i = 0; i < histModelo.Count; i++)
                        {
                            if (histModelo[i].Quantidade_Aprovacao_Historico != 0)
                            {
                                countHist++;
                                idUseHist = histModelo[i].Id_Usuario_Historico;
                            }
                        }
                    }

                    if (countHist == 2)
                    {
                        MessageBox.Show("Nota já aprovada.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else if (countHist == 1)
                    {
                        if (usuarioSistema.Id_Usuario == idUseHist)
                        {
                            MessageBox.Show("Usuário sem permissão de aprovar nota por já te dado na nota.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }

                    if (obterNota.Quantidade_Visto_Nota == 2 && obterNota.Quantidade_Aprovacao_Nota == 0)
                    {

                        cadHist.Data_Historico = DateTime.Now;
                        cadHist.Id_Usuario_Historico = usuarioSistema.Id_Usuario;
                        cadHist.Operacao_Historico = "Aprovação";
                        cadHist.Id_Nota_Historico = idNota;
                        cadHist.Quantidade_Visto_Historico = 0;
                        cadHist.Quantidade_Aprovacao_Historico = 1;
                        cadHist.Id_Configuracao_Faixa_Valor_Historico = obterNota.Id_Configuracao_Faixa_Valor_Nota;

                        if (n.CadastarNotaHistorico(cadHist))
                        {
                            if (n.AprovacaoNota(idNota, 1))
                            {
                                t = n.CarregaDadosGridNotaAprovacao();

                                dtgNotas.DataSource = t;
                                dtgNotas.Refresh();

                                MessageBox.Show("Nota aprovada com sucesso", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    else if (obterNota.Quantidade_Visto_Nota == 2 && (obterNota.Quantidade_Aprovacao_Nota >0 && obterNota.Quantidade_Aprovacao_Nota < 2))
                    {
                        cadHist.Data_Historico = DateTime.Now;
                        cadHist.Id_Usuario_Historico = usuarioSistema.Id_Usuario;
                        cadHist.Operacao_Historico = "Aprovação";
                        cadHist.Id_Nota_Historico = idNota;
                        cadHist.Quantidade_Visto_Historico = 0;
                        cadHist.Quantidade_Aprovacao_Historico = 1;
                        cadHist.Id_Configuracao_Faixa_Valor_Historico = obterNota.Id_Configuracao_Faixa_Valor_Nota;

                        if (n.CadastarNotaHistorico(cadHist))
                        {
                            if (n.AprovacaoNotaDefinitiva(idNota, 2))
                            {
                                t = n.CarregaDadosGridNotaAprovacao();

                                dtgNotas.DataSource = t;
                                dtgNotas.Refresh();

                                MessageBox.Show("Nota aprovada com sucesso", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txbValorMercadoria_Leave(object sender, EventArgs e)
        {
            var num = Convert.ToDecimal(txbValorMercadoria.Text);
            txbValorMercadoria.Text = num.ToString("N2");

            lblTotalNota.Text = txbValorMercadoria.Text;
        }

        private void txbValorMercadoria_KeyPress(object sender, KeyPressEventArgs e)
        {
            Program.soNumero(sender, e);
        }

        private void txbValorMercadoria_TextChanged(object sender, EventArgs e)
        {

        }

        private void txbValorDesconto_Leave(object sender, EventArgs e)
        {
            decimal num = 0;

            if(txbValorDesconto.Text != "")
            {
                num = Convert.ToDecimal(txbValorDesconto.Text);
            }

            txbValorDesconto.Text = num.ToString("N2");

            decimal total = 0;

            if (txbValorMercadoria.Text != "" & txbValorDesconto.Text != "" && txbValorFrete.Text != "")
            {
                total = Convert.ToDecimal(txbValorMercadoria.Text) - Convert.ToDecimal(txbValorDesconto.Text) + Convert.ToDecimal(txbValorFrete.Text);
            }
            else if (txbValorMercadoria.Text != "" & txbValorDesconto.Text == "" && txbValorFrete.Text != "")
            {
                total = Convert.ToDecimal(txbValorMercadoria.Text) + Convert.ToDecimal(txbValorFrete.Text);
            }
            else if (txbValorMercadoria.Text != "" & txbValorDesconto.Text == "" && txbValorFrete.Text == "")
            {
                total = Convert.ToDecimal(txbValorMercadoria.Text);
            }

            lblTotalNota.Text = total.ToString("N2");
        }

        private void txtValorFrete_Leave(object sender, EventArgs e)
        {
            decimal num = 0;

            if (txbValorFrete.Text != "")
            {
                num = Convert.ToDecimal(txbValorFrete.Text);
            }
            txbValorFrete.Text = num.ToString("N2");

            decimal total = 0;

            if (txbValorMercadoria.Text != "" & txbValorDesconto.Text != "" && txbValorFrete.Text != "")
            {
                total = Convert.ToDecimal(txbValorMercadoria.Text) - Convert.ToDecimal(txbValorDesconto.Text) + Convert.ToDecimal(txbValorFrete.Text);
            }
            else if (txbValorMercadoria.Text != "" & txbValorDesconto.Text == "" && txbValorFrete.Text != "")
            {
                total = Convert.ToDecimal(txbValorMercadoria.Text) + Convert.ToDecimal(txbValorFrete.Text);
            }
            else if (txbValorMercadoria.Text != "" & txbValorDesconto.Text == "" && txbValorFrete.Text == "")
            {
                total = Convert.ToDecimal(txbValorMercadoria.Text);
            }

            lblTotalNota.Text = total.ToString("N2");
        }

        private void txbValorDesconto_KeyPress(object sender, KeyPressEventArgs e)
        {
            Program.soNumero(sender, e);
        }

        private void txtValorFrete_KeyPress(object sender, KeyPressEventArgs e)
        {
            Program.soNumero(sender, e);
        }

        private void btncadastarNota_Click(object sender, EventArgs e)
        {
            cadastrarNota();

            carregaGridNota();
        }

        private void carregaGridNota()
        {
            try
            {
                nota n = new nota();
                DataTable t = new DataTable();

                if (usuarioSistema.Papel_Usuario == 'V')
                {
                    t = n.CarregaDadosGridNota();

                    dtgNotas.DataSource = t;
                }
                else if (usuarioSistema.Papel_Usuario == 'A')
                {
                    t = n.CarregaDadosGridNotaAprovacao();

                    dtgNotas.DataSource = t;
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void carregaComboFaixaValor()
        {
            conexao _conn = new conexao();

            try
            {
                
                DataTable dt = new DataTable();

                string query = string.Format(@" 
                SELECT 
                    Id_Configuracao,
	                Descricao_Configuracao 
                from 
                    configuracao_faixa_valor
                order by 
                    Id_Configuracao");

                _conn.Open();

                SqlDataReader dataReader = _conn.ExecuteReader(query);

                if (dataReader != null)
                {
                    dt.Load(dataReader);

                    if (dt.Rows.Count > 0)
                    {
                        DataRow dr = dt.NewRow();

                        dr["Descricao_Configuracao"] = "";

                        dt.Rows.InsertAt(dr, 0);

                        this.cboFaixaValorNota.DataSource = dt;
                        this.cboFaixaValorNota.ValueMember = "Id_Configuracao";
                        this.cboFaixaValorNota.DisplayMember = "Descricao_Configuracao";

                    }
                }

                dataReader.Close();
                dataReader.Dispose();

                /*
                nota n = new nota();

                this.cboFaixaValorNota = n.carregarComboFaixaValor();
                */
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _conn.Close();
                _conn.Dispose();
            }
        }

        private void cadastrarNota()
        {
            try
            {
                cadastrarNota cadNota = new cadastrarNota();

                cadNota.Data_Emissao_Nota = Convert.ToDateTime(mtbDataEmissao.Text);
                cadNota.Valor_Mercadoria_Nota = Convert.ToDouble(txbValorMercadoria.Text);
                cadNota.Valor_Desconto_Nota = Convert.ToDouble(txbValorDesconto.Text);
                cadNota.Valor_Frete_Nota = Convert.ToDouble(txbValorFrete.Text);
                cadNota.Valor_Total_Nota = Convert.ToDouble(lblTotalNota.Text);
                cadNota.Id_Configuracao_Faixa_Valor_Nota = Convert.ToInt32(cboFaixaValorNota.SelectedValue);
                cadNota.Quantidade_Visto_Nota = 0;
                cadNota.Quantidade_Aprovacao_Nota = 0;
                cadNota.Status_Nota = 'P';

                nota n = new nota();

                if (n.IncluirNota(cadNota))
                {
                    MessageBox.Show("Nota Cadastrado com sucesso", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnListarHistorico_Click(object sender, EventArgs e)
        {
            frmHistorico listarHis = new frmHistorico();
            listarHis.ShowDialog();
        }
    }
}
