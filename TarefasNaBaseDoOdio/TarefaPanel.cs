using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TarefasNaBaseDoOdio
{
    public partial class TarefaPanel : UserControl
    {
        public TarefaPanel()
        {
            InitializeComponent();
        }

        public void ConfigurarTarefa(string titulo, string descricao, string prioridade, string data)
        {
            lblName.Text = titulo;  
            lblDesc.Text = descricao;
            lblPriori.Text = prioridade;
            lblData.Text = data;
        }

        private void TarefaPanel_Load(object sender, EventArgs e)
        {

        }
    }
}
