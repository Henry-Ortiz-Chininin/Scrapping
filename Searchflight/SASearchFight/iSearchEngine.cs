using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ELSearchFight;

namespace SASearchFight
{
    public interface iSearchEngine
    {
        List<entSearch> getResults(string query, List<entNavigator> oNavigators);

    }
}
