using BLLTCEREDX;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
 


namespace TCEREDX
{
    public partial class ImportarSeq : Form
    {
        public ImportarSeq()
        {
            InitializeComponent();
        }

        private void ImportarSeq_Load(object sender, EventArgs e)
        {
            btnImportar.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            txtNomeArquivo.Text = openFileDialog1.FileName;
            btnImportar.Enabled = true;
        }

        private void txtNomeArquivo_TextChanged(object sender, EventArgs e)
        {
           
        }

      
        private void btnImportar_Click(object sender, EventArgs e)
        {
            Sequencial seq = new Sequencial();
            seq.ImportarSequencial(txtNomeArquivo.Text);
        }
    }
}
