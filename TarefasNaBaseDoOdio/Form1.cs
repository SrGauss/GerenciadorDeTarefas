using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using MySql.Data.MySqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TarefasNaBaseDoOdio
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataGridHell();
            this.dgvInferno.Columns["id"].Visible = false;
        }

        private void DataGridHell()
        {
            MySqlConnection conn = new MySqlConnection("server=127.0.0.1;userid=root;password=root;database=gerenciamentotarefas");

            MySqlCommand command = new MySqlCommand("SELECT `id`,`nomeTarefa`, `descricao`, `dataTarefa`, `prioridade` FROM `tarefas`", conn);

            MySqlDataAdapter adapter = new MySqlDataAdapter(command);

            DataTable table = new DataTable();

            adapter.Fill(table);

            dgvInferno.DataSource = table;

            dgvInferno.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        public void dgvInferno_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell cell = dgvInferno.CurrentCell;

            int RowIndex = cell.RowIndex;

            string valorCelula = cell.Value.ToString(); //Valor da celula

            string ColumnName = dgvInferno.Columns[cell.ColumnIndex].Name; //Nome da Coluna

            //Aqui é para pegar o ID
            int id = dgvInferno.Columns["id"].Index;
            object IdValue = dgvInferno.Rows[RowIndex].Cells[id].Value;

            ArmazenaCoisa nova = new ArmazenaCoisa(valorCelula, ColumnName, IdValue.ToString());
        }

        public void dgvInferno_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
            DataGridHell();
        }

        private void dgvInferno_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DataGridViewRow row = e.Row;
       
            if (dgvInferno.Columns["id"] != null)
            {                
                object IdValue = row.Cells["id"].Value;

                if (!e.Row.IsNewRow)
                {
                    DialogResult res = MessageBox.Show("Tem certeza de que deseja deletar esta linha ?", "Deletar ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (res == DialogResult.No)
                    {
                        e.Cancel = true;
                    }
                    else if (res == DialogResult.Yes)
                    {
                        MySqlConnection conn = new MySqlConnection("server=127.0.0.1;userid=root;password=root;database=gerenciamentotarefas");

                        conn.Open();

                        MySqlCommand command = new MySqlCommand("DELETE FROM `tarefas` WHERE id = @id", conn);

                        command.Parameters.AddWithValue("@id", IdValue);

                        command.ExecuteNonQuery();

                        conn.Close();

                    }
                }

            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {

            string id = ArmazenaCoisa.IdValue.ToString();
            string coluna = ArmazenaCoisa.ColumnName.ToString();

            string valorNovo = ArmazenaCoisa.ValorCelula.ToString();



            string connectionString = "server=127.0.0.1;userid=root;password=root;database=gerenciamentotarefas";

            string query = $"UPDATE tarefas SET {coluna} = @valorNovo WHERE id = @id";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {

                    conn.Open();


                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {

                        cmd.Parameters.AddWithValue("@valorNovo", valorNovo);
                        cmd.Parameters.AddWithValue("@id", id);


                        int rowsAffected = cmd.ExecuteNonQuery();


                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Tarefa atualizada com sucesso!");
                        }
                        else
                        {
                            MessageBox.Show("Nenhuma linha foi atualizada.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro: {ex.Message}");
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dgvInferno.Update();
            dgvInferno.Refresh();
        }
    }
}
