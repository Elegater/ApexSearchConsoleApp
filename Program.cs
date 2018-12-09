using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;
using System.Data;

namespace ApexSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(String.Format("Credits to Network2501 for collating the data on all the apexes" + Environment.NewLine));
            ExcelReader reader = new ExcelReader(@".\Data.xlsx", 2, 1);

            List<Apex> apexes = reader.Read();

            ////Console.WriteLine(data.Columns + " " + data.Rows);

            //for(int row = 2; row <= data.Rows; row++)
            //{
            //    string ship = data[row, 2].Value.ToString();
            //    string rank = data[row, 2].Value.ToString();
            //    apexes.Add(new Apex(data[row, 1].Text, data[row, 2].Text, data[row, 3].Text, data[row, 4].Text, data[row, 5].Text, data[row, 6].Text, data[row, 7].Text, data[row, 8].Text));
            //}

            //Console.WriteLine(apexes.Count);

            while (true)
            {
                Console.Write("Search by ship name and apex name / rank: ");
                string searchTerm = Console.ReadLine();
                string[] terms = searchTerm.Split(' ');

                List<Apex> results = new List<Apex>();

                if(terms.Length == 1)
                {
                    List<Apex> individualResult = apexes.Where(x => x.Ship.ToLower().Trim().Contains(terms[0].Replace('_', ' ').ToLower().Trim()) || x.Name.ToLower().Trim().Contains(terms[0].Replace('_', ' ').ToLower().Trim())).ToList<Apex>();
                    results.AddRange(individualResult);
                }
                else if(terms.Length == 2)
                {
                    List<Apex> individualResultName = apexes.Where(x => x.Ship.ToLower().Trim().Contains(terms[0].Replace('_', ' ').ToLower().Trim()) && x.Name.ToLower().Trim().Contains(terms[1].Replace('_', ' ').ToLower().Trim())).ToList<Apex>();
                    List<Apex> individualResultRank = apexes.Where(x => x.Ship.ToLower().Trim().Contains(terms[0].Replace('_', ' ').ToLower().Trim()) && x.Rank.ToLower().Trim().Contains(terms[1].ToLower().Trim())).ToList<Apex>();

                    results.AddRange(individualResultName);
                    results.AddRange(individualResultRank);
                }

                if(results.Count > 0)
                {
                    foreach(Apex a in results)
                    {
                        Console.WriteLine(a.ToString() + Environment.NewLine);
                    }

                    Console.WriteLine("----------------" + Environment.NewLine);
                }
                else
                {
                    Console.WriteLine(String.Format("No results were found matching the search term '{0}'\r\n", searchTerm));
                }
            }
        }
    }
}
