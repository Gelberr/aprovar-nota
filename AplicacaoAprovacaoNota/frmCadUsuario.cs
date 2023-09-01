using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UsuarioDll;

namespace AplicacaoAprovacaoNota
{
    public partial class frmCadUsuario : Form
    {
        frmLogin telaLogin;

        usuarioCadastro useCad;

        usuario usuario;

        public frmCadUsuario(frmLogin login)
        {
            InitializeComponent();

            telaLogin = login;
        }

        private void btnCadastrarUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                char papelUse;

                if(cboPapelUsuario.Text.ToUpper() == "VISTO")
                {
                    papelUse = 'V';
                }
                else
                {
                    papelUse = 'A';
                }
                useCad = new usuarioCadastro();

                useCad.Nome_Usuario = txbNome.Text;
                useCad.Email_Usuario = txbEmail.Text;
                useCad.Senha_Usuario = txbSenha.Text;
                useCad.Confirmar_Senha_Usuario = txbConfirmaSenha.Text;
                useCad.Papel_Usuario = papelUse;
                useCad.Quantidade_Minimo_Visto = Convert.ToInt32(txbQuantidadeMinimaVisto.Text);
                useCad.Quantidade_Maximo_Visto = Convert.ToInt32(txbQuantidadeMaximaVisto.Text);
                useCad.Quantidade_Minimo_Aprovacao = Convert.ToInt32(txbQuantidadeMinimaAprovacao.Text);
                useCad.Quantidade_Maximo_Aprovacao = Convert.ToInt32(txbQuantidadeMaximaAprovacao.Text);
                useCad.Status_Usuario = 'A';

                usuario = new usuario();

                if(usuario.IncluirUsuario(useCad))
                {
                    MessageBox.Show("Usuário Cadastrado com sucesso", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Erro",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void frmCadUsuario_Load(object sender, EventArgs e)
        {
            cboPapelUsuario.Items.Add("Visto");
            cboPapelUsuario.Items.Add("Aprovação");
        }

        private void frmCadUsuario_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(useCad != null)
            {
                telaLogin.usuarioModelo = usuario.LogonUsuario(useCad.Email_Usuario, useCad.Senha_Usuario);
            }
        }

        private void cboPapelUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPapelUsuario.Text == "Visto")
            {
                txbQuantidadeMinimaVisto.Enabled = true;
                txbQuantidadeMaximaVisto.Enabled= true;

                txbQuantidadeMinimaAprovacao.Text = "0";
                txbQuantidadeMaximaAprovacao.Text = "0";

                txbQuantidadeMinimaAprovacao.Enabled = false;
                txbQuantidadeMaximaAprovacao.Enabled = false;
            }
            else
            {
                txbQuantidadeMinimaAprovacao.Enabled = true;
                txbQuantidadeMaximaAprovacao.Enabled = true;

                txbQuantidadeMinimaVisto.Text = "0";
                txbQuantidadeMaximaVisto.Text = "0";

                txbQuantidadeMinimaVisto.Enabled = false;
                txbQuantidadeMaximaVisto.Enabled = false;
            }
        }
    }
}
