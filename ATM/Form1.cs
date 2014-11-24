using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

using System.Data.Common;
using System.Linq;
using System.Data.OleDb;


namespace ATM
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

       // private static Regex regexInText = new Regex("^-?((\\d|\b)+)$");
       // private bool OnlyNum;
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("感谢使用，走好不送");
            Application.Exit();
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //if (!regexInText.IsMatch(textBox1.Text) && textBox1.Text != "")
            //{
            //    MessageBox.Show("请输入0~9数字");
            //    OnlyNum = false;

            //}
            //else
            //    OnlyNum = true;
     

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //if (!regexInText.IsMatch(textBox2.Text) && textBox2.Text != "")
            //{
            //    MessageBox.Show("请输入0~9数字");
            //    OnlyNum = false;

            //}
            //else
            //    OnlyNum = true;
     

        }
    }
}
