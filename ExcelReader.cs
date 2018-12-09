using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;
using System.IO;

namespace ApexSearch
{
    class ExcelReader
    {

        public ExcelReader(string filePath, int startRow, int startCol)
        {
            this.FilePath = filePath;
            this.StartRow = startRow;
            this.StartCol = startCol;
        }

        public string FilePath { get; set; }
        public int StartRow { get; set; }
        public int StartCol { get; set; }
        
        public List<Apex> Read()
        {
            FileInfo fi = new FileInfo(this.FilePath);
            ExcelRange data = null;
            List<Apex> apexes = new List<Apex>();

            if (!File.Exists(fi.FullName))
            {
                Console.WriteLine("Incorrect file name");
            }
            using (ExcelPackage p = new ExcelPackage(fi))
            {
                ExcelWorkbook wb = p.Workbook;
                ExcelWorksheet ws = wb.Worksheets[1];
                data = ws.Cells;

                int endRow = 0;
                int endCol = 0;
                bool lastRowFound = false;
                bool lastColFound = false;

                for (int i = this.StartRow; !lastRowFound; i++)
                {
                    if (String.IsNullOrEmpty(ws.Cells[i, this.StartCol].Text))
                    {
                        lastRowFound = true;
                    }
                    else
                    {
                        endRow = i;
                    }
                }

                for (int i = this.StartRow; !lastColFound; i++)
                {
                    if (String.IsNullOrEmpty(ws.Cells[this.StartRow, i].Text))
                    {
                        lastColFound = true;
                    }
                    else
                    {
                        endCol = i;
                    }
                }

                for(int row = StartRow; row <= endRow; row++)
                {
                    apexes.Add(new Apex(data[row, StartCol].Text, data[row, StartCol + 1].Text, data[row, StartCol + 2].Text, data[row, StartCol + 3].Text, data[row, StartCol + 4].Text, data[row, StartCol + 5].Text, data[row, StartCol + 6].Text, data[row, StartCol + 7].Text, data[row, StartCol + 8].Text, data[row, StartCol + 9].Text));
                }
            }
            return apexes;
        }
    }
}
