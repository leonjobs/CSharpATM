using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;

namespace PKUBank
{
    //Bank类保存着所有的数据处理功能，不断地与ATM交互
    class Bank
    {
        //List<Account> accounts = new List<Account>();
        //static string ConnecCmdSQL = "";
        private static string SqlCmdStr = "";
        private static string OleDBConnectStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=../pkubank.mdb";

        private static OleDbConnection OleDBConnectObject;


        public delegate void buildFormToCheck();
        public static event buildFormToCheck CheckEvent;
        
        public static OleDbConnection BuildConnectObject(string constr)//建立一个OleDbConnection对象
        {
            OleDBConnectObject = new OleDbConnection(constr);
            return OleDBConnectObject;
        }

        public static OleDbConnection GetOleDBConObject()
        {
            return OleDBConnectObject;
        }
        
        //根据SQL语句，和OleDbConnection对象建立数据库操作对象，并返回，以便之后进行操作。
        public static OleDbCommand BuildCommandObject(string SQLcmd, OleDbConnection connection)
        {
            OleDbCommand cmd = new OleDbCommand(SQLcmd, connection);
            return cmd;
        }


        public static void ExcuteSQLCmd(OleDbCommand cmd)//执行数据库操作命令；
        {
            cmd.ExecuteNonQuery();
        }


        public static void OpenDB(OleDbConnection connection)//打开数据库
        {
            connection.Open();
        }


        public static void CloseDB(OleDbConnection connection)//关闭数据库
        {
            connection.Close();
        }
        public static void UpdateAccountPwd(string id, string pwd)//更改密码
        {
            OpenDB(BuildConnectObject(OleDBConnectStr));
            SqlCmdStr = "update bank set [pwd] = '" + pwd + "' where [Accid] = '" + id + "'";
            BuildCommandObject(SqlCmdStr, GetOleDBConObject()).ExecuteNonQuery();
            CloseDB(GetOleDBConObject());
            Account.setPwd(pwd);
        }

        public static void TransferMoney(string id, string money)//存款
        {
            string TempStr = CheckMoneyById(id);
            TempStr = (Convert.ToInt32(TempStr) + Convert.ToInt32(money)).ToString();
            OpenDB(BuildConnectObject(OleDBConnectStr));
            SqlCmdStr = "update bank set [money] = '" + TempStr + "' where [Accid] = '" + id + "'";
            BuildCommandObject(SqlCmdStr, GetOleDBConObject()).ExecuteNonQuery();
            CloseDB(GetOleDBConObject());
            Account.money = TempStr;
        }

        public static void UpdataAccountMoney(string id, string pwd, string money)//存款
        {
            //UPDATE 表名称 SET 列名称 = 新值 WHERE 列名称 = 某值
            string TempStr = CheckMoney(id, pwd);
            TempStr = (Convert.ToInt32(TempStr) + Convert.ToInt32(money)).ToString();
            OpenDB(BuildConnectObject(OleDBConnectStr));
            SqlCmdStr = "update bank set [money] = '" + TempStr + "' where [Accid] = '" + id +"'";
            BuildCommandObject(SqlCmdStr, GetOleDBConObject()).ExecuteNonQuery();
            CloseDB(GetOleDBConObject());
            Account.money = TempStr;
        }

        public static void EventPopUp()
        {
            ATM.ShowAccountMessage("大金额交易请确认：\n您确定交易此金额吗");
        }

        public static bool DrawAccountMoney(string id, string pwd, string money)//取款
        {
            if(CheckEvent != null)
            {
                CheckEvent();

            }
            string TempStr = CheckMoney(id, pwd);
            //if (Convert.ToInt32(TempStr) < Convert.ToInt32(money))
            //{
            //    return false;
            //}
            try
            {
                int testNum = Convert.ToInt32(TempStr) - Convert.ToInt32(money);
                if (testNum < 0)
                    throw new BankError("NoMoneyError");
            }
            catch(BankError a)
            {
                return false;
            }
            TempStr = (Convert.ToInt32(TempStr) - Convert.ToInt32(money)).ToString();
            OpenDB(BuildConnectObject(OleDBConnectStr));
            SqlCmdStr = "update bank set [money] = '" + TempStr + "' where [Accid] = '" + id + "'";
            BuildCommandObject(SqlCmdStr, GetOleDBConObject()).ExecuteNonQuery();
            CloseDB(GetOleDBConObject());
            Account.money = TempStr;
            return true;
        }

        public static void OpenAccount(string id, string pwd)//注册一个账号
        {
            //进行数据库操作
           // bool TempBoolean = false;
            OpenDB(BuildConnectObject(OleDBConnectStr));
            SqlCmdStr = "insert into bank ([Accid],[pwd],[money]) values ('" + id + "','" + pwd + "','" + "0')";
            BuildCommandObject(SqlCmdStr, GetOleDBConObject()).ExecuteNonQuery();
            CloseDB(GetOleDBConObject());
            //MessageBox.Show("账户余额不足");
           //return TempBoolean;
        }


      //  public static bool CloseAccount(Account account)//删除某个账号account
      //  {
           //进行数据库操作
      //  }

        public static string CheckMoney(string id, string pwd)//返回账户余额：
        {
            string TempStr = "";
            OpenDB(BuildConnectObject(OleDBConnectStr));
            SqlCmdStr = "select * from bank where Accid ='" + id + "' and pwd = '"+ pwd +"'";
            OleDbDataReader datareader = BuildCommandObject(SqlCmdStr, GetOleDBConObject()).ExecuteReader();
            if (datareader.Read())
            {
                TempStr = datareader["money"].ToString();
            }
            CloseDB(GetOleDBConObject());
            return TempStr;
        }

        public static string CheckMoneyById( string id )//返回账户余额：
        {
            string TempStr = "";
            OpenDB(BuildConnectObject(OleDBConnectStr));
            SqlCmdStr = "select * from bank where Accid ='" + id + "'";
            OleDbDataReader datareader = BuildCommandObject(SqlCmdStr, GetOleDBConObject()).ExecuteReader();
            if (datareader.Read())
            {
                TempStr = datareader["money"].ToString();
            }
            CloseDB(GetOleDBConObject());
            return TempStr;
        }


        public static bool ToMatchIdAndPwd(string id, string pwd)//匹配账户和密码
        {
            bool TempBoolean = false;
            OpenDB(BuildConnectObject(OleDBConnectStr));
            SqlCmdStr = "select * from bank where Accid ='" + id + "' and pwd = '"+ pwd +"'";
            OleDbDataReader datareader = BuildCommandObject(SqlCmdStr, GetOleDBConObject()).ExecuteReader();
            if (datareader.Read())
            {
                TempBoolean = true;
            }
            CloseDB(GetOleDBConObject());
            return TempBoolean;
        }

        public static bool FindAccount(string id)//查找账户
        {
            bool TempBoolean = false;
            OpenDB(BuildConnectObject(OleDBConnectStr));
            SqlCmdStr = "select * from bank where Accid ='" + id + "'";
            OleDbDataReader datareader = BuildCommandObject(SqlCmdStr, GetOleDBConObject()).ExecuteReader();
            if(datareader.Read())
            {
                TempBoolean = true;
            }
            CloseDB(GetOleDBConObject());
            return TempBoolean;
        }
    }
}
