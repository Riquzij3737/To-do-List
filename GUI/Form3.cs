using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace To_do_List_List.GUI
{
    public partial class Form3 : Form
    {


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
            } else
            {
                
            }

        }
    }
}
