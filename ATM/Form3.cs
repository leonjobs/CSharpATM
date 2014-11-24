using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;

namespace ATM
{
    public partial class Form3 : Form
    {
        public OleDbConnection getConn()
    {
        string connstr="Provider=Microsoft.Jet.OLEDB.4.0 ;Data Source=F:\\ATM.accdb";
        OleDbConnection tempconn= new OleDbConnection(connstr);
        return(tempconn);
    }         

        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //OleDbConnection conn = getConn(); //getConn():得到连接对象
            //conn.Open();

            //string insertstr = "INSERT INTO ATMTable(Card, Password, Money) VALUES ('";
            //insertstr += ATMTable.Card + "','";
            //insertstr += ATMTable.Password + "','";
            //insertstr += ATMTable.Money + "')";

            //OleDbCommand insertcmd = new OleDbCommand(insertstr, conn);
            //insertcmd.ExecuteNonQuery();


        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
