using MySql.Data.MySqlClient;
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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection("server=127.0.0.1;userid=root;password=root;database=gerenciamentotarefas");

                conn.Open();

                MySqlCommand command = new MySqlCommand("INSERT INTO `tarefas` (`nomeTarefa`, `descricao`, `dataTarefa`, `prioridade`,`concluido`) VALUES (@Nome,@Descricao,@Data,@Prioridade,@Concluido)", conn);

                command.Parameters.AddWithValue("@Nome", txbNome.Text);

                command.Parameters.AddWithValue("@Descricao", txbDescricao.Text);

                command.Parameters.AddWithValue("@Data", dtpData.Value.ToString("dd-MM-yyyy"));

                command.Parameters.AddWithValue("@Prioridade", cbPrioridade.SelectedItem.ToString());

                command.Parameters.AddWithValue("@Concluido", "N");

                command.ExecuteNonQuery();

                conn.Close();

            }
            catch (Exception ex) { MessageBox.Show($"Erro ao ler o arquivo: {ex.Message}"); }

            finally
            {
                txbNome.Text = "";
                txbDescricao.Text = "";
                cbPrioridade.SelectedItem = "";
                DataGridHell();
            }
        }

        private void DataGridHell()
        {
            MySqlConnection conn = new MySqlConnection("server=127.0.0.1;userid=root;password=root;database=gerenciamentotarefas");

            MySqlCommand command = new MySqlCommand("SELECT `nomeTarefa`, `descricao`, `dataTarefa`, `prioridade` FROM `tarefas`", conn);

            MySqlDataAdapter adapter = new MySqlDataAdapter(command);

            DataTable table = new DataTable();

            adapter.Fill(table);

            conn.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
