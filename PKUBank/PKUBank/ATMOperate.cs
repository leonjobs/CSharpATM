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
    public partial class ATMOperate : Form
    {
        public ATMOperate()
        {
            InitializeComponent();
            this.ControlBox = false;
        }

        private void button1_Click(object sender, EventArgs e)//取款
        {
            //check and updata the money;
            if (!ATM.CheckEmpty(textBox1.Text) || !ATM.CheckIsNum(textBox1.Text))
            {
                ATM.ShowAccountMessage("输入信息有误");
                return;
            }
            if(Convert.ToInt32(textBox1.Text) >= 10000)
            {
                Bank.CheckEvent += Bank.EventPopUp;
            }
            if (Bank.DrawAccountMoney(Account.getId(), Account.getPwd(), textBox1.Text))
            {
                ATM.ShowAccountMessage("取款成功");
            }
            else
            {
                ATM.ShowAccountMessage("账户余额不足");
            }
            Bank.CheckEvent -= Bank.EventPopUp;
            textBox1.Text = "交互文本框";
        }

        private void button2_Click(object sender, EventArgs e)//存款
        {
            //check and updata the money; 
            if (!ATM.CheckEmpty(textBox1.Text) || !ATM.CheckIsNum(textBox1.Text))
            {
                ATM.ShowAccountMessage("输入信息有误");
                return;
            }
            Bank.UpdataAccountMoney(Account.getId(), Account.getPwd(), textBox1.Text);
            ATM.ShowAccountMessage("存款成功");
            textBox1.Text = "交互文本框";
            
        }

        private void button3_Click(object sender, EventArgs e)//更改密码
        {
            //check and updata the pwd;
            if (!ATM.CheckEmpty(textBox1.Text) || !ATM.CheckIsNum(textBox1.Text))
            {
                ATM.ShowAccountMessage("输入信息有误");
                return;
            }
            Bank.UpdateAccountPwd(Account.getId(), textBox1.Text);
            //Account.setPwd(textBox1.Text);
            ATM.ShowAccountMessage("密码更改成功");
            ATM.ShowAccountMessage("更改后的密码为："+ textBox1.Text +"，请牢记");
            textBox1.Text = "交互文本框";
        }

        private void button4_Click(object sender, EventArgs e)//查询余额
        {
            //check the money
            ATM.ShowAccountMessage("账户余额：" + Bank.CheckMoney(Account.getId(),Account.getPwd()));
        }

        private void button5_Click(object sender, EventArgs e)//转账
        {
            //new form to do this
            this.Hide();
            new ATMTransfer().Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            //抹掉相应的账户变量；
            new ATMLogin().Show();
        }
    }
}
