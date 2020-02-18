using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ULSeachFight
{
    public interface iQueryTools
    {
        List<string> QueryTerms(string sQuery);
        long getNumber(string sResult);
    }
}
