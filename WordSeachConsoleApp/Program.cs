using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordSeachConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcomet to Word Search App.");
            if (args == null && args.Length == 0)
            {
                Console.WriteLine("Please provide command for search.");
                return;
            }

            // assuming all the 3 inpus are given at this time
            // grep –v –i hello file:text.txt folder:C:\Directory url:http://www.lipsum.com
            string cmd = string.Join(" ", args);
            string strCmd = cmd.Replace("grep ", "");
            strCmd = strCmd.Replace("-v ", "");
            strCmd = strCmd.Replace("-i ", "");

            string[] arrayCmd = strCmd.Split(' ');
            if (arrayCmd.Length > 0)
            {
                ModelWordSearch modelWordSearch = new ModelWordSearch();

                modelWordSearch.isRverseSearch = args.Contains("-v");
                modelWordSearch.isCaseInSensitiveSearch = args.Contains("-i");
                modelWordSearch.textToSearch = arrayCmd[0];
                modelWordSearch.folder = arrayCmd[1];
                modelWordSearch.file = arrayCmd[2];
                modelWordSearch.uri = arrayCmd[3];

                // File Search
                ISearch search = new FileSearch();
                Console.WriteLine("Running");
                Console.WriteLine($"grep {modelWordSearch.folder}");

                search.Search(modelWordSearch);
                Console.WriteLine("Outputs");

                // Folder Search
                search = new FolderSearch();
                search.Search(modelWordSearch);

                // Folder Search
                search = new UrlSearch();
                search.Search(modelWordSearch);
            }

            Console.ReadLine();
        }
    }
}
