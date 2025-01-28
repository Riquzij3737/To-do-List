﻿using MySql.Data.MySqlClient;
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
                        cmd.CommandText = $@"CREATE TABLE `tasks_db`.`{acessadortabela}` (
                                                    `ID` INT NOT NULL AUTO_INCREMENT,
                                                     `Nome` VARCHAR(45) NOT NULL,
                                                     `Concluida` VARCHAR(3) NOT NULL,
                                                     `Categoria` VARCHAR(45) NOT NULL,
                                                     PRIMARY KEY (`ID`));
                                                ";

                        try
                        {
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Conta criada com sucesso!", "To-Do-List", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                            
                            Form1 form = new Form1();

                            Form1.Acessor = acessadortabela;

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

        private void button1_Click(object sender, EventArgs e)
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
                        cmd.CommandText = "select * from users_tb";

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Descryptor descryptor = new Descryptor();

                                string senha = descryptor.DescryptText(reader["Senha"].ToString());

                                if (textBox1.Text == reader["Nome"].ToString() && textBox2.Text == senha)
                                {
                                    MessageBox.Show("Conta acessada com sucesso com sucesso!", "To-Do-List", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                                    Form1 form = new Form1();
                                    Form3 form3 = new Form3();
                                    Form1.Acessor = reader["TBL_Tasks"].ToString();
                                    form.ShowDialog();                                    
                                    

                                    break;
                                } else
                                {
                                    MessageBox.Show("Acesso negado!");
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}

