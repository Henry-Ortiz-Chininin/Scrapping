using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELSearchFight
{
    public class entSearch:entNavigator
    {
        public int SearchId { get; set; }
        public string Query { get; set; }
        public string Result { get; set; }
        public Int64 CountResults { get; set; }
    }
}
