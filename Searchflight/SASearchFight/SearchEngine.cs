using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ELSearchFight;
using ULSeachFight;
using HtmlAgilityPack;
using System.Net;
using Autofac;


namespace SASearchFight
{
    public class SearchEngine:iSearchEngine
    {
        protected iQueryTools searchTools;

        public SearchEngine()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<QueryTools>().As<iQueryTools>();
            var container = builder.Build();
            searchTools = container.Resolve<iQueryTools>();
        }

        public List<entSearch> getResults(string query, List<entNavigator> oNavigators)
        {
            List<entSearch> listSearch = new List<entSearch>();
            foreach(entNavigator oNav in oNavigators)
            {
                string remotePath = string.Format(oNav.UrlBase, query);
                entSearch oSearch = new entSearch();

                using (WebClient oWebClient = new WebClient())
                {
                    oWebClient.UseDefaultCredentials = true;
                    byte[] oBuffer = oWebClient.DownloadData(remotePath);
                    string oResponse = System.Text.Encoding.ASCII.GetString(oBuffer);
                    var oPage = new HtmlDocument();
                    oPage.LoadHtml(oResponse);
                    var sResult = oPage.DocumentNode.SelectNodes(oNav.regexResult).ToList();

                    oSearch.IdNavigator = oNav.IdNavigator;
                    oSearch.Name = oNav.Name;
                    oSearch.Query = query;
                    oSearch.Result= sResult[0].InnerHtml;
                    oSearch.CountResults = searchTools.getNumber(oSearch.Result);
                    listSearch.Add(oSearch);
                }                    

            }
            return listSearch;
        }

    }
}
