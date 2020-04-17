using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace GeneticAlgorithm_DS
{
    public class FileReader
    {
        public static void ReadFile()
        {
            var envPath = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;
            var filePath = envPath + "/Files/RetailMart.xlsx";
            List<string> list = new List<string>();

            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(filePath);
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[3];
            Excel.Range xlRange = xlWorksheet.UsedRange;

            int rows;
            int columns;

            rows = xlRange.Rows.Count;
            //Work in progress
            columns = xlRange.Columns.Count;

            for (int i = 8; i < 1008; i++)
            {
                for (int j = 2; j < 22; j++)
                {
                    if (xlRange.Cells[i, j] != null && xlRange.Cells[i, j].value2 != null)
                    {
                        Console.Write(xlRange.Cells[i, j].Value2.ToString() + "\t");
                    }
                }
            }

        }
    }
}
