using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System.Configuration;
using ELSearchFight;

namespace DLSearchFight
{
    public class daNavigators:iNavigators
    {
        public daNavigators()
        {

        }

        public List<entNavigator> getNavigators()
        {
            try
            {
                using (StreamReader r = new StreamReader(ConfigurationManager.AppSettings["NavigatorsList"].ToString()))
                {
                    string json = r.ReadToEnd();
                    return JsonConvert.DeserializeObject<List<entNavigator>>(json);
                }
            }
            catch (Exception ex)
            {
                return new List<entNavigator>();
            }

        }
    }
}
