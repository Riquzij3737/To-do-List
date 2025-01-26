// Importo o Mysql e o namespace padrão da aplicação
using MySql.Data.MySqlClient;
using To_do_List_List;

// Adiciona a classe a seguir dentro do namespace padrão da aplicação
namespace To_do_List_List
{
    // Crio a classe para conter o método AddList
    public class addList
    {
        // Crio um objeto global para o painel utilizado
        public Panel panelTarefas;

        // Crio o construtor da classe addList
        public addList(Panel panel)
        {
            panelTarefas = panel; // Atribuo o painel passado ao construtor ao objeto global panelTarefas
        }

        // Crio o método Addtask, para adicionar uma tarefa ao painel
        public async Task Addtask(string task, string Concluida, Categoria categoria, string connectionString)
        {
            MySqlConnection conn = new MySqlConnection(connectionString); // Crio a conexão com o banco de dados

            // Criar um novo painel para a nova tarefa
            Panel newTaskPanel = new Panel
            {
                BackColor = Color.LightGoldenrodYellow,
                BorderStyle = BorderStyle.FixedSingle,
                Size = new Size(289, 100), // Aumentei o tamanho para garantir espaço para a categoria
            };

            // Criar painel da categoria
            Panel panelCategoria = new Panel
            {
                BorderStyle = BorderStyle.FixedSingle,
                Size = new Size(264, 27), // Largura ajustada para cobrir a área do painel
                Location = new Point(0, 0) // Garantir que o painel da categoria fique no topo
            };

            // Criar label da categoria
            Label labelCategoria = new Label
            {
                AutoSize = true,
                Font = new Font("Segoe UI", 9F),
                Location = new Point(5, 5) // Ajuste de localização
            };

            // Definir cor e texto baseado na categoria
            switch (categoria)
            {
                case Categoria.Nulo:
                    panelCategoria.BackColor = Color.Blue;
                    labelCategoria.Text = "Nulo";
                    break;
                case Categoria.Relativa:
                    panelCategoria.BackColor = Color.Green;
                    labelCategoria.Text = "Relativa";
                    break;
                case Categoria.Importante:
                    panelCategoria.BackColor = Color.Yellow;
                    labelCategoria.Text = "Importante";
                    break;
                case Categoria.Muito_importante:
                    panelCategoria.BackColor = Color.Orange;
                    labelCategoria.Text = "Muito Importante";
                    break;
                case Categoria.BEI:
                    panelCategoria.BackColor = Color.Red;
                    labelCategoria.Text = "BEI";
                    break;
            }

            // Adicionar o label ao painel da categoria
            panelCategoria.Controls.Add(labelCategoria);

            // Criar o CheckBox para a tarefa
            CheckBox newTaskCheckBox = new CheckBox
            {
                AutoSize = true,
                Font = new Font("Segoe UI", 11F),
                Text = task,
                Location = new Point(5, 35) // Posição ajustada para abaixo do painel da categoria
            };

            // Verifico se o parâmetro concluída é igual a "Sim", se for, marco o checkbox como marcado
            if (Concluida == "Sim")
            {
                newTaskCheckBox.Checked = true;
                newTaskCheckBox.Font = new Font(newTaskCheckBox.Font, FontStyle.Strikeout);
            }
            else // Se não, marco o checkbox como desmarcado
            {
                newTaskCheckBox.Checked = false;
                newTaskCheckBox.Font = new Font(newTaskCheckBox.Font, FontStyle.Regular);
            }

            // Adiciono um evento ao checkbox, para marcar a tarefa como concluída ou não
            newTaskCheckBox.CheckedChanged += async (sender, e) =>
            {
                await conn.OpenAsync(); // Abro uma conexão com o banco de dados

                using (MySqlCommand cmd = conn.CreateCommand())
                {
                    cmd.Parameters.Clear(); // Limpar parâmetros anteriores
                    if (newTaskCheckBox.Checked)
                    {
                        newTaskCheckBox.Font = new Font(newTaskCheckBox.Font, FontStyle.Strikeout);
                        cmd.CommandText = "UPDATE Tarefas SET Concluida = \"Sim\" WHERE Nome = @Nome"; // Marcando sim
                    }
                    else
                    {
                        newTaskCheckBox.Font = new Font(newTaskCheckBox.Font, FontStyle.Regular);
                        cmd.CommandText = "UPDATE Tarefas SET Concluida = \"Não\" WHERE Nome = @Nome"; // Marcando não
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

            // Adiciono um evento ao botão, para remover a tarefa
            removeButton.Click += async (sender, e) =>
            {
                await conn.OpenAsync();

                using (MySqlCommand cmd = conn.CreateCommand())
                {
                    panelTarefas.Controls.Remove(newTaskPanel); // Remove o painel da lista
                    cmd.Parameters.Clear(); // Limpar parâmetros anteriores
                    cmd.CommandText = "DELETE FROM Tarefas WHERE Nome = @Nome";
                    cmd.Parameters.AddWithValue("@Nome", task);
                    await cmd.ExecuteNonQueryAsync();
                }

                await conn.CloseAsync(); // Fecho a conexão
            };

            // Adicionar os controles ao painel da nova tarefa
            newTaskPanel.Controls.Add(panelCategoria);
            newTaskPanel.Controls.Add(newTaskCheckBox);
            newTaskPanel.Controls.Add(removeButton);

            // Determinar a posição do novo painel baseado nas tarefas já existentes
            int taskCount = panelTarefas.Controls.Count;
            newTaskPanel.Location = new Point(13, 17 + (taskCount * 105)); // Ajusta a posição para a próxima tarefa

            // Adicionar o painel da nova tarefa ao painel principal
            panelTarefas.Controls.Add(newTaskPanel);

            await conn.CloseAsync(); // Fechar conexão
        }
    }
}
