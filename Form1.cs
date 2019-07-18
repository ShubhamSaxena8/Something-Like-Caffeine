using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestWPApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }
        int pos1 = 0;
        int pos2 = 0;
        System.Threading.Thread t;
        Random random = new Random();
        [STAThread]
        private void DoThisAllTheTime()
        {
            while (true)
            {
               // you need to use Invoke because the new thread can't access the UI elements directly
                textBox1.AppendText($"{DateTime.Now.ToString()}\r\n");
                //Cursor.Position = new Point(random.Next(0,1366), random.Next(0, 738));
                SendKeys.SendWait("{BREAK}");
                System.Threading.Thread.Sleep(4000);
                MethodInvoker mi = delegate () { this.Text = DateTime.Now.ToString(); };
                this.Invoke(mi);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
                t = new System.Threading.Thread(DoThisAllTheTime); 
                t.Start();
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBox1.AppendText($"\r\nKeyPress keychar: {e.KeyChar}" + "\r\n");
            t.Abort();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            t.Abort();
        }
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBox1.AppendText($"\r\nKeyPress keychar: {e.KeyChar}" + "\r\n");
        }

        //private void Form1_Load(object sender, EventArgs e)
        //{
        //    SendKeys.SendWait("{J}");
        //}
    }
}