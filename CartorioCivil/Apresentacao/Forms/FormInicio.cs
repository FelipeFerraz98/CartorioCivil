using System;
using System.Windows.Forms;

namespace CartorioCivil.Apresentacao.Forms
{
    public partial class FormInicio : Form
    {
        public FormInicio()
        {
            InitializeComponent();
        }

        private void btnNascimento_Click(object sender, EventArgs e)
        {
            using (var form = new FormNascimento())
            {
                this.Hide();
                form.ShowDialog();
                this.Show();
            }
        }

        private void btnCasamento_Click(object sender, EventArgs e)
        {
            using (var form = new FormCasamento())
            {
                this.Hide();
                form.ShowDialog();
                this.Show();
            }
        }

        private void btnObito_Click(object sender, EventArgs e)
        {
            using (var form = new FormObito())
            {
                this.Hide();
                form.ShowDialog();
                this.Show();
            }
        }
    }
}
