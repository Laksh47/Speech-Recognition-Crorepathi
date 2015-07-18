using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace voice
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals("game"))
            {
                if (textBox2.Text.Equals("pass"))
                {
                    string s = textBox3.Text;
                    Form1 ob = new Form1(s);
                    ob.Show();
                    this.Hide();
                }

            }
            else
            {
                MessageBox.Show("ENTER CORRECT USERNAME AND PASSWORD");
            }

            

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
