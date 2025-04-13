using System.Data;
using System.Windows.Forms;

namespace CartorioCivil.Apresentacao.Forms
{
    public partial class FormRelNascimento : Form
    {
        public FormRelNascimento(DataTable dt)
        {
            InitializeComponent();

            reportViewer1.LocalReport.ReportEmbeddedResource = "CartorioCivil.Apresentacao.Relatorios.RelNascimento.rdlc";

            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dt));

            reportViewer1.RefreshReport();
        }
    }
}
