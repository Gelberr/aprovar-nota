using ConexaoDll;
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
    public partial class frmLogin : Form
    {
        public usuarioModelo usuarioModelo;

        public frmLogin()
        {
            InitializeComponent();

            usuarioModelo = new usuarioModelo();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            try
            {
                usuario use = new usuario();

                usuarioModelo useModelo = use.LogonUsuario(txbLogin.Text, txbSenha.Text);

                if (useModelo != null)
                {
                    frmPrincipal frmAppPrincipal = new frmPrincipal(useModelo);
                    frmAppPrincipal.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Nenhum usuário inválido ou não cadastrado", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnCadastar_Click(object sender, EventArgs e)
        {
            frmCadUsuario cadUsuario = new frmCadUsuario(this);
            cadUsuario.ShowDialog();

            txbLogin.Text = usuarioModelo.Email_Usuario;
        }

        private void txbLogin_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
