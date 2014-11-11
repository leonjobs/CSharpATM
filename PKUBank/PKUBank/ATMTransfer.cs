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
    public partial class ATMTransfer : Form
    {
       
        public ATMTransfer()
        {
            InitializeComponent();
            this.ControlBox = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //进行文本匹配和检查，以便于正常交易
            if(!Bank.FindAccount(textBox1.Text))
            {
                ATM.ShowAccountMessage("没有此账号");
                return ;
            }
            if(!ATM.CheckEmpty(textBox2.Text) || !ATM.CheckIsNum(textBox2.Text))
            {
                ATM.ShowAccountMessage("金额输入框出错");
                return;
            }
            if (Convert.ToInt32(textBox2.Text) >= 10000)
            {
                Bank.CheckEvent += Bank.EventPopUp;
            }
            if(!Bank.DrawAccountMoney(Account.getId(), Account.getPwd(), textBox2.Text))
            {
                ATM.ShowAccountMessage("账户余额不足");
                Bank.CheckEvent -= Bank.EventPopUp;
                return;
            }
            Bank.TransferMoney(textBox1.Text,  textBox2.Text);
            ATM.ShowAccountMessage("转账成功");
            Bank.CheckEvent -= Bank.EventPopUp;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new ATMOperate().Show();
        }
    }
}
