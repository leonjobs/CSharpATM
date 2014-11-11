using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PKUBank
{
    public partial class BankError: ApplicationException
    {
        //a可以表示错误
        public BankError(string a) : base(a) { }
    }
}
