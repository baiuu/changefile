using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace changefile
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label3.Text = "Example";
            label4.Text = "";
            //初始显示的目录
            openFileDialog1.InitialDirectory = @"F:\zmz";
            //操作完后恢复为原有的目录
            openFileDialog1.RestoreDirectory = true;
            //filter是设置打开文件对话框　文件类型的下拉列表子项为 txt files(*.txt)和all files(*.*)共2个子项
            //filter的值全是一对对的，比如 bat files(*.bat)|*.bat，以|分隔的2部分
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*|bat files(.bat)|*.bat|ass files(.ass)|*.ass|m4a files(.m4a)|*.m4a";
            //filterindex与上个属性filter关联对应；它是显示打开文件对话框时默认显示的文件类型下拉列表的子项内容
            openFileDialog1.FilterIndex = 2;//默认是1
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            { textBox1.Text = openFileDialog1.FileName; }
            FileInfo file = new FileInfo(textBox1.Text);
            string a = file.Extension;
            label4.Text = label3.Text + textBox2.Text + a;
            label3.Text = label3.Text + a;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
