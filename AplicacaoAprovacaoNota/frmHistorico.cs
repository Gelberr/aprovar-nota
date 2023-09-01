using NotaDll;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AplicacaoAprovacaoNota
{
    public partial class frmHistorico : Form
    {
        public frmHistorico()
        {
            InitializeComponent();
        }

        private void frmHistorico_Load(object sender, EventArgs e)
        {
            carregaGridNota();
        }

        private void carregaGridNota()
        {
            try
            {
                nota n = new nota();
                DataTable t = new DataTable();

                t = n.CarregaDadosGridHistorico();

                dtgHistorico.DataSource = t;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (mtbDataInicio.Text == "  /  /")
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

                t = n.CarregaDadosGridHistoricoFiltroData(mtbDataInicio.Text, mtbDataFinal.Text);

                dtgHistorico.DataSource = t;


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
