using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PKUBank
{
    class Account
    {
        internal static string money
        {
            set;
            get;
        }
        static string id;
        static string pwd;
        //string name;
        static public string getId()
        {
            return id;
        }
        static public void setId(string tempid)
        {
            id = tempid;
        }
        static public string getPwd()
        {
            return pwd;
        }
        static public void setPwd(string temppwd)
        {
            pwd = temppwd;
        }
        
       
    }
}
