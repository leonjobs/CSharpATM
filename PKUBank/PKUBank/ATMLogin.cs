using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PKUBank
{
    public partial class ATMLogin : Form
    {
        public ATMLogin()
        {
            InitializeComponent();
            this.ControlBox = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();// exit the app;
        }

        private void button1_Click(object sender, EventArgs e)//是否已经注册
        {
            //与数据库中的信息比较
            //进行文本匹配
            if (!ATM.CheckEmpty(textBox1.Text) || !ATM.CheckEmpty(textBox2.Text))
            {
                ATM.ShowAccountMessage("请输入正确信息");
                return ;
            }
            if(!ATM.CheckIsNum(textBox1.Text) || !ATM.CheckIsNum(textBox2.Text))
            {
                ATM.ShowAccountMessage("请输入正确信息");
                return;
            }

            //检测数据
            //
            if(!Bank.FindAccount(textBox1.Text))
            {
                Bank.OpenAccount(textBox1.Text, textBox2.Text);
                ATM.ShowAccountMessage("账户注册成功");
            }
            else
            {
                ATM.ShowAccountMessage("已有此账号，不需要重复注册");
            }

        }

        private void button2_Click(object sender, EventArgs e)//可以登录否？
        {
            if (!ATM.CheckEmpty(textBox1.Text) || !ATM.CheckEmpty(textBox2.Text))
            {
                ATM.ShowAccountMessage("请输入正确信息");
                return;
            }
            if (!ATM.CheckIsNum(textBox1.Text) || !ATM.CheckIsNum(textBox2.Text))
            {
                ATM.ShowAccountMessage("请输入正确信息");
                return;
            }
            //与数据库中的信息比较
            //新的界面；
            if(Bank.ToMatchIdAndPwd(textBox1.Text, textBox2.Text))
            {
                //标记一个当前账号；可以保存在ATM static 变量中，或者保存在Bank类中，
                this.Hide();
                Account.setId(textBox1.Text);
                Account.setPwd(textBox2.Text);
                Account.money = Bank.CheckMoney(textBox1.Text, textBox2.Text);
                new ATMOperate().Show();
            }
            else
            {
                ATM.ShowAccountMessage("账号与密码不匹配");
            }
        }
    }
}
