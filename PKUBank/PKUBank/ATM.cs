using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace PKUBank
{
   class ATM
   {
       //检测是否只为数字
       static Regex RegexInText = new Regex("^(\\d|\b)+$");
       
       //检测是否为数字
       static public bool CheckIsNum( string a )
       {
           if (!RegexInText.IsMatch(a) && a != "")
           {
               return false;
           }
           else
           {
               return true;
           }
       }

       //检测是否为空
       static public bool CheckEmpty(string a)
       {
           if(a != "")
           {
               return true;
           }
           else
           {
               return false;
           }
       }


       //反馈信息
       static public void ShowAccountMessage(string a)
       {
           MessageBox.Show(a);
       }
    }
}
