using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using ELSearchFight;
using DLSearchFight;
using SASearchFight;
using ULSeachFight;


namespace BLSearchFight
{
    public class bizSearch:ibizSearch
    {
        protected iNavigators navigators;
        protected iSearchEngine searchEngine;
        protected iQueryTools queryTools;
        public bizSearch()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<daNavigators>().As<iNavigators>();
            builder.RegisterType<SearchEngine>().As<iSearchEngine>();
            builder.RegisterType<QueryTools>().As<iQueryTools>();
            var container = builder.Build();

            navigators = container.Resolve<iNavigators>();
            searchEngine = container.Resolve<iSearchEngine>();
            queryTools = container.Resolve<iQueryTools>();
        }

        public List<entSearchTerm> getSearchResults(string[] sQuery)
        {
            List<entSearchTerm> searchResult = new List<entSearchTerm>();

            foreach (string sTerm in sQuery)
            {
                entSearchTerm searchTerm = new entSearchTerm();
                searchTerm.Term = sTerm;
                searchTerm.Results = searchEngine.getResults(sTerm, navigators.getNavigators());
                searchResult.Add(searchTerm);
            }

            return searchResult; 
        }


    }
}
