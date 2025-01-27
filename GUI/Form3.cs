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
using To_do_List_List.Security;

namespace To_do_List_List.GUI
{
    public partial class Form3 : Form
    {
        public readonly string connectionString = MakeMysqlKey.MakeKey("Users_Tasksoftwares");

        public Form3()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox2.Text) || String.IsNullOrEmpty(textBox1.Text))
            {
                throw new ArgumentNullException("Oq tu quer q eu faça? adiciona um usuario no banco de dados sem ter a senha ou nome?\n Vai toma no seu cu:D");
            }
            else
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    using (MySqlCommand cmd = conn.CreateCommand())
                    {
                        Encryptor encryptor = new Encryptor();

                        string textocriptografado = encryptor.Encryp(textBox2.Text);
                        string acessadortabela = textBox1.Text + "_Tsk";

                        cmd.Parameters.Clear();
                        cmd.CommandText = "INSERT INTO Users_tb (Nome, Senha, TBL_Tasks) VALUES (@Nome, @Senha, @TBL_Tasks)";

                        cmd.Parameters.AddWithValue("@Nome", textBox1.Text);
                        cmd.Parameters.AddWithValue("@Senha", textocriptografado);
                        cmd.Parameters.AddWithValue("@TBL_Tasks", acessadortabela);

                        try
                        {
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Conta criada com sucesso!", "To-Do-List", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                            this.Close();

                            cmd.CommandText =

                            Form1 form = new Form1();

                            form.ShowDialog();

                            

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Erro: {ex}", "Tratamento de erros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        finally
                        {
                            conn.Close();

                            GC.Collect(conn.GetHashCode());

                        }

                    }
                }
            }
        }

    }
}

