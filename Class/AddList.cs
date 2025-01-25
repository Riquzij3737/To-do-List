using System.Data.SQLite;
using To_do_List_List;

namespace To_do_List_List
{
    public class addList
    {
        public Panel panelTarefas;
              
        public addList(Panel panel)
        {
            panelTarefas = panel;
        }

        public async Task Addtask(string task, string connectionString)
        {
            SQLiteConnection conn = new SQLiteConnection(connectionString);            

            // Criar um novo painel para a nova tarefa
            Panel newTaskPanel = new Panel
            {
                BackColor = Color.LightGoldenrodYellow,
                BorderStyle = BorderStyle.FixedSingle,
                Size = new Size(289, 70)
            };

            // Criar o CheckBox para a tarefa
            CheckBox newTaskCheckBox = new CheckBox
            {
                AutoSize = true,
                Font = new Font("Segoe UI", 11F),
                Text = task,
                Location = new Point(3, 20)
            };

            newTaskCheckBox.CheckedChanged += async (sender, e) =>
            {
                await conn.OpenAsync();

               using (SQLiteCommand cmd = conn.CreateCommand())
                {
                    cmd.Parameters.Clear();  // Limpar parâmetros anteriores
                    if (newTaskCheckBox.Checked)
                    {
                        newTaskCheckBox.Font = new Font(newTaskCheckBox.Font, FontStyle.Strikeout);
                        cmd.CommandText = "UPDATE Tarefas SET Concluida = \"Sim\" WHERE Nome = @Nome";
                    }
                    else
                    {
                        newTaskCheckBox.Font = new Font(newTaskCheckBox.Font, FontStyle.Regular);
                        cmd.CommandText = "UPDATE Tarefas SET Concluida = \"Não\" WHERE Nome = @Nome";
                    }

                    cmd.Parameters.AddWithValue("@Nome", task);
                    await cmd.ExecuteNonQueryAsync();
                }

               await conn.CloseAsync();
            };

            // Criar o botão para remover a tarefa
            Button removeButton = new Button
            {
                BackColor = Color.Brown,
                FlatStyle = FlatStyle.Popup,
                Font = new Font("Showcard Gothic", 10.2F, FontStyle.Bold),
                Text = "X",
                Size = new Size(25, 27),
                Location = new Point(265, 0)
            };

            removeButton.Click += async (sender, e) =>
            {
                await conn.OpenAsync();

                using (SQLiteCommand cmd = conn.CreateCommand())
                {
                    panelTarefas.Controls.Remove(newTaskPanel); // Remove o painel da lista

                    cmd.Parameters.Clear(); // Limpar parâmetros anteriores

                    cmd.CommandText = "DELETE FROM Tarefas WHERE Nome = @Nome";
                    cmd.Parameters.AddWithValue("@Nome", task);

                    await cmd.ExecuteNonQueryAsync();
                }

                await conn.CloseAsync();
            };

            // Adicionar o CheckBox e o botão ao painel da nova tarefa
            newTaskPanel.Controls.Add(newTaskCheckBox);
            newTaskPanel.Controls.Add(removeButton);

            int taskCount;

            // Determinar a posição do novo painel baseado nas tarefas já existentes
            try
            {                
                    taskCount = panelTarefas.Controls.Count;
                    newTaskPanel.Location = new Point(13, 17 + (taskCount * 75)); // Ajusta a posição para a próxima tarefa
                
            } catch (NullReferenceException)
            {
                newTaskPanel.Location = new Point(13, 17);
            }

            // Adicionar o painel da nova tarefa ao painel principal
            panelTarefas.Controls.Add(newTaskPanel);

            // fechando a conexão
            conn.Close();

        }
    }
}
