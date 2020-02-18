using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ULSeachFight
{
    public class QueryTools:iQueryTools
    {
        public QueryTools()
        {

        }

        public List<string> QueryTerms(string sQuery)
        {
            return sQuery.Split(' ').ToList<string>();
        }

        public Int64 getNumber(string sResult)
        {
            var oNumbers = (from t in sResult
                              where char.IsDigit(t)
                              select t).ToArray();
            return Convert.ToInt64(new string(oNumbers));
        }

    }
}
