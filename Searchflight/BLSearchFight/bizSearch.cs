using System;
using System.Collections.Generic;
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

            navigators = new daNavigators();
            searchEngine = new SearchEngine();
            queryTools = new QueryTools();
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
