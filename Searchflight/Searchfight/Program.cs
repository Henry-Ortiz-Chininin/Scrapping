using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using ELSearchFight;
using BLSearchFight;

namespace Searchfight
{
    class Program
    {
        protected static ibizSearch bsearch;

        static void Main(string[] args)
        {
            
            var builder = new ContainerBuilder();
            builder.RegisterType<bizSearch>().As<ibizSearch>();
            var container = builder.Build();

            bsearch = container.Resolve<ibizSearch>();
            List<entSearchTerm> searchResults = bsearch.getSearchResults(args);

            foreach(entSearchTerm item in searchResults)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(item.Term);
                foreach(entSearch result in item.Results)
                {
                    sb.Append(String.Format(" {0} {1} ", result.Name, result.CountResults));
                }
                Console.WriteLine(sb);
            }


            Console.WriteLine("PressKey to finish");
            Console.ReadKey();

            

        }
    }
}
