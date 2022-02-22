using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.AppendText("Form 1 wird geladen \r\n");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.AppendText("Button 1 wurde geklickt " + Environment.NewLine);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.AppendText("Button 2 wurde geklickt" + Environment.NewLine);
        }
    }
}
