using MatchSimDalLibrary;
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
    public partial class MatchStandardForm : Form
    {
        public MatchStandardForm()
        {
            InitializeComponent();
        }

        public MatchStandardForm(bool neutral)
        {
            InitializeComponent();
            lbNeutral.Text = neutral.ToString();
        }

        private void btnStdResult_Click(object sender, EventArgs e)
        {
            bool esNeutral = Convert.ToBoolean(lbNeutral.Text);
            var cmbResultLocal = cmbLocal.SelectedIndex;
            var cmbResultVisitante = cmbVisitante.SelectedIndex;

            bool haceFalta = cmbResultLocal == -1 || cmbResultVisitante == -1;

            if (haceFalta)
                MessageBox.Show("No están completos los datos de los rivales", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            else
            {
                string _out = Liga.Partido((short)cmbResultLocal, (short)cmbResultVisitante, esNeutral);
                string resultado = $"El resultado es {_out}";
                MessageBox.Show(resultado, "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
