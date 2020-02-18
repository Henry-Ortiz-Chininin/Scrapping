using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System.Configuration;
using ELSearchFight;

namespace DLSearchFight
{
    public interface iNavigators
    {
        List<entNavigator> getNavigators();
    }
}
