using MatchSimDalLibrary.Competencia;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MatchSimDalWindows
{
    public partial class MatchCupForm : Form
    {
        public MatchCupForm()
        {
            InitializeComponent();
        }

        private void btnCupResult_Click(object sender, EventArgs e)
        {
            short catLocal = (short)spinLocal.Value;
            short catVisitante = (short)spinVisitante.Value;

            short cmbResultLocal = (short)cmbLocal.SelectedIndex;
            short cmbResultVisitante = (short)cmbVisitante.SelectedIndex;

            bool haceFalta = cmbResultLocal == -1 || cmbResultVisitante == -1;

            if (haceFalta)
                MessageBox.Show("No están completos los datos del nivel de los rivales", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            else
            {
                string resultado = Copa.Partido(catLocal, cmbResultLocal, catVisitante, cmbResultVisitante);
                MessageBox.Show(resultado, "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
