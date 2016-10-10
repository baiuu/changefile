using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace changefile
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择文件路径";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string foldPath = dialog.SelectedPath;
                textBox1.Text = foldPath;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择文件路径";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string foldPath = dialog.SelectedPath;
                textBox2.Text = foldPath;
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (textBox1.Text.Length == 0)
            {
                MessageBox.Show("请填写目标路径！", "警告");
            }
            else
            {
                string address = textBox1.Text;
                string[] path = Directory.GetFiles(@address);
                int count = Convert.ToInt32(textBox3.Text);
                int counts = path.Length;
                string[] add = new string[counts];
                int n;
                int co = count;
                string a = "";
                int x = 1;
                int b = 0;
                for (n = 0; n < counts; n++)
                {
                    if (n >= Math.Pow(10, x)-1)
                    {
                        b = x++;
                    }
                }
                for (n = 0; n < counts; n++)
                {
                    x = 1;
                    if (n >= Math.Pow(10, x))
                    {
                        x++;
                    };
                    for (co = count + b + 2 - x; co > 1; co--)
                    {
                        a = a + "0";
                    }
                    add[n] = a + Convert.ToString(n);
                    a = "";
                }
                progressBar1.Value = 0;
                progressBar1.Minimum = 0;
                progressBar1.Maximum = counts - 1;
                for (n=0;n< counts;n++)
                {
                    string z;
                    if (textBox4.Text.Length == 0)
                    { z = ""; }
                    else
                    { z = "-"; }
                    progressBar1.Value = n;
                    FileInfo file = new FileInfo(path[n]);
                    string f = @address +"\\" +(textBox4.Text + z + add[n] + file.Extension);
                    if (File.Exists(@f))
                    {
                        string g = @address + "\\" + (textBox4.Text + z + add[n]+"(bak)" + file.Extension);
                        file.MoveTo(g);
                        file.MoveTo(f);
                    }
                    else
                    {
                        file.MoveTo(f);
                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (textBox1.Text.Length == 0||textBox2.Text.Length == 0 )
            {
                MessageBox.Show("请填写目标路径或复制路径！", "警告");
            }
            else
            {
                string change = textBox2.Text;
                string address = textBox1.Text;
                string[] path = Directory.GetFiles(@address);
                int count = Convert.ToInt32(textBox3.Text);
                int counts = path.Length;
                string[] add = new string[counts];
                int n;
                int co = count;
                string a="";
                int x = 1;
                int b = 0;
                for (n = 0; n < counts; n++)
                {
                    if (n >= Math.Pow(10, x) - 1)
                    {
                        b = x++;
                    }
                }
                for (n = 0; n < counts; n++)
                {
                    x = 1;
                    if (n >= Math.Pow(10, x))
                    {
                        x++;
                    };
                    for (co = count + b + 2 - x; co > 1; co--)
                    {
                        a = a + "0";
                    }
                    add[n] = a + Convert.ToString(n);
                    a = "";
                }
                progressBar1.Value = 0;
                progressBar1.Minimum = 0;
                progressBar1.Maximum = counts - 1;
                for (n = 0; n < counts; n++)
                {
                    string z;
                    if (textBox4.Text.Length == 0)
                    { z = ""; }
                    else
                    { z = "-"; }
                    progressBar1.Value = n;
                    FileInfo file = new FileInfo(path[n]);
                    string f = @change+ "\\" + (textBox4.Text + z + add[n] + file.Extension);
                    if (File.Exists(@f))
                    {
                        string g = @change + "\\" + (textBox4.Text + z + add[n] + file.Extension + ".bak");
                        string r = "C:\\Tmap\\" + file.FullName;
                        file.CopyTo(r);
                        file.Replace(f, g, true);
                        file.CopyTo(path[n]);
                    }
                    else
                    {
                        file.CopyTo(f);
                    }
                }
            }
        }
    }
}
